//
//  
// 
// 
// 
// 
//
// 
// 

using System.Collections.Generic;
using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class MaskPuzzle
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the MaskPuzzle class.
        /// </summary>
        /// <param name="Level">The difficulty level to mask to.</param>
        internal MaskPuzzle(DifficultyLevels Level)
        {
            _level = Level;
        }

        #endregion

        #region . Properties: Public .

        /// <summary>
        ///     Gets a flag indicating whether the masking was good or not.
        /// </summary>
        internal bool NotGood { get; private set; }

        #endregion

        #region . Variables, Constants, And other Declarations .

        #region . Constants .

        private readonly int _cMaxInterations = 10; // Maximum number of iterations before we give up.

        #endregion

        #region . Variables .

        private readonly DifficultyLevels _level;

        #endregion

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Masks the specified puzzle board.
        /// </summary>
        /// <param name="cells">Puzzle to mask.</param>
        internal void MaskBoard(CellClass[,] cells)
        {
            var list = TransferToList(cells); // Transfer the 2D array to a list.
            var mask = 81 - GetMaskedValue(_level); // Get the number of cells to mask based on the difficulty level.
            var cSolve = new SolveGame(); // Instantiate a the game solver class
            var numIterations = 0; // Initialize the iteration counter
            NotGood = false; // Clear the flag.
            do
            {
                var index1 = FindRandomCell(list); // Find a random cell
                var index2 = GetMirror(index1); // Get a mirror cell on the vertical axis
                SetCellState(cells, index1, index2, CellStateEnum.Blank); // Mask the cells
                if (cSolve.SolvePuzzle(cells)) // Try to sell the puzzle
                {
                    mask -= RemoveCells(list); // Solvable, remove the masked cells from the list
                    numIterations = 0; // Zero out the interation counter
                }
                else
                {
                    // Not solvable
                    SetCellState(cells, index1, index2, CellStateEnum.Answer); // Restore the cell states
                    numIterations++; // Increment the interation counter
                    if (numIterations > _cMaxInterations) // Did we exceed the maximum iterations?
                    {
                        NotGood = true; // Yes, raise the flag
                        break; // Exit out of the loop
                    }
                }
            } while (mask > 0); // Keep loop until there are no more cells to mask
        }

        #endregion

        #region . Methods: Private .

        private static List<CellClass> TransferToList(CellClass[,] cells)
        {
            var retList = new List<CellClass>(81); // Instantiate a new list
            for (var col = 0; col < 9; col++) // Loop through the columns
                for (var row = 0; row < 9; row++) // Loop through the rows
                    retList.Add(cells[col, row]); // Add the cell to the list
            return retList; // Return the list
        }

        private static CellIndex GetMirror(CellIndex index)
        {
            var col = 8 - index.Column; // Get the index on the other side
            return new CellIndex(col, index.Row); // Return a new CellIndex class
        }

        private static CellIndex FindRandomCell(List<CellClass> list)
        {
            var index = RandomClass.GetRandomInt(list.Count - 1); // Find a random cell in the list
            return list[index].CellIndex; // Return the CellIndex of the selected cell
        }

        private static void SetCellState(CellClass[,] cells, CellIndex index1, CellIndex index2, CellStateEnum state)
        {
            cells[index1.Column, index1.Row].CellState = state; // Set the cell state of the first cell
            cells[index2.Column, index2.Row].CellState = state; // Set the cell state of the second cell
        }

        private static int RemoveCells(List<CellClass> cells)
        {
            var index = FindFirstMaskedCell(cells); // Find the index of the first masked cell
            cells.RemoveAt(index); // Remove it from the list
            var count = 1; // Set the counter to 1
            index = FindFirstMaskedCell(cells); // Find the index of the next masked cell
            if (index >= 0) // Found?
            {
                cells.RemoveAt(index); // Yes, remove it as well
                count++; // Increment the count
            }
            return count; // Return the count of masked cells removed
        }

        private static int FindFirstMaskedCell(List<CellClass> cells)
        {
            for (var i = 0; i < cells.Count; i++) // Loop through the list of cells
                if (cells[i].CellState == CellStateEnum.Blank) // Find first blank cell
                    return i; // Return the index
            return -1; // None found, return -1
        }

        private static int GetMaskedValue(DifficultyLevels level)
        {
            int min;
            int max;
            switch (level)
            {
                case DifficultyLevels.VeryEasy: // If the difficulty level is very easy
                    min = 50; // Number of given is between 50 and 60
                    max = 60;
                    break;

                case DifficultyLevels.Easy: // If the difficulty level is easy       
                    min = 36; // Number of given is between 36 and 49
                    max = 49;
                    break;

                case DifficultyLevels.Medium: // If the difficulty level is medium
                    min = 32; // Number of given is between 32 and 35
                    max = 35;
                    break;

                case DifficultyLevels.Hard: // If the difficulty level is hard
                    min = 28; // Number of given is between 28 and 31
                    max = 31;
                    break;

                default: // Default is expert level.
                    min = 22; // Number of given is between 22 and 27
                    max = 27;
                    break;
            }
            return RandomClass.GetRandomInt(min, max); // Return a random number between the min and max
        }

        #endregion

        #endregion
    }
}