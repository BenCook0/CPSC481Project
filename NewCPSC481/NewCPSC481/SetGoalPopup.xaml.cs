using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using NewCPSC481.Data;

namespace NewCPSC481
{
    /// <summary>
    /// Interaction logic for SetGoalPopup.xaml
    /// </summary>
    public partial class SetGoalPopup : Page
    {
        private readonly List<string> errors = new List<string>();

        public User User { get; set; }

        public SetGoalPopup()
        {
            InitializeComponent();
        }
        
        private void OnAddGoalClick(object sender, RoutedEventArgs e)
        {
            if (!IsValid()) return;
            try
            {
                Events.RaiseGoalCreated(AssembleGoal());
                Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButton.OK);
            }
        }

        private void Clear()
        {
            GoalMetricComboBox.Text = "choose one";
            GoalNameTextBox.Text = string.Empty;
            StartDatePicker.SelectedDate = DateTime.Today;
            EndDatePicker.SelectedDate = DateTime.Today;
            CurrentValueTextBox.Text = string.Empty;
            GoalTextBox.Text = string.Empty;
            AddPercentageCheckBox.IsChecked = false;
            ShowProgessCheckBox.IsChecked = false;
        }

        private Goal AssembleGoal()
        {
            return new Goal
            {
                Name = GoalNameTextBox.Text,
                GoalMetric = GoalMetricComboBox.Text,
                StartDate = StartDatePicker.SelectedDate.Value,
                EndDate = EndDatePicker.SelectedDate.Value,
                Start = float.Parse(CurrentValueTextBox.Text),
                Target = float.Parse(GoalTextBox.Text),
                HasPercentShown = AddPercentageCheckBox.IsChecked?? false,
                ShowProgress = ShowProgessCheckBox.IsChecked?? false
            };
        }

        private bool IsValid()
        {
            errors.Clear();

            HasValue(GoalNameTextBox.Text, "Goal name missing");
            HasValue(StartDatePicker.Text, "Start date missing");
            HasValue(EndDatePicker.Text, "EndDate missing");
            HasValue(GoalMetricComboBox.Text, "Missing goal metric missing");
            HasValue(CurrentValueTextBox.Text, "Current value missing");
            HasValue(GoalTextBox.Text, "Goal value missing");

            IsTrue(StartDatePicker.SelectedDate >= DateTime.Today, "Start Date invalid");
            IsTrue(StartDatePicker.SelectedDate <= EndDatePicker.SelectedDate, "Start Date must be <= End Date");

            if (errors.Count == 0)
            {
                return true;
            }

            MessageBoxWrapper.Show(FormatErrors(), "Errors", MessageBoxButton.OK, MessageBoxImage.Error);
            return false;

        }

        private void IsTrue(bool value, string message)
        {
            if (!value)
                errors.Add(message);
        }

        private string FormatErrors()
        {
            var builder = new StringBuilder();
            builder.AppendLine("Errors");

            errors.ForEach(each => builder.AppendLine($"- {each}"));
            return builder.ToString();
        }

        private void HasValue(string value, string message)
        {
            if (string.IsNullOrEmpty(value)) 
                errors.Add(message);
        }

        private void DecimalInput(object sender, TextCompositionEventArgs e)
        {
            var approvedDecimalPoint = false;

            if (e.Text == ".")
            {
                if (!((TextBox)sender).Text.Contains("."))
                    approvedDecimalPoint = true;
            }

            if (!(char.IsDigit(e.Text, e.Text.Length - 1) || approvedDecimalPoint))
                e.Handled = true;
        }
    }
}
