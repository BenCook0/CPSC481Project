using System;

namespace NewCPSC481.Data
{
    public class Goal
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string GoalMetric { get; set; }
        public float Start { get; set; }
        public float Current { get; set; }
        public float Target { get; set; }
        public bool ShowProgress { get; set; }

        //nullable, if its not checked by the user
        public bool HasPercentShown { get; set; }
        public double PercentTowardsGoal { get; set; }

        public Goal() { }

        public Goal(string name,  DateTime startDate,  DateTime endDate, string goalMetric, float start, float current, float target, bool showProgress, bool hasPercentShown)
        {
            Name = name;
            StartDate = startDate;
            EndDate = endDate;
            GoalMetric = goalMetric;
            Start = start;
            Current = current;
            Target = target;
            ShowProgress = showProgress;
            HasPercentShown = hasPercentShown;
            PercentTowardsGoal = Math.Round((current - start) / (target - start)*100, 2);
        }
    }
}
