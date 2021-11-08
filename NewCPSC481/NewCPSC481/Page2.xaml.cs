﻿using NewCPSC481;
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
        GoalUserControl GoalUserCOntrol = new GoalUserControl();
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

        private void GraphicalDataButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 2;
        }
        private void SetGoalButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 3;
        }

        //goals functions below
        private void setGoalButtonClick(object sender, RoutedEventArgs e)
        {
            setGoalPopup.IsOpen = true;
        }

        private void GoalListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            testTextbox.Text = (String)((ListBoxItem)GoalListBox.SelectedItem).Content;
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
