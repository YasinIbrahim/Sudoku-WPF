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
using System.Diagnostics;
using System.Text;
using SudokuWPF.Model.Enums;
using SudokuWPF.Model.Structures;

namespace SudokuWPF.ViewModel
{
    internal class Common
    {
        #region . Constant declarations .

        internal const int MaxLevels = 5;
            // This value should correspond to the number of game levels (DifficultyLevels enum)

        #endregion

        #region . Public properties .

        /// <summary>
        ///     Return true if the specified index is between 0 and 8.
        /// </summary>
        /// <param name="index">Index value to check.</param>
        /// <returns></returns>
        internal static bool IsValidIndex(int index)
        {
            return (0 <= index) && (index <= 8);
        }

        /// <summary>
        ///     Return true if the specified column and row is between 0 and 8.
        /// </summary>
        /// <param name="col">Column value to check.</param>
        /// <param name="row">Row value to check.</param>
        /// <returns></returns>
        internal static bool IsValidIndex(int col, int row)
        {
            return IsValidIndex(col) && IsValidIndex(row);
        }

        /// <summary>
        ///     Return true if the specified CellIndex class is valid.
        /// </summary>
        /// <param name="uIndex">CellIndex call to check.</param>
        /// <returns></returns>
        internal static bool IsValidIndex(CellIndex uIndex)
        {
            if (uIndex != null)
                if (IsValidIndex(uIndex.Column, uIndex.Row))
                    return IsValidIndex(uIndex.Region);
            return false;
        }

        /// <summary>
        ///     Return true if the specified value is between 1 and 9.
        /// </summary>
        /// <param name="value">Integer to check.</param>
        /// <returns></returns>
        internal static bool IsValidAnswer(int value)
        {
            return (1 <= value) && (value <= 9);
        }

        /// <summary>
        ///     Return true if the specified object is a valid cell state enum.
        /// </summary>
        /// <param name="value">Object to check.</param>
        /// <returns></returns>
        internal static bool IsValidStateEnum(object value)
        {
            return Enum.IsDefined(typeof (CellStateEnum), value);
        }

        /// <summary>
        ///     Return true if the specified object is a valid difficulty level.
        /// </summary>
        /// <param name="value">Object to check.</param>
        /// <returns></returns>
        internal static bool IsValidGameLevel(object value)
        {
            return Enum.IsDefined(typeof (DifficultyLevels), value);
        }

        /// <summary>
        ///     Print the grid out to the immediate window.
        /// </summary>
        /// <param name="cells">Two dimensional array of cells to print out.</param>
        internal static void PrintGrid(CellClass[,] cells)
        {
            for (var col = 0; col < 9; col++)
            {
                var sTemp = new StringBuilder();
                for (var row = 0; row < 9; row++)
                    sTemp.AppendFormat("{0} ", cells[col, row].Answer);
                Debug.WriteLine("{0}) {1}", col, sTemp);
            }
        }

        #endregion
    }
}