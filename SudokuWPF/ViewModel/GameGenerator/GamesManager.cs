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
using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;
using SudokuWPF.Properties;
using SudokuWPF.ViewModel.CustomEventArgs;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class GamesManager
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the GamesManager class.
        /// </summary>
        internal GamesManager()
        {
            InitializeClass();
        }

        #endregion

        #region . Event Handlers .

        private void GameManagerEventHandler(object sender, GameManagerEventArgs e)
        {
            RaiseEvent(e);
        }

        #endregion

        #region . Variables, Constants, And other Declarations .

        #region . Variables .

        private readonly GameCollection[] _games = new GameCollection[Common.MaxLevels];

        #endregion

        #region . Other Declarations .

        internal event EventHandler<GameManagerEventArgs> GamesManagerEvent;

        #endregion

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Stops the game manager thread.
        /// </summary>
        internal void StopGamesManager()
        {
            StopBackgroundTasks(); // Stop all background threads.
            SaveGames(); // Save the games to the application config file.
        }

        /// <summary>
        ///     Gets a game based on the specified difficulty level.
        /// </summary>
        /// <param name="level">Level of difficulty specified.</param>
        /// <returns>A 2D CellClass array of the game.</returns>
        internal CellClass[,] GetGame(DifficultyLevels level)
        {
            return _games[(int) level].GetGame; // Get a game based on the specified difficulty level
        }

        /// <summary>
        ///     Gets the number of games in the game queue of the specified level.
        /// </summary>
        /// <param name="level">Difficulty level of the count needed.</param>
        /// <returns>The number of games in the queue.</returns>
        internal int GameCount(DifficultyLevels level)
        {
            return _games[(int) level].GameCount;
        }

        #endregion

        #region . Methods: Private .

        private void InitializeClass()
        {
            InitGameCollectionArray(); // Initialize the game collection array
            LoadGames(); // Load any saved games from the config file
            StartBackgroundTasks(); // Start the background tasks
        }

        private void InitGameCollectionArray()
        {
            foreach (int i in Enum.GetValues(typeof (DifficultyLevels))) // Loop through the enum
                _games[i] = InitGameCollection((DifficultyLevels) i); // For each level, initialize a game manager class
        }

        private GameCollection InitGameCollection(DifficultyLevels level)
        {
            var collection = new GameCollection(level); // Instantiate a new game collection class
            collection.GameManagerEvent += GameManagerEventHandler; // Set the event handler
            return collection; // Return the pointer
        }

        private void LoadGames()
        {
            _games[0].LoadGames(Settings.Default.GamesLevel0); // Load games from the config file
            _games[1].LoadGames(Settings.Default.GamesLevel1);
            _games[2].LoadGames(Settings.Default.GamesLevel2);
            _games[3].LoadGames(Settings.Default.GamesLevel3);
            _games[4].LoadGames(Settings.Default.GamesLevel4);
        }

        private void StartBackgroundTasks()
        {
            foreach (var item in _games) // Loop though the array
                item.StartThread(); // Start each background thread
        }

        private void StopBackgroundTasks()
        {
            foreach (var item in _games) // Loop through the array
                item.StopThread(); // Stop each background thread
        }

        private void SaveGames()
        {
            Settings.Default.GamesLevel0 = _games[0].SaveGames(); // Save the games to the application config file
            Settings.Default.GamesLevel1 = _games[1].SaveGames();
            Settings.Default.GamesLevel2 = _games[2].SaveGames();
            Settings.Default.GamesLevel3 = _games[3].SaveGames();
            Settings.Default.GamesLevel4 = _games[4].SaveGames();
            Settings.Default.Save(); // Now save it to disk
        }

        private void RaiseEvent(GameManagerEventArgs e)
        {
            var handler = GamesManagerEvent; // Get a pointer to the event handler
            if (handler != null) // Any listeners?
                handler(this, e); // Yes, then raise the event
        }

        #endregion

        #endregion
    }
}