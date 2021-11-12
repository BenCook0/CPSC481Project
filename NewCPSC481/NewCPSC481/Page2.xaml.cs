﻿using NewCPSC481;
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
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
        readonly GoalUserControl goalUserControl = new GoalUserControl();
        readonly WorkoutUserControl workoutUserControl = new WorkoutUserControl();

        public Page2()
        {
            InitializeComponent();

            //fill recent data with user data
            WorkoutListStackPanel.Children.Add(workoutUserControl);
            CurrentGoalStackPanel.Children.Add(goalUserControl);
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
            workoutUserControl.Visibility = Visibility.Hidden;

            InitalizeGoalListBox();
            goalUserControl.Visibility = Visibility.Hidden;

            Events.UserGoalCreated += OnGoalCreated;
            Events.CloseGoalControl += CloseGoalControl;
        }

        //initalize page functions
        private void InitalizeRecentData()
        {
            DailyStepsTaken.Text = user.CollectedData[^1].Item2.ToString();
            DailyCalories.Text = user.CollectedData[^1].Item3.ToString();
            DailyHeartRate.Text = user.CollectedData[^1].Item4.ToString();
        }

        private void InitalizeWeeklyData()
        {
            float weeklyStepsAvg = 0;
            float WeeklyCalorieAvg = 0;
            float weeklyHeartRateAvg = 0;

            //if this is a new user and they have less than 1 week of data then just count them, otherwise
            for(int i = Math.Max(user.CollectedData.Count -7,0); i < user.CollectedData.Count; i++)
            {
                weeklyStepsAvg += user.CollectedData[i].Item2;
                WeeklyCalorieAvg += user.CollectedData[i].Item3;
                weeklyHeartRateAvg += user.CollectedData[i].Item4;
            }
            weeklyStepsAvg = weeklyStepsAvg / (Math.Min(7, user.CollectedData.Count));
            WeeklyCalorieAvg = WeeklyCalorieAvg / Math.Min(7, user.CollectedData.Count);
            weeklyHeartRateAvg = weeklyHeartRateAvg / (Math.Min(7, user.CollectedData.Count));

            WeeklyStepsTaken.Text = weeklyStepsAvg.ToString();
            WeeklyCalories.Text = WeeklyCalorieAvg.ToString();
            WeeklyHeartRate.Text = weeklyHeartRateAvg.ToString();
        }

        private void InitalizeWorkoutListBox()
        {
            WorkoutsListBox.ItemsSource = user.WorkoutHistory.OrderByDescending(x => x.WorkoutDate)
                .Select(x => x.WorkoutDate.ToString("g"));
        }

        private void InitalizeGoalListBox()
        {
            GoalListBox.ItemsSource = user.GoalList.Select(x => x.Name);
        }

        private void LogOutButtonClick(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Page1());
            NavigationService.RemoveBackEntry();
        }

        //welcome page click functions
        private void RecentDataButtonClick(object sender, RoutedEventArgs e)
        {
            MainTabControl.SelectedIndex = 1;
                            MessageBox.Show("Invalid Credentials", user.CollectedData[0].Item3.ToString(), MessageBoxButton.OK); //remove this just a test
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
            setGoalPopup.IsOpen = true;
        }

        //workout functions below
        private void WorkoutListBoxSelection(object sender, SelectionChangedEventArgs e)
        {
            if (WorkoutsListBox.SelectedItem == null)
            {
                workoutUserControl.Visibility = Visibility.Hidden;
                return;
            }

            var workoutDate = AsDateTime(WorkoutsListBox.SelectedItem.ToString());
            workoutTestTextbox.Text = workoutDate.ToString("g");

            workoutUserControl.SetWorkout(user.GetWorkoutForDate(workoutDate));
            workoutUserControl.Visibility = Visibility.Visible;
        }

        private static DateTime AsDateTime(string value)
        {
            return DateTime.Parse(value);
        }

        //goals functions below

        private void OnGoalCreated(Goal goal)
        {
            setGoalPopup.IsOpen = false;
            user.AddNewGoal(goal);
            InitalizeGoalListBox();
        }

        private void CloseGoalControl()
        {
            setGoalPopup.IsOpen = false;
        }

        private void GoalsSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (GoalListBox.SelectedItem == null)
            {
                goalUserControl.Visibility = Visibility.Hidden;
                return;
            }

            var goalName = GoalListBox.SelectedItem.ToString();
            testTextbox.Text = goalName;
            goalUserControl.SetGoal(user.GetGoalByName(goalName));

            goalUserControl.Visibility = Visibility.Visible;
        }

        private void DeleteGoalButtonClick(object sender, RoutedEventArgs e)
        {
            if (GoalListBox.Items.IndexOf(GoalListBox.SelectedItem) == -1) return;

            testTextbox.Text = "Item Just Got Deleted";
            var goalName = GoalListBox.SelectedItem.ToString();
            user.RemoveGoal(goalName);

            InitalizeGoalListBox();
            goalUserControl.Visibility = Visibility.Hidden;
        }
    }
}
