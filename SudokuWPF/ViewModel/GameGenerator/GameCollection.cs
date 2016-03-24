//
//  
// 
// 
// 
// 
//
// 
// 

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;
using SudokuWPF.ViewModel.CustomEventArgs;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class GameCollection
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the GameCollection class.
        /// </summary>
        /// <param name="level">The level of difficulty for this instance.</param>
        internal GameCollection(DifficultyLevels level)
        {
            InitializeVariables(level);
        }

        #endregion

        #region . Event Handlers: Other Events .

        private void GameGeneratorEventHandler(object sender, GameGeneratorEventArgs e)
        {
            var count = 0; // Init the counter to zero.
            lock (_qLock) // Obtain a lock on the queue
            {
                if (_games == null) // Is the queue object null?
                    _games = new Queue<CellClass[,]>(); // Yes, then instantiate a new queue object
                _games.Enqueue(e.Cells); // Add the new game to the queue
                count = _games.Count;
            }
            RaiseEvent(count); // Raise an event with the new count
            _makeMoreGames.Set(); // Tell the background thread to make more games
        }

        #endregion

        #region . Variables, Constants, And other Declarations .

        #region . Constants .

        private const int _cDepth = 5; // Number of games to keep around

        #endregion

        #region . Variables .

        private DifficultyLevels _level;
        private Queue<CellClass[,]> _games;
        private object _qLock;
        private bool _stop;
        private AutoResetEvent _makeMoreGames;
        private GameGenerator _cGameGenerator;

        #endregion

        #region . Other Declarations .

        internal event EventHandler<GameManagerEventArgs> GameManagerEvent;

        #endregion

        #endregion

        #region . Properties: Public .

        /// <summary>
        ///     Gets the number of games in the queue.
        /// </summary>
        internal int GameCount
        {
            get
            {
                lock (_qLock) // Obtain a lock on the game queue.
                {
                    if (_games == null) // Is the queue object null?
                        _games = new Queue<CellClass[,]>(); // Yes, then instantiate a new queue object.
                    return _games.Count; // Return the count in the queue.
                }
            }
        }

        /// <summary>
        ///     Gets a game off the queue.
        /// </summary>
        internal CellClass[,] GetGame
        {
            get
            {
                try
                {
                    lock (_qLock) // Obtain a lock on the queue.
                    {
                        if (_games == null) // Is the queue object null?
                            _games = new Queue<CellClass[,]>(); // Yes, then instantiate a new queue object.
                        if (_games.Count > 0) // Any games in the queue?
                        {
                            var cells = _games.Dequeue(); // Yes, pop a game off the queue
                            RaiseEvent(_games.Count); // Raise a new event with the new count
                            _makeMoreGames.Set(); // Tell the background thread to create another game
                            return cells; // Return the game that was just removed.
                        }
                    }
                }
                catch (Exception)
                {
                    // TODO: What to do here?
                    // Maybe log the error in the Application.Event log?
                }
                return null; // Error ... just return null.
            }
        }

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Starts a thread to manage this queue.
        /// </summary>
        internal void StartThread()
        {
            CreateGames(); // Start the background thread to create games.
        }

        /// <summary>
        ///     Stop the thread that is managing this queue.
        /// </summary>
        internal void StopThread()
        {
            _stop = true; // Raise the stop flag
            _makeMoreGames.Set(); // Unblock the background thread if it is blocked
        }

        /// <summary>
        ///     Converts the games in the queue into a string that can be saved.
        /// </summary>
        /// <returns>A string that represents the games in the queue.</returns>
        internal string SaveGames()
        {
            try
            {
                lock (_qLock) // Obtain a lock on the game queue
                {
                    if (_games != null) // Is the queue object null?
                    {
                        var sTemp = new StringBuilder(); // No, then instantiate a string builder object
                        foreach (var item in _games.Where(item => item != null))
                            sTemp.Append(ConvertGameToString(item)); // Convert it to a string
                        return sTemp.ToString(); // Return the string of games
                    }
                    _games = new Queue<CellClass[,]>(); // Game object is null, so instantiate a new queue object
                }
            }
            catch (Exception)
            {
                // TODO: What to do here?
                // Maybe log error into Application.Event log?
            }
            return null; // Error somewhere, just return a null string
        }

        /// <summary>
        ///     Converts a string of saved games into the proper format.
        /// </summary>
        /// <param name="sGames">A string representing the saved games.</param>
        internal void LoadGames(string sGames)
        {
            if (!string.IsNullOrWhiteSpace(sGames)) // Is the input parameter null?
            {
                lock (_qLock) // No, obtain a lock on the queue object
                {
                    if (_games == null) // Is the queue object null?
                        _games = new Queue<CellClass[,]>(); // Yes, then instantiate a new queue objectc
                    var iPtr = 0; // Initialize the pointer to zero
                    while (sGames.Length > iPtr) // While there are more games to process
                    {
                        var sTemp = sGames.Substring(iPtr, 162); // Extract the game starting at the pointer
                        var cells = ConvertStringToGame(sTemp); // Convert the string to a game
                        if (cells != null) // Is the return value null?
                            _games.Enqueue(cells); // No, then save it to the queue
                        iPtr += 162; // Increment the pointer to the next game
                    }
                    RaiseEvent(_games.Count); // Done, raise an event with the new game count
                }
            }
        }

        #endregion

        #region . Methods: Private .

        private void InitializeVariables(DifficultyLevels level)
        {
            _level = level; // Save the difficulty level that we are managing
            _stop = false; // Default the stop flag to false
            _qLock = new object(); // Instantiate a new lock object
            _makeMoreGames = new AutoResetEvent(false); // Instantiate a new AutoResetEven object
            _cGameGenerator = new GameGenerator(level); // Instantiate the game creator object
            _cGameGenerator.GameGeneratorEvent += GameGeneratorEventHandler; // Add the event handler
            lock (_qLock) // Obtain a lock on the queue object
            {
                _games = new Queue<CellClass[,]>(); // Instantiate a new queue object
            }
        }

        private void CreateGames()
        {
            var t = new Thread(GameMaker) {IsBackground = true}; // Create a new thread
            // Set the thread to background mode
            t.Start(); // Start it
        }

        private void GameMaker()
        {
            do // Enter a loop
            {
                try
                {
                    lock (_qLock) // Obtain a lock on the queue object
                    {
                        if (_games == null) // Is the queue object null?
                            _games = new Queue<CellClass[,]>(); // Yes, then instantiate a new queue object
                        if (!_cGameGenerator.Busy && (_games.Count < _cDepth))
                            // Game creator not busy and we need more games?
                            _cGameGenerator.CreateNewGame(); // Yes, then create another game
                    }
                    _makeMoreGames.WaitOne(); // Wait for a signal to continue
                }
                catch (Exception)
                {
                    // TODO: What to do here?
                    // Maybe log the error to the Application.Event log?
                }
            } while (!_stop); // Keep looping until the stop flag is raised
        }

        private static string ConvertGameToString(CellClass[,] cells)
        {
            var sTemp = new StringBuilder(); // Instantiate a new string builder object
            for (var col = 0; col < 9; col++) // Loop through the columns
                for (var row = 0; row < 9; row++) // Loop through the rows
                    sTemp.Append(cells[col, row]); // Append to the string builder object
            return sTemp.ToString(); // Return the whole string
        }

        private static CellClass[,] ConvertStringToGame(string sInput)
        {
            if (sInput.Length >= 162) // Is the input string the right length?
            {
                var cells = new CellClass[9, 9]; // Yes, the instantiate a new 2D array to hold the new game
                var iPtr = 0; // Initialize the pointer variable
                for (var col = 0; col < 9; col++) // Loop through the columns
                    for (var row = 0; row < 9; row++) // Loop through the rows
                    {
                        var sTemp = sInput.Substring(iPtr, 2); // Extract a 2 character string at the pointer location
                        cells[col, row] = new CellClass(col, row, sTemp);
                            // Instantiate a new CellClass object with that string
                        if (cells[col, row].InvalidState) // Was the conversion valid?
                            return null; // No, then abort and return null
                        iPtr += 2; // Yes, the increment pointer by 2
                    }
                return cells; // Return the game that was restored
            }
            return null; // Problems, return null instead
        }

        protected virtual void RaiseEvent(int count)
        {
            var handler = GameManagerEvent;
            if (handler != null)
            {
                var e = new GameManagerEventArgs(_level, count);
                handler(this, e);
            }
        }

        #endregion

        #endregion
    }
}