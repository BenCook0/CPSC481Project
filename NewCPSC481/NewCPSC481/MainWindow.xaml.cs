using System.Windows;

namespace CPSC481WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {

        public MainWindow()
        {
            InitializeComponent();
        }

        private void myWindow_loaded(object sender, RoutedEventArgs e)
        {
            frame.NavigationService.Navigate(new Page1());
        }

    }
}
