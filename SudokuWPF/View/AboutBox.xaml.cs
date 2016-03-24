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

namespace SudokuWPF.View
{
    /// <summary>
    ///     Interaction logic for AboutBox.xaml
    /// </summary>
    public partial class AboutBox : Window
    {
        #region . Constructors .

        /// <summary>
        ///     Initializes a new instance of the Aboutbox form.
        /// </summary>
        public AboutBox()
        {
            InitializeComponent();
        }

        #endregion

        #region . Form Event Handlers .

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            Close(); // OK button clicked.  Close this window.
        }

        #endregion
    }
}