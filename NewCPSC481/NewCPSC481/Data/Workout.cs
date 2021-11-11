using System;
using System.Collections.Generic;

namespace NewCPSC481.Data
{
    public class Workout
    {
        public DateTime WorkoutDate { get; set; }
        public List<Exercise> Exercises { get; set; }

        public Workout(DateTime workoutDate, List<Exercise> exercises)
        {
            WorkoutDate = workoutDate;
            Exercises = exercises;
        }
    }

    public class Exercise
    {
        public string Name { get; set; }
        public int Sets { get; set; }
        public int Reps { get; set; }

        public Exercise() { } //for serialization

        public Exercise(string name, int sets, int reps)
        {
            Name = name;
            Sets = sets;
            Reps = reps;
        }

    }

}
