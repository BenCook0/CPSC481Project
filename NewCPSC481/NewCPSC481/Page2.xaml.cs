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

namespace CPSC481WPF
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        //stubbed for now, will build one each later
        GoalUserControl GoalUserCOntrol = new GoalUserControl();
        WorkoutUserControl WorkoutUserControl = new WorkoutUserControl();
        public Page2()
        {
            InitializeComponent();
        }
        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            this.NavigationService.Navigate(new Page1());
            this.NavigationService.RemoveBackEntry();
        }

        //welcome page click functions
        private void RecentDataButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
        }

        private void WorkoutsButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }

        private void GraphicalDataButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }
        private void SetGoalButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 4;
        }

        //workout functions below
        private void WorkoutListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            if (WorkoutsListBox.SelectedItem != null)
            {
                workoutTestTextbox.Text = (String)((ListBoxItem)WorkoutsListBox.SelectedItem).Content;
            }

            WorkoutListStackPanel.Children.Clear();
            WorkoutListStackPanel.Children.Add(WorkoutUserControl);
        }

        //goals functions below
        private void setGoalButtonClick(object sender, RoutedEventArgs e)
        {
            setGoalPopup.IsOpen = true;
        }

        private void deleteGoalButtonClick(object sender, RoutedEventArgs e)
        {  
            if(GoalListBox.Items.IndexOf(GoalListBox.SelectedItem) != -1)
            {
                testTextbox.Text = "Item Just Got Deleted";
                GoalListBox.Items.RemoveAt(GoalListBox.Items.IndexOf(GoalListBox.SelectedItem));
                CurrentGoalStackPanel.Children.Clear();
            }

        }

        private void GoalListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            if(GoalListBox.SelectedItem != null)
            {
                testTextbox.Text = (String)((ListBoxItem)GoalListBox.SelectedItem).Content;
            }

            CurrentGoalStackPanel.Children.Clear();
            CurrentGoalStackPanel.Children.Add(GoalUserCOntrol);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {

        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_2(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_3(object sender, TextChangedEventArgs e)
        {

        }

        private void TextBox_TextChanged_4(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
