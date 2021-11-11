using System;
using System.Collections.Generic;
using System.Linq;

namespace NewCPSC481.Data
{
    public class DataRepository
    {
        private static DataRepository singleton;

        public List<User> Users { get; set; }

        private void Add(User toAdd)
        {
            Users ??= new List<User>();
            Users.Add(toAdd);
        }

        public static DataRepository Instance => singleton ??= InitializeData();


        public static User Login(string deviceId, string password)
        {
            return Instance.Users.FirstOrDefault(x => x.DeviceId == deviceId && x.Password == password);            
        }


        private static DataRepository InitializeData()
        {
            //initalize repository
            var repository = new DataRepository();

            //build workouts
            var workoutA = new Workout(
                new DateTime(2021, 10, 30, 13,0,0), 
                new List<Exercise> { 
                    new Exercise("Pushup", 5, 12),
                    new Exercise("Situp", 3, 9),
                    new Exercise("Bicep Curls", 4, 10)
                });

            var workoutB = new Workout(
                new DateTime(2021, 10, 31, 06, 0,0),
                new List<Exercise> {
                    new Exercise("Pushup", 8, 9),
                });

            var workoutC = new Workout(
                new DateTime(2021, 11, 01, 18,0,0),
                new List<Exercise> {
                    new Exercise("Bench Press", 4, 10),
                    new Exercise("Leg Press", 4, 11),
                    new Exercise("Lunges", 6, 10),
            });

            var workoutD = new Workout(
                new DateTime(2021, 11, 05, 12, 30, 0),
                new List<Exercise> {
                    new Exercise("Situp", 8, 9),
            });

            var user1Workouts = new List<Workout> { workoutA, workoutB, workoutC, workoutD };
            var user2Workouts = new List<Workout> {workoutB, workoutD };

            //build goals

            //standard Target example
            var goalA = new Goal(
                "Burn Extra Calories",
                new DateTime(2021, 11, 10),
                new DateTime(2021, 12, 15),
                "Calories",
                100,
                128,
                300,
                true,
                true
                );

            //no progress bar example
            var goalB = new Goal(
                "Do More Cardio",
                new DateTime(2021, 12, 10),
                new DateTime(2021, 12, 20),
                "Avg HeartRate",
                75,
                90,
                110,
                false,
                true
                );

            //progress bar but no percent example
            var goalC = new Goal(
                "Run Longer Distances",
                new DateTime(2021, 11, 10),
                new DateTime(2021, 12, 15),
                "Steps Taken",
                1500,
                30000,
                40000,
                true,
                false
                );

            //no progress bar OR percent example
            var goalD = new Goal(
                "Lose Weight",
                new DateTime(2021, 10, 10),
                new DateTime(2021, 12, 19),
                "Calories",
                1000,
                2000,
                3000,
                false,
                false
                );

            //set each users goals
            var user1Goals = new List<Goal> { goalA, goalB, goalC, goalD };
            var user2Goals = new List<Goal> { goalA, goalD };

            //user 1 - 60 days of random data
            var user1CollectedData = new List<(DateTime, int, float, float)>();
            DateTime user1Start;
            user1Start = new DateTime(2021, 10, 01);

            var rnd = new Random();

            for (var i = 0; i < 60; i++)
            {
                //generatees 60 days of random data
                user1CollectedData.Add((user1Start, rnd.Next(600, 4000), rnd.Next(50, 600), rnd.Next(80, 140)));
                user1Start.AddDays(1); //generate 60 days of data starting october 1st
            }

            var user2CollectedData = new List<(DateTime, int, float, float)>()
            {
                (new DateTime(2021,11,01),2000,300,95),             //date, steps, calories burned, bpm heartrate
            };

            //add users to the repository
            repository.Add(User.Create("User1", "Pass1", user1Workouts, user1Goals, user1CollectedData));
            repository.Add(User.Create("User2", "Pass2", user2Workouts, user2Goals, user2CollectedData));
            return repository;
        }
    }
}
