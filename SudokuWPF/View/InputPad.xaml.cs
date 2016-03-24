//
//  
// 
// 
// 
// 
//
// 
// 

using System.Windows;
using SudokuWPF.Model.Enums;

namespace SudokuWPF.View
{
    /// <summary>
    ///     Interaction logic for InputPad.xaml
    /// </summary>
    public partial class InputPad : Window
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the InputPad window.
        /// </summary>
        public InputPad()
        {
            InitializeComponent();

            InputPadState = InputPadStateEnum.InvalidState; // Default the state to Invalid.
        }

        #endregion

        #region . Public Read-only properties .

        /// <summary>
        ///     Gets the state of the window.
        /// </summary>
        public InputPadStateEnum InputPadState { get; private set; }

        #endregion

        #region . Private methods .

        private void SaveState(InputPadStateEnum state)
        {
            InputPadState = state; // Save the state to the property.
            Close(); // Close the window.
        }

        #endregion

        #region . Form Event Handlers .

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number1);
        }

        private void Button2_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number2);
        }

        private void Button3_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number3);
        }

        private void Button4_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number4);
        }

        private void Button5_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number5);
        }

        private void Button6_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number6);
        }

        private void Button7_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number7);
        }

        private void Button8_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number8);
        }

        private void Button9_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.Number9);
        }

        private void HintButton_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.HintRaised);
        }

        private void ClearButton_Click(object sender, RoutedEventArgs e)
        {
            SaveState(InputPadStateEnum.ClearRaised);
        }

        #endregion
    }
}