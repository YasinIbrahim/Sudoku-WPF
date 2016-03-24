//
//  
// 
// 
// 
// 
//
// 
// 

using System.ComponentModel;
using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using SudokuWPF.Model.Enums;
using SudokuWPF.ViewModel;

namespace SudokuWPF.View
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        #region . Variable Declarations .

        private ViewModelClass _viewModel;

        #endregion

        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the MainWindow class.
        /// </summary>
        public MainWindow()
        {
            InitializeComponent();
        }

        #endregion

        #region . Properties: Public .

        /// <summary>
        ///     Gets or sets the ViewModel pointer for this class.
        /// </summary>
        internal ViewModelClass ViewModel
        {
            get { return _viewModel; }
            set
            {
                _viewModel = value; // Save a pointer to the ViewModel class
                DataContext = value; // Set the datacontext of the WPF form to the view model.
            }
        }

        #endregion

        #region . Form Event Handlers .

        #region . WPF Controls Event Handlers .

        private void Window_Closing(object sender, CancelEventArgs e)
        {
            if (ViewModel != null)
                e.Cancel = ViewModel.CloseClicked();
                    // Check if user really wants to quit?  Cancel the event if user says "No"
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Close();
        }

        private void btnNew_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.NewClicked();
        }

        private void btnStart_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.StartClicked();
        }

        private void btnReset_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.ResetClicked();
        }

        private void btnAbout_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.AboutClicked();
        }

        private void btnPrint_Click(object sender, RoutedEventArgs e)
        {
            ViewModel?.PrintClicked();
        }

        #endregion

        #region . Cell Content Event Handlers .

        private void A0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 0);
        }

        private void A1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 1);
        }

        private void A2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 2);
        }

        private void A3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 3);
        }

        private void A4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 4);
        }

        private void A5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 5);
        }

        private void A6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 6);
        }

        private void A7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 7);
        }

        private void A8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(0, 8);
        }

        private void B0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 0);
        }

        private void B1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 1);
        }

        private void B2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 2);
        }

        private void B3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 3);
        }

        private void B4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 4);
        }

        private void B5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 5);
        }

        private void B6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 6);
        }

        private void B7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 7);
        }

        private void B8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(1, 8);
        }

        private void C0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 0);
        }

        private void C1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 1);
        }

        private void C2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 2);
        }

        private void C3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 3);
        }

        private void C4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 4);
        }

        private void C5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 5);
        }

        private void C6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 6);
        }

        private void C7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 7);
        }

        private void C8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(2, 8);
        }


        private void D0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 0);
        }

        private void D1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 1);
        }

        private void D2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 2);
        }

        private void D3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 3);
        }

        private void D4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 4);
        }

        private void D5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 5);
        }

        private void D6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 6);
        }

        private void D7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 7);
        }

        private void D8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(3, 8);
        }


        private void E0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 0);
        }

        private void E1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 1);
        }

        private void E2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 2);
        }

        private void E3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 3);
        }

        private void E4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 4);
        }

        private void E5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 5);
        }

        private void E6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 6);
        }

        private void E7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 7);
        }

        private void E8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(4, 8);
        }


        private void F0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 0);
        }

        private void F1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 1);
        }

        private void F2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 2);
        }

        private void F3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 3);
        }

        private void F4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 4);
        }

        private void F5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 5);
        }

        private void F6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 6);
        }

        private void F7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 7);
        }

        private void F8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(5, 8);
        }


        private void G0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 0);
        }

        private void G1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 1);
        }

        private void G2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 2);
        }

        private void G3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 3);
        }

        private void G4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 4);
        }

        private void G5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 5);
        }

        private void G6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 6);
        }

        private void G7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 7);
        }

        private void G8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(6, 8);
        }


        private void H0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 0);
        }

        private void H1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 1);
        }

        private void H2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 2);
        }

        private void H3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 3);
        }

        private void H4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 4);
        }

        private void H5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 5);
        }

        private void H6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 6);
        }

        private void H7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 7);
        }

        private void H8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(7, 8);
        }


        private void I0_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 0);
        }

        private void I1_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 1);
        }

        private void I2_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 2);
        }

        private void I3_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 3);
        }

        private void I4_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 4);
        }

        private void I5_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 5);
        }

        private void I6_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 6);
        }

        private void I7_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 7);
        }

        private void I8_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            if (ViewModel != null)
                ViewModel.CellClicked(8, 8);
        }

        #endregion

        #endregion

        #region . Public Methods .

        /// <summary>
        ///     Launch the number pad dialog.
        /// </summary>
        /// <returns>Returns the state of the number pad.</returns>
        internal InputPadStateEnum ShowNumberPad()
        {
            InputPad inputPad;
            try
            {
                inputPad = new InputPad(); // Instantiate a new instance of the window
                inputPad.Owner = this; // Set the owner to this window
                var point = Control.MousePosition; // Figure out the current mouse position relative to the whole screen
                inputPad.Left = point.X + 20; // Set the left edge equal to the mouse pointer + 20 pixels
                inputPad.Top = point.Y - inputPad.Height/2;
                    // Set the middle of the window vertically where the mouse clicked
                inputPad.ShowDialog(); // Now show the dialog
                return inputPad.InputPadState; // Return the input state of the window
            }
            finally
            {
                inputPad = null; // Release the window pointer
            }
        }

        /// <summary>
        ///     Launch the About box dialog.
        /// </summary>
        internal void ShowAboutBox()
        {
            AboutBox aboutBox;
            try
            {
                aboutBox = new AboutBox {Owner = this}; // Instantiate a new instance of the window
                // Set the owner to this window
                aboutBox.ShowDialog(); // Display the dialog
            }
            finally
            {
                aboutBox = null; // Release the window pointer
            }
        }

        /// <summary>
        ///     Launch the Game Complete dialog.
        /// </summary>
        internal void ShowGameCompletedDialog()
        {
            GameComplete gameComplete;
            try
            {
                gameComplete = new GameComplete(_viewModel);
                    // Instantiate a new instance of the window and pass it the ViewModel instance
                gameComplete.Owner = this; // Set the owner to this window
                gameComplete.ShowDialog(); // Display the dialog
            }
            finally
            {
                gameComplete = null; // Release the window pointer
            }
        }

        #endregion
    }
}