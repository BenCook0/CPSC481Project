using NewCPSC481;
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
using System.Windows.Threading;

namespace CPSC481WPF
{
    /// <summary>
    /// Interaction logic for Page1.xaml
    /// </summary>
    /// HELLO 
    public partial class Page1 : Page
    {
        private int seconds = 0;
        private DispatcherTimer timer;

        FrontPageFirst first = new FrontPageFirst();
        FrontPageSecond second = new FrontPageSecond();

        public Page1()
        {
            InitializeComponent();

            FrontPagePanel.Children.Clear();
            FrontPagePanel.Children.Add(first);

            //setup timer for the swapping components
            timer = new DispatcherTimer();
            timer.Tick += timer_tick;
            timer.Interval = System.TimeSpan.FromMilliseconds(1000);
            timer.Start();
        }

        private void timer_tick(object sender, EventArgs e)
        {
            seconds++;
            if(seconds % 10 == 0)
            {
                elipse1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#44acc2") ;
                elipse2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
                FrontPagePanel.Children.Clear();
                FrontPagePanel.Children.Add(first);
            }
            if(seconds % 10 == 5)
            {
                elipse2.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#44acc2");
                elipse1.Fill = (SolidColorBrush)new BrushConverter().ConvertFrom("#FFFFFF");
                FrontPagePanel.Children.Clear();
                FrontPagePanel.Children.Add(second);
            }
        }

        private void elipse1MouseDown(object sender, MouseButtonEventArgs e)
        {
            seconds = 9;
        }

        private void elipse2MouseDown(object sender, MouseButtonEventArgs e)
        {
            seconds = 4;
        }

        private void LoginButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page2());
            this.NavigationService.RemoveBackEntry();
        }

        private void FrontPageStackSwapper(object sender, SelectionChangedEventArgs e)
        {
            FrontPagePanel.Children.Clear();
            FrontPagePanel.Children.Add(first);
        }

        private void ToggleUsernamePopup(object sender, MouseButtonEventArgs e)
        {
            if (UsernameAndPasswordPopup.IsOpen)
            {
                UsernameAndPasswordPopup.IsOpen = false;
            }
            else
            {
                UsernameAndPasswordPopup.IsOpen = true;
            }
        }
    }
}
