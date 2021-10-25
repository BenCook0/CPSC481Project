using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace CPSC481WPF
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        public Page2()
        {
            InitializeComponent();
        }
        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
            this.NavigationService.RemoveBackEntry();
        }

        //goals functions below
        private void setGoalButtonClick(object sender, RoutedEventArgs e)
        {
            setGoalPopup.IsOpen = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
