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
using NewCPSC481.Data;


namespace CPSC481WPF
{
    /// <summary>
    /// Interaction logic for Page2.xaml
    /// </summary>
    public partial class Page2 : Page
    {
        private User user;
        //stubbed for now, will build one each later
        GoalUserControl GoalUserControl = new GoalUserControl();
        WorkoutUserControl WorkoutUserControl = new WorkoutUserControl();
        public Page2()
        {
            InitializeComponent();

            //fill recent data with user data

            WorkoutListStackPanel.Children.Add(WorkoutUserControl);
            CurrentGoalStackPanel.Children.Add(GoalUserControl);


        }


        public Page2(User user) : this()
        {
            this.user = user;
            DataContext = user;

            //Daily data
            //user data is datetime date, int steps, float calories, float bpm
            InitalizeRecentData();
            InitalizeWeeklyData();
            //fill workout list boxes
            InitalizeWorkoutListBox();
            WorkoutUserControl.Visibility = Visibility.Hidden;

            InitalizeGoalListBox();
            GoalUserControl.Visibility = Visibility.Hidden;


        }

        //initalize page functions
        private void InitalizeRecentData()
        {
            DailyStepsTaken.Text = user.collectedData[user.collectedData.Count-1].Item2.ToString();
            DailyCalories.Text = user.collectedData[user.collectedData.Count - 1].Item3.ToString();
            DailyHeartRate.Text = user.collectedData[user.collectedData.Count - 1].Item4.ToString();
        }

        private void InitalizeWeeklyData()
        {
            float weeklyStepsAvg = 0;
            float WeeklyCalorieAvg = 0;
            float weeklyHeartRateAvg = 0;

            //if this is a new user and they have less than 1 week of data then just count them, otherwise
            for(int i = Math.Max(user.collectedData.Count -7,0); i < user.collectedData.Count; i++)
            {
                weeklyStepsAvg += user.collectedData[i].Item2;
                WeeklyCalorieAvg += user.collectedData[i].Item3;
                weeklyHeartRateAvg += user.collectedData[i].Item4;
            }
            weeklyStepsAvg = weeklyStepsAvg / (Math.Min(7, user.collectedData.Count));
            WeeklyCalorieAvg = WeeklyCalorieAvg / Math.Min(7, user.collectedData.Count);
            weeklyHeartRateAvg = weeklyHeartRateAvg / (Math.Min(7, user.collectedData.Count));

            WeeklyStepsTaken.Text = weeklyStepsAvg.ToString();
            WeeklyCalories.Text = WeeklyCalorieAvg.ToString();
            WeeklyHeartRate.Text = weeklyHeartRateAvg.ToString();
        }

        private void InitalizeWorkoutListBox()
        {
            //puts them in reverse order by date
            for (int i = user.WorkoutHistory.Count-1; i > -1; i--)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = user.WorkoutHistory[i].workoutDate.ToString();
                WorkoutsListBox.Items.Add(item);
            }

        }

        private void InitalizeGoalListBox()
        {
            //puts them in reverse order by date
            for (int i = user.GoalList.Count - 1; i > -1; i--)
            {
                ListBoxItem item = new ListBoxItem();
                item.Content = user.GoalList[i].goalName;
                GoalListBox.Items.Add(item);
            }

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
                            MessageBox.Show("Invalid Credentials", user.collectedData[0].Item3.ToString(), MessageBoxButton.OK); //remove this just a test
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
                workoutTestTextbox.Text = ((ListBoxItem)WorkoutsListBox.SelectedItem).Content.ToString();
            }
            WorkoutUserControl.Visibility = Visibility.Visible;

        }

        //goals functions below
        private void setGoalButtonClick(object sender, RoutedEventArgs e)
        {
            setGoalPopup.IsOpen = true;
        }

        private void GoalsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GoalListBox.SelectedItem != null)
            {
                testTextbox.Text = ((ListBoxItem)GoalListBox.SelectedItem).Content.ToString();
            }

            GoalUserControl.Visibility = Visibility.Visible;

        }

        private void DeleteGoalButtonClick(object sender, RoutedEventArgs e)
        {  
            if(GoalListBox.Items.IndexOf(GoalListBox.SelectedItem) != -1)
            {
                testTextbox.Text = "Item Just Got Deleted";
                GoalListBox.Items.RemoveAt(GoalListBox.Items.IndexOf(GoalListBox.SelectedItem));
                CurrentGoalStackPanel.Children.Clear();
            }
            GoalUserControl.Visibility = Visibility.Hidden;
        }
    }
}
