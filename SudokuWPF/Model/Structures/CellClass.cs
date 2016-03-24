//
//  
//
// This program is free software.  It is distributed under the terms of
// the GNU General Public License v3 as published by the Free Software
// Foundation.
//
// 
//

using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using SudokuWPF.Model.Enums;
using SudokuWPF.ViewModel;

namespace SudokuWPF.Model.Structures
{
    public class CellClass : INotifyPropertyChanged
    {
        #region . Interface Implementation .

        // This routine is normally called from the Set accessor of each property
        // that is bound to the a WPF control.  We use the [CallMemberName] attribute
        // so that the property name of the caller will be substituted as the argument.
        protected void OnPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region . Variables, constants, and other declarations .

        #region . Variables .

        private int _userAnswer; // Holds the user's answer.
        private CellStateEnum _cellState; // Holds the state of this cell.

        #endregion

        #region . Other declarations .

        public event PropertyChangedEventHandler PropertyChanged; // Interface definition.

        #endregion

        #endregion

        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the CellClass.
        /// </summary>
        /// <param name="col">Column value to initialize this instance with.</param>
        /// <param name="row">Row value to initialize this instance with.</param>
        /// <param name="state">Two or three character string to initialize the state of this cell.</param>
        internal CellClass(int col, int row, string state)
        {
            InitCell(col, row); // Initialize the variables of this instance.
            LoadState(state); // Convert the input state.
        }

        /// <summary>
        ///     Initializes a new instance of the CellClass.
        /// </summary>
        /// <param name="index">Index of the cell to create.</param>
        /// <param name="answer">The answer value for this cell.</param>
        internal CellClass(int index, int answer)
        {
            InitCell(); // Initialize the variables of this instance.
            CellIndex = new CellIndex(index); // Instantiate a new CellIndex class and save it.
            Answer = answer; // Save the answer.
            CellState = CellStateEnum.Answer; // Set the cell's state to Answer.
        }

        #endregion

        #region . Properties: Public .

        #region . Properties: Public Read/Write .

        /// <summary>
        ///     Gets or sets the state of this cell.
        /// </summary>
        public CellStateEnum CellState
        {
            get { return _cellState; }
            set
            {
                _cellState = value; // Save the new state.
                OnPropertyChanged(); // Raise a property changed event.
            }
        }

        /// <summary>
        ///     Gets or sets the user's answer.
        /// </summary>
        public int UserAnswer
        {
            get { return _userAnswer; }
            set
            {
                if (Common.IsValidAnswer(value)) // Is the answer within range?
                {
                    _userAnswer = value; // Yes, save it.
                    if (_userAnswer == Answer) // Is the user's answer correct?
                        CellState = CellStateEnum.UserInputCorrect; // Yes, set the state to correct.
                    else
                        CellState = CellStateEnum.UserInputIncorrect; // No, set the state to incorrect.
                    OnPropertyChanged(); // Raise a property changed event.
                }
            }
        }

        #endregion

        #region . Properties: Public Read-only .

        /// <summary>
        ///     Gets this cell's answer.
        /// </summary>
        public int Answer { get; private set; }

        /// <summary>
        ///     Gets a value indicating whether or not the initial state of this cell was set properly or not.
        /// </summary>
        public bool InvalidState { get; private set; }

        /// <summary>
        ///     Gets the CellIndex for this cell.
        /// </summary>
        public CellIndex CellIndex { get; private set; }

        /// <summary>
        ///     Gets the row value for this cell.
        /// </summary>
        public int Row => CellIndex.Row;

        /// <summary>
        ///     Gets the column value for this cell.
        /// </summary>
        public int Col => CellIndex.Column;

        /// <summary>
        ///     Gets the region value for this cell.
        /// </summary>
        public int Region => CellIndex.Region;

        /// <summary>
        ///     Gets the cell name for this cell.
        /// </summary>
        public string CellName => $"Cell{CellIndex.Column}{CellIndex.Row}";

        /// <summary>
        ///     Gets the Notes array for this cell.
        /// </summary>
        public NoteState[] Notes { get; } = new NoteState[9];

        #endregion

        #endregion

        #region . Methods .

        #region . Methods: Public .

        /// <summary>
        ///     Clear all notes for this cell.
        /// </summary>
        internal void ClearNotes()
        {
            for (var i = 0; i < 9; i++) // Loop through the array.
                if (Notes[i] == null) // Is the array element is null?
                    Notes[i] = new NoteState(i + 1); // Yes, instantiate a new element.
                else
                    Notes[i].State = false; // No, set the state to false.
        }

        /// <summary>
        ///     Indicates whether the specified cell is on the same row as this instance.
        /// </summary>
        /// <param name="cell">The CellClass object to compare to.</param>
        /// <returns>Returns true if they are on the same row.  Returns false otherwise.</returns>
        internal bool IsSameRow(CellClass cell)
        {
            if (cell != null) // Is the input parameter null?
                return CellIndex.IsSameRow(cell.CellIndex); // No, then compare the row values.
            return false; // Yes, return false.
        }

        /// <summary>
        ///     Indicates whether the specified cell is on the same column as this instance.
        /// </summary>
        /// <param name="cell">The CellClass object to compare to.</param>
        /// <returns>Returns true if they are on the same column.  Returns false otherwise.</returns>
        internal bool IsSameCol(CellClass cell)
        {
            if (cell != null) // Is the input parameter null?
                return CellIndex.IsSameColumn(cell.CellIndex); // No, then compare the column values.
            return false; // Yes, return false.
        }

        /// <summary>
        ///     Indicates whether the specified cell is in the same region as this instance.
        /// </summary>
        /// <param name="cell">The CellClass object to compare to.</param>
        /// <returns>Returns true if they are in the same region.  Returns false otherwise.</returns>
        internal bool IsSameRegion(CellClass cell)
        {
            if (cell != null) // Is the input parameter null?
                return CellIndex.IsSameRegion(cell.CellIndex); // No, then compare the region values.
            return false; // Yes, return false.
        }

        /// <summary>
        ///     Returns a string value indicating the answer (first character) and the state (second character).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return ToString(false);
        }

        /// <summary>
        ///     Returns a string value indicating the answer (first character), the state (second character), and the
        ///     user's answer (third character).
        /// </summary>
        /// <param name="includeUserAnswer"></param>
        /// <returns></returns>
        internal string ToString(bool includeUserAnswer)
        {
            var sTemp = new StringBuilder(); // Instantiate a new String Builder class.
            sTemp.Append(Answer.ToString()); // Append the answer.
            sTemp.Append(CellState.GetHashCode()); // Append the cell state as a numeric value.
            if (includeUserAnswer) // Do we need to include the user's answer?
                sTemp.Append(UserAnswer.ToString()); // Yes, include the user's answer.
            return sTemp.ToString(); // Return the resulting string.
        }

        #endregion

        #region . Methods: Private .

        private void InitCell()
        {
            Answer = 0; // Initialize the answer to zero.
            UserAnswer = 0; // Initialize the user's answer to zero.
            CellState = CellStateEnum.Blank; // Initialize the cell's state to Blank.
            ClearNotes(); // Clear the Notes array.
        }

        private void InitCell(int col, int row)
        {
            InitCell(); // Initialize the cell instance.
            CellIndex = new CellIndex(col, row); // Instantiate the cell index.
        }

        private void LoadState(string state)
        {
            InvalidState = true; // Default flag to true.
            if (state.Length >= 2) // Is the input parameter a valid length?
                if (ExtractAnswer(state.Substring(0, 1))) // Yes, extract the answer from the first character.
                    if (ExtractCellState(state.Substring(1, 1)))
                        // Answer extracted, now extract the state from the second character.
                        if (state.Length >= 3) // More data?
                        {
                            if (ExtractUserAnswer(state.Substring(2, 1))) // Yes, extract the user's answer.
                                InvalidState = false; // Extract just fine.  Clear the flag.
                        }
                        else // No more data.  Check if the state is valid or not.
                            InvalidState = !((CellState == CellStateEnum.Answer) || (CellState == CellStateEnum.Blank));
        }

        private bool ExtractAnswer(string state)
        {
            Answer = ConvertAnswerToInt32(state); // Convert the string to the answer.
            return Answer != 0; // Return true if the answer is non-zero.
        }

        private bool ExtractUserAnswer(string state)
        {
            UserAnswer = ConvertAnswerToInt32(state); // Convert the string to the user's answer.
            return UserAnswer != 0; // Return true if it is non-zero.
        }

        private static int ConvertAnswerToInt32(string value)
        {
            int temp;
            var results = int.TryParse(value, out temp); // Try to parse the input string.
            if (results && Common.IsValidAnswer(temp)) // Parse okay and within range?
                return temp; // Yes, then return the converted value.
            return 0; // No, return zero.
        }

        private bool ExtractCellState(string state)
        {
            try
            {
                // Try to convert the state value to an enum value.
                var eState = (CellStateEnum) Enum.Parse(typeof (CellStateEnum), state);
                if (Common.IsValidStateEnum(eState)) // Conversion valid?
                {
                    CellState = eState; // Yes, save it.
                    return true; // Return true.
                }
            }
            catch (Exception)
            {
                // TODO: What to do here?
                // Maybe log error to Application.Event log?
            }
            CellState = CellStateEnum.Blank; // Conversion failed.  Set state to Blank.
            return false; // Return false.
        }

        #endregion

        #endregion
    }
}