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
            Frame.NavigationService.Navigate(new Page1());
        }

        private void OnExit(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
