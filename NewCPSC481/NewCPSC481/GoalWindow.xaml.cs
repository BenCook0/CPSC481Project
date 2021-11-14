using System.Windows;

namespace NewCPSC481
{
    /// <summary>
    /// Interaction logic for GoalWindow.xaml
    /// </summary>
    public partial class GoalWindow : Window
    {
        public GoalWindow()
        {
            InitializeComponent();
            Application.Current.MainWindow.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.Visibility = Visibility.Visible;
            Close();
        }
    }
}
