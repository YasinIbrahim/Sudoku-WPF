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
using System.Threading;
using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;
using SudokuWPF.ViewModel.CustomEventArgs;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class GameGenerator
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the GameGenerator class.
        /// </summary>
        /// <param name="level">Level of difficulty for this game generator instance to create.</param>
        internal GameGenerator(DifficultyLevels level)
        {
            _level = level;
        }

        #endregion

        #region . Properties: Public .

        /// <summary>
        ///     Gets a flag that indicates whether this class is busy or not.
        /// </summary>
        internal bool Busy { get; private set; }

        #endregion

        #region . Variables, Constants, And other Declarations .

        #region . Variables .

        private readonly DifficultyLevels _level;

        #endregion

        #region . Other Declarations .

        internal event EventHandler<GameGeneratorEventArgs> GameGeneratorEvent;

        #endregion

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Starts a new background thread to create the game.
        /// </summary>
        internal void CreateNewGame()
        {
            var t = new Thread(GenerateNewGame) {IsBackground = true}; // Instantiate a new thread
            // Set the thread to background mode.
            t.Start(); // Start the thread
        }

        #endregion

        #region . Methods: Private .

        private void GenerateNewGame()
        {
            var cells = GenerateNewBoard(); // Generate a new game
            RaiseEvent(cells); // Raise an event to tell whoever is listening that we're done
        }

        private CellClass[,] GenerateNewBoard()
        {
            try
            {
                Busy = true; // Raise the busy flag
                CellClass[,] cells; // Initialize some variables
                var cPopulate = new PopulatePuzzle();
                var cMask = new MaskPuzzle(_level);
                do
                {
                    cells = cPopulate.GeneratePuzzle(); // Create a new game
                    cMask.MaskBoard(cells); // Try to mask cells
                } while (cMask.NotGood); // Was mask successful?  If not, then loop again
                return cells; // Return the generated game
            }
            finally
            {
                Busy = false; // Clear busy flag
            }
        }

        protected virtual void RaiseEvent(CellClass[,] cells)
        {
            var handler = GameGeneratorEvent;
            if (handler != null)
            {
                var e = new GameGeneratorEventArgs(cells);
                handler(this, e);
            }
        }

        #endregion

        #endregion
    }
}