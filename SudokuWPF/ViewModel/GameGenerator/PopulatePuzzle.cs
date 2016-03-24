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
using System.Linq;
using SudokuWPF.Model.Structures;

namespace SudokuWPF.ViewModel.GameGenerator
{
    internal class PopulatePuzzle
    {
        #region . Variables .

        private readonly CellClass[] _cells = new CellClass[81];

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Create a new Sudoku puzzle.
        /// </summary>
        /// <returns>Return the puzzle generated.</returns>
        internal CellClass[,] GeneratePuzzle()
        {
            ClearCells(); // Clear the cells
            GenerateGrid(); // Generate a new puzzle
            return TransferGameToGrid(); // Transfer the puzzle to the game grid
        }

        #endregion

        #region . Methods: Private .

        private void ClearCells()
        {
            for (var i = 0; i < 81; i++) // Loop through the array
                _cells[i] = null; // Set each element to null
        }

        private void GenerateGrid()
        {
            var available = InitializeArray(); // Initialize the list
            var index = 0; // Set the index pointer to zero
            do
            {
                if (available[index].Count > 0) // If more number available
                {
                    var i = RandomClass.GetRandomInt(available[index].Count); // Get a random number
                    var item = new CellClass(index, available[index][i]); // Create a new 
                    if (Conflicts(item)) // Any conflicts with existing cells?
                    {
                        available[index].RemoveAt(i); // Yes, remove it from the available list
                        item = null; // Clear the CellClass pointer
                    }
                    else
                    {
                        // No conflicts
                        _cells[index] = item; // Save the CellClass to the array
                        item = null; // Clear the CellClass pointer
                        available[index].RemoveAt(i); // Remove it from the available list
                        index++; // Increment the index pointer
                    }
                }
                else
                {
                    // No more number available
                    available[index] = InitArray(); // Re-initialize the available list
                    index--; // To back one spot
                    _cells[index] = null; // Clear the array pointer
                }
            } while (index < 81); // Keep looping until there are no more cells to process
        }

        private static List<int>[] InitializeArray()
        {
            var available = new List<int>[81]; // Instantiate a new array of lists
            for (var i = 0; i < 81; i++) // Loop through the array
                available[i] = InitArray(); // Initialize the element
            return available; // Return the list of arrays
        }

        private static List<int> InitArray()
        {
            var retVal = new List<int>(); // Instantiate a new list
            for (var j = 1; j <= 9; j++) // Loop through the answers
                retVal.Add(j); // Add it to the list
            return retVal; // Return the list
        }

        private bool Conflicts(CellClass check)
        {
            // If the answer already exists in the column, row, or region, return true.
            return
                _cells.Where(item => item != null)
                    .Any(
                        item =>
                            (item.IsSameRow(check) || item.IsSameCol(check) || item.IsSameRegion(check)) &&
                            (item.Answer == check.Answer));
        }

        private CellClass[,] TransferGameToGrid()
        {
            var cells = new CellClass[9, 9]; // Initialize a new cell array
            foreach (var item in _cells) // Loop the cell list
                cells[item.Col, item.Row] = item; // Save the pointer
            return cells; // Return the cell array
        }

        #endregion

        #endregion
    }
}