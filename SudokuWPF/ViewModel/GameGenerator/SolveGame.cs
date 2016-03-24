//
//  
// 
// 
// 
// 
//
// 
// 

using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;
using SudokuWPF.ViewModel.GameGenerator.Solver;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class SolveGame
    {
        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Solve the puzzle specified.
        /// </summary>
        /// <param name="cells">Puzzle to solve.</param>
        /// <returns>Returns a flag to indicate whether a solution was found or not.</returns>
        internal bool SolvePuzzle(CellClass[,] cells)
        {
            var iTask = ConvertBoard(cells); // Convert board to a 2D array of integers
            var cArena = new SudokuArena(iTask, 3, 3); // Instantiate a new dancing arena 
            cArena.Solve(); // Now solve it
            return cArena.Solutions == 1; // Return true if there is only one solution
        }

        #endregion

        #region . Methods: Private .

        private static int[,] ConvertBoard(CellClass[,] cells)
        {
            var iRet = new int[9, 9]; // Initialize a new 9 x 9 array of integers
            for (var col = 0; col < 9; col++) // Loop through the columns
                for (var row = 0; row < 9; row++) // Loop through the rows
                {
                    // Is the cell state answer?
                    if (cells[col, row].CellState == CellStateEnum.Answer)
                        iRet[col, row] = cells[col, row].Answer; // Yes, save the answer
                    else
                        iRet[col, row] = 0; // No, set it to zero
                }
            return iRet; // Return the array
        }

        #endregion

        #endregion
    }
}