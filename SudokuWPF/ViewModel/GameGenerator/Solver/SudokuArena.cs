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

namespace SudokuWPF.ViewModel.GameGenerator.Solver
{
    internal class SudokuArena : Arena
    {
        #region . Constructors .

        internal SudokuArena(int[,] puzzle, int boxRows, int boxCols)
            : base(puzzle.Length*4)
        {
            Solutions = 0;
            Size = puzzle.GetLength(0);
            var positions = new int[4];
            var known = new List<SNode>();
            for (var row = 0; row < Size; row++)
                for (var col = 0; col < Size; col++)
                {
                    var boxRow = row/boxRows;
                    var boxCol = col/boxCols;
                    for (var digit = 0; digit < Size; digit++)
                    {
                        var isGiven = puzzle[row, col] == digit + 1;
                        positions[0] = 1 + row*Size + col;
                        positions[1] = 1 + puzzle.Length + row*Size + digit;
                        positions[2] = 1 + 2*puzzle.Length + col*Size + digit;
                        positions[3] = 1 + 3*puzzle.Length + (boxRow*boxRows + boxCol)*Size + digit;
                        var newRow = AddRow(positions);
                        if (isGiven)
                            known.Add(newRow);
                    }
                }
            RemoveKnown(known);
        }

        #endregion

        #region . Methods: Public .

        internal override void HandleSolution(SNode[] rows)
        {
            Solutions++;
        }

        #endregion

        #region . Properties .

        #region . Properties: Public Read-only.

        internal int Solutions { get; private set; }

        #endregion

        #region . Properties: Private .

        private int Size { get; }

        #endregion

        #endregion
    }
}