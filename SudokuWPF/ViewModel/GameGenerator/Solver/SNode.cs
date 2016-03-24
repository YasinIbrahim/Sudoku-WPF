//
//  
// 
// 
// 
// 
//
// 
// 

namespace SudokuWPF.ViewModel.GameGenerator.Solver
{
    internal class SNode
    {
        #region . Constructors .

        internal SNode(int row, int col)
        {
            Left = this;
            Right = this;
            Upper = this;
            Lower = this;
            Header = null;
            Row = row;
            Col = col;
        }

        #endregion

        #region . Properties: Public .

        internal SNode Left { get; set; }
        internal SNode Right { get; set; }
        internal SNode Upper { get; set; }
        internal SNode Lower { get; set; }
        internal SColumn Header { get; set; }
        internal int Row { get; set; }
        internal int Col { get; set; }

        #endregion

        #region . Methods .

        #region . Methods: Public .

        public override string ToString()
        {
            return
                $"Node({Name()}), left({Name(Left)}), right({Name(Right)}), upper({Name(Upper)}), lower({Name(Lower)}), header({Name(Header)})";
        }

        #endregion

        #region . Methods: Private .

        private static string Name(SNode node)
        {
            return node == null ? "NULL" : node.Name();
        }

        private string Name()
        {
            return $"R{Row}, C{Col}";
        }

        #endregion

        #endregion
    }
}