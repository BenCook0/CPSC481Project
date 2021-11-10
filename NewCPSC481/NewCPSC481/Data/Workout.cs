using System;
using System.Collections.Generic;
using System.Text;

namespace NewCPSC481.Data
{
    public class Workout
    {
        public DateTime workoutDate;
        public List<(String, int, int)> Exercises;

        public Workout(DateTime workoutDate, List<(String, int, int)> Exercises)
        {
            this.workoutDate = workoutDate;
            this.Exercises = Exercises;
        }
    }
}
