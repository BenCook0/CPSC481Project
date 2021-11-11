using System;
using System.Windows;
using System.Windows.Controls;
using NewCPSC481.Data;

namespace NewCPSC481
{
    /// <summary>
    /// Interaction logic for GoalUserControl.xaml
    /// </summary>
    public partial class GoalUserControl : UserControl
    {
        private Goal goal;
        public GoalUserControl()
        {
            InitializeComponent();
        }

        public void SetGoal(Goal goal)
        {
            this.goal = goal;
            DataContext = goal;
            CurrentDate.Text = DateTime.Today.ToString("yyyy-MM-dd");

            GoalProgressBar.Visibility = goal.ShowProgress ? Visibility.Visible : Visibility.Hidden;
            GoalPercentLabel.Visibility = goal.HasPercentShown ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
