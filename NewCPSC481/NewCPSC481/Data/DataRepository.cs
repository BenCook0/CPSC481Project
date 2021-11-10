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
            List<Workout> User2Workouts = new List<Workout> {WorkoutB, WorkoutD };


            //add users to the repository
            repository.Add(User.Create("User1", "Pass1", User1Workouts));
            repository.Add(User.Create("User2", "Pass2", User2Workouts));
            return repository;
        }
    }
}
