using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCPSC481.Data
{
    public class User 
    {
        public string DeviceId { get; set; }
        public string Password { get; set; }

        //list of workouts, workout class is Datetime and an array of (string, int, int)
        public List<Workout> WorkoutHistory { get; set; }

        //List of Goals
        public List<Goal> GoalList { get; set; }

        //collected data, each is made of "Datetime, int (steps taken), float (cals burned) and float (avg bpm)
        public List<(DateTime, int, float, float)> CollectedData;

        public static User Create(string deviceId, string password, List<Workout> workouts, List<Goal> goals, List<(DateTime, int, float, float)> data)
        {
            return new User
            {
                DeviceId = deviceId,
                Password = password,
                WorkoutHistory = workouts,
                GoalList = goals,
                CollectedData = data
            };
        }

        public Workout GetWorkoutForDate(DateTime workoutDate)
        {
            return WorkoutHistory.First(x => x.WorkoutDate == workoutDate);
        }

        public Goal GetGoalByName(string  goalName)
        {
            return GoalList.First(x => x.Name == goalName);
        }

        public void RemoveGoal(string goalName)
        {
            var goal = GetGoalByName(goalName);
            GoalList.Remove(goal);
        }

        public void AddNewGoal(Goal newGoal)
        {
            if (GoalList.Exists(x => x.Name == newGoal.Name))
                throw new ArgumentException($"Goal with name: {newGoal.Name} already exists");
            GoalList.Add(newGoal);
        }
    }
}
