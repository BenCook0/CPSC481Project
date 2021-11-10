using System.Collections.Generic;

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

        public static User Create(string deviceId, string password, List<Workout> workouts, List<Goal> goals)
        {
            return new User
            {
                DeviceId = deviceId,
                Password = password,
                WorkoutHistory = workouts,
                GoalList = goals
            };
        }
    }
}
