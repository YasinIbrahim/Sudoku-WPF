using System.Windows;
using SudokuWPF.View;
using SudokuWPF.ViewModel;

namespace SudokuWPF
{
    /// <summary>
    ///     Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public void ApplicationStartup(object sender, StartupEventArgs args)
        {
            var mainWindow = new MainWindow(); // Instantiate the main window
            mainWindow.ViewModel = ViewModelClass.GetInstance(mainWindow);
            // Get an instance of the ViewModel and set the View's ViewModel pointer
            mainWindow.Show(); // Now display the view
        }
    }
}