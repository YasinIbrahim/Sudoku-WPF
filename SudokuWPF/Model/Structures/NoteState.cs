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
using System.ComponentModel;
using SudokuWPF.ViewModel;

namespace SudokuWPF.Model.Structures
{
    public class NoteState : INotifyPropertyChanged
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the NoteState class.
        /// </summary>
        /// <param name="value">Value for this note instance.</param>
        internal NoteState(int value)
        {
            if (Common.IsValidAnswer(value)) // Check that the input value is valid.
            {
                _stateValue = $" {value} "; // Yes, then save it.
                State = false; // Default state to False.
            }
            else
                throw new Exception("Invalid input."); // No, raise an exception.
        }

        #endregion

        #region . Interface Implementation .

        // This routine is normally called from the Set accessor of each property
        // that is bound to the a WPF control.
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        #region . Variables, constants, and other declarations .

        #region . Variables .

        private readonly string _stateValue; // Stores the string value of the note.
        private bool _state; // Stores the state value of the note.  True = display it.  False = hide it.

        #endregion

        #region . Other declarations .

        public event PropertyChangedEventHandler PropertyChanged; // Interface definition

        #endregion

        #endregion

        #region . Properties .

        #region . Properties: Public Read-Only .

        /// <summary>
        ///     Gets the string value to display.
        /// </summary>
        public string Value
        {
            get
            {
                if (State) // If the state is True.
                    return _stateValue; // Return the value to display
                return "   "; // Otherwise, return a blank string.
            }
        }

        #endregion

        #region . Properties: Public Read/Write.

        /// <summary>
        ///     Gets or set the display state for this instance.  True = display the value.  False = hide the value.
        /// </summary>
        public bool State
        {
            get { return _state; // Return the current state.
            }
            set
            {
                _state = value; // Save the state.
                OnPropertyChanged("Value"); // Raise the event on the Value property.
            }
        }

        #endregion

        #endregion
    }
}