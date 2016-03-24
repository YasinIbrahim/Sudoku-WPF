//
//  
//
// This program is free software.  It is distributed under the terms of
// the GNU General Public License v3 as published by the Free Software
// Foundation.
//
// 
//

using SudokuWPF.ViewModel;

namespace SudokuWPF.Model.Structures
{
    public class CellIndex
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the CellIndex class.
        /// </summary>
        /// <param name="col">Column value to initialize the instance with.  Valid input is from 0 through 8.</param>
        /// <param name="row">Row value to initialize the instance with.  Valid input is from 0 through 8.</param>
        internal CellIndex(int col, int row)
        {
            if (Common.IsValidIndex(col, row)) // Check if this input parameters are valid.
            {
                Column = col; // Yes they are, so save them.
                Row = row;
                Region = SetRegion(col, row); // Compute the region based on the column and row.
            }
        }

        /// <summary>
        ///     Initializes a new instance of the CellIndex class.
        /// </summary>
        /// <param name="index">Zero based index into the 9x9 grid.</param>
        internal CellIndex(int index)
        {
            if ((0 <= index) && (index <= 80)) // Check if the input parameter is valid.
            {
                // Yes they are.  
                index++; // Increment the index.
                Column = ComputeColumn(index); // Figure out which column the index points to.
                Row = ComputeRow(Column, index); // Figure out which row the index points to.
                Region = SetRegion(Column, Row); // Compute the region based on the column and row.
            }
        }

        #endregion

        #region . Public Properties Read-only .

        /// <summary>
        ///     Gets the row value that this instance was initialized with.
        /// </summary>
        internal int Row { get; }

        /// <summary>
        ///     Gets the column value that this instance was initialized with.
        /// </summary>
        internal int Column { get; }

        /// <summary>
        ///     Gets the region value that this instance with initialized with.
        /// </summary>
        internal int Region { get; }

        #endregion

        #region . Public Methods .

        /// <summary>
        ///     Indicates whether the specified CellIndex is on the same row as this instance.
        /// </summary>
        /// <param name="uIndex">Another CellIndex instance to compare to.</param>
        /// <returns>Returns true if both instances are on the same row.  Returns false otherwise.</returns>
        internal bool IsSameRow(CellIndex uIndex)
        {
            if (uIndex != null) // Is the input parameter null?
                return uIndex.Row == Row; // No, then check if the row is the same.
            return false; // Yes, then return false.
        }

        /// <summary>
        ///     Indicates whether the specified CellIndex is on the same column as this instance.
        /// </summary>
        /// <param name="uIndex">Another CellIndex instance to compare to.</param>
        /// <returns>Returns true if both instances are on the same column.  Returns false otherwise.</returns>
        internal bool IsSameColumn(CellIndex uIndex)
        {
            if (uIndex != null) // Is the input parameter null?
                return uIndex.Column == Column; // No, then check if the column is the same.
            return false; // Yes, then return false.
        }

        /// <summary>
        ///     Indicates whether this specified CellIndex is in the same region as this instance.
        /// </summary>
        /// <param name="uIndex">Another CellIndex instance to compare to.</param>
        /// <returns>Returns true if both instances are in the same region.  Returns false otherwise.</returns>
        internal bool IsSameRegion(CellIndex uIndex)
        {
            if (uIndex != null) // IS the input parameter null?
                return uIndex.Region == Region; // No, then check if the region is the same.
            return false; // Yes, then return false.
        }

        #endregion

        #region . Private Methods .

        private static int ComputeColumn(int index)
        {
            var ret = index%9; // Mod the index by 9.
            if (ret == 0) // If mod = 0
                return 8; // Then must be column 8.
            return --ret; // Decrement and return it.
        }

        private static int ComputeRow(int col, int index)
        {
            var ret = index/9; // Divide the index by 9.
            if (col == 8) // If the column is 9
                return --ret; // Then decrement and return the results.
            return ret; // Otherwise, just return it.
        }

        private static int SetRegion(int col, int row)
        {
            if ((0 <= row) && (row <= 2)) // If the row is within 0 and 2
            {
                if ((0 <= col) && (col <= 2)) // And the column is within 0 and 2
                    return 0; // Must be region 0
                if ((3 <= col) && (col <= 5)) // If the column is within 3 and 5
                    return 1; // Must be region 1
                return 2; // Otherwise, it's region 2
            }
            if ((3 <= row) && (row <= 5)) // If row is within 3 and 5
            {
                if ((0 <= col) && (col <= 2)) // And column is within 0 and 2
                    return 3; // Must be region 3
                if ((3 <= col) && (col <= 5)) // If the column is within 3 and 5
                    return 4; // Must be region 4
                return 5; // Otherwise, it's region 5
            }
            if ((0 <= col) && (col <= 2)) // If the column is within 0 and 2
                return 6; // Must be region 6
            if ((3 <= col) && (col <= 5)) // If the column is within 3 and 5
                return 7; // Must be region 7
            return 8; // Otherwise, it's region 8
        }

        // For reference, here is a diagram showing how each cell is
        // referenced in code by [col][row].
        //
        //      +----------+----------+----------+
        //      | 00 10 20 | 30 40 50 | 60 70 80 |
        //      | 01 11 21 | 31 41 51 | 61 71 81 |
        //      | 02 12 22 | 32 42 52 | 62 72 82 |
        //      +----------+----------+----------+
        //      | 03 13 23 | 33 43 53 | 63 73 83 |
        //      | 04 14 24 | 34 44 54 | 64 74 84 |
        //      | 05 15 25 | 35 45 55 | 65 75 85 |
        //      +----------+----------+----------+
        //      | 06 16 26 | 36 46 56 | 66 76 86 |
        //      | 07 17 27 | 37 47 57 | 67 77 87 |
        //      | 08 18 28 | 38 48 58 | 68 78 88 |
        //      +----------+----------+----------+
        //
        // And the regions are define like so:
        //      
        //      +----------+----------+----------+
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      | ..  0 .. | ..  1 .. | ..  2 .. |
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      +----------+----------+----------+
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      | ..  3 .. | ..  4 .. | ..  5 .. |
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      +----------+----------+----------+
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      | ..  6 .. | ..  7 .. | ..  8 .. |
        //      | .. .. .. | .. .. .. | .. .. .. |
        //      +----------+----------+----------+
        //
        // And another diagram showing how each cell is reference by
        // index from 0 through 80.
        //
        //      +----------+----------+----------+
        //      | 00 01 02 | 03 04 05 | 06 07 08 |
        //      | 09 10 11 | 12 13 14 | 15 16 17 |
        //      | 18 19 20 | 21 22 23 | 24 25 26 |
        //      +----------+----------+----------+
        //      | 27 28 29 | 30 31 32 | 33 34 35 |
        //      | 36 37 38 | 39 40 41 | 42 43 44 |
        //      | 45 46 47 | 48 49 50 | 51 52 53 |
        //      +----------+----------+----------+
        //      | 54 55 56 | 57 58 59 | 60 61 62 |
        //      | 63 64 65 | 66 67 68 | 69 70 71 |
        //      | 72 73 74 | 75 76 77 | 78 79 80 |
        //      +----------+----------+----------+

        #endregion
    }
}