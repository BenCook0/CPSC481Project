using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading;

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
            Workout WorkoutA = new Workout(
                new DateTime(2021, 10, 30), 
                new List<(string, int, int)> { 
                    ("Pushup", 5, 12),
                    ("Situp", 3, 9),
                    ("Bicep Curls", 4, 10)
                });

            Workout WorkoutB = new Workout(
                new DateTime(2021, 10, 31),
                new List<(string, int, int)> {
                    ("Pushup", 8, 9),
                });

            Workout WorkoutC = new Workout(
                new DateTime(2021, 11, 01),
                new List<(string, int, int)> {
                    ("Bench Press", 4, 10),
                    ("Leg Press", 4, 11),
                    ("Lunges", 6, 10),
            });

            Workout WorkoutD = new Workout(
                new DateTime(2021, 11, 05),
                new List<(string, int, int)> {
                    ("Situp", 8, 9),
            });

            List <Workout> User1Workouts = new List<Workout> { WorkoutA, WorkoutB, WorkoutC, WorkoutD };
            List <Workout> User2Workouts = new List<Workout> {WorkoutB, WorkoutD };

            //build goals

            //standard goal example
            Goal goalA = new Goal(
                "Burn Extra Calories",
                new DateTime(2021, 11, 10),
                new DateTime(2021, 12, 15),
                "Calories",
                128,
                300,
                true,
                true
                );

            //no progress bar example
            Goal goalB = new Goal(
                "Do More Cardio",
                new DateTime(2021, 12, 10),
                new DateTime(2021, 12, 20),
                "Avg HeartRate",
                90,
                110,
                false,
                true
                );

            //progress bar but no percent example
            Goal goalC = new Goal(
                "Run Longer Distances",
                new DateTime(2021, 11, 10),
                new DateTime(2021, 12, 15),
                "Steps Taken",
                30000,
                40000,
                true,
                false
                );

            //no progress bar OR percent example
            Goal goalD = new Goal(
                "Burn Extra Calories",
                new DateTime(2021, 11, 10),
                new DateTime(2021, 12, 15),
                "Calories",
                128,
                300,
                false,
                false
                );

            //set each users goals
            List<Goal> User1Goals = new List<Goal> { goalA, goalB, goalC, goalD };
            List<Goal> User2Goals = new List<Goal> { goalA, goalD };

            //user 1 - 60 days of random data
            List<(DateTime, int, float, float)> User1collectedData = new List<(DateTime, int, float, float)>();
            DateTime user1Start = new DateTime(2021, 10, 01);

            Random rnd = new Random();

            for (int i = 0; i < 60; i++)
            {
                //generatees 60 days of random data
                User1collectedData.Add((user1Start, rnd.Next(600, 4000), rnd.Next(50, 600), rnd.Next(80, 140)));
                user1Start.AddDays(1); //generate 60 days of data starting october 1st
            }

            List<(DateTime, int, float, float)> User2collectedData = new List<(DateTime, int, float, float)>()
            {
                (new DateTime(2021,11,01),2000,300,95),             //date, steps, calories burned, bpm heartrate
            };

            //add users to the repository
            repository.Add(User.Create("User1", "Pass1", User1Workouts, User1Goals, User1collectedData));
            repository.Add(User.Create("User2", "Pass2", User2Workouts, User2Goals, User2collectedData));
            return repository;
        }
    }
}
