using System;
using System.Collections.Generic;
using System.Text;

namespace NewCPSC481.Data
{
    public class Goal
    {
        public string goalName;
        public DateTime startDate;
        public DateTime endDate;
        public string goalMetric;
        public float current;
        public float goal;
        public bool hasProgressBar;

        //nullable, if its not checked by the user
        public float? percentTowardsGoal;

        public Goal(string goalName,  DateTime startDate,  DateTime endDate, string goalMetric, float current, float goal, bool hasProgressBar,float? percentTowardsGoal)
        {
            this.goalName = goalName;
            this.startDate = startDate;
            this.endDate = endDate;
            this.goalMetric = goalMetric;
            this.current = current;
            this.goal = goal;
            this.hasProgressBar = hasProgressBar;
            this.percentTowardsGoal = percentTowardsGoal;
        }
    }
}
