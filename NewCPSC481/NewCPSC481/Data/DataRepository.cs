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
            var repository = new DataRepository();

            //manually build some users here


            Workout a = new Workout(
                new DateTime(2021, 04, 30), 
                new List<(string, int, int)> { 
                    ("Pushup", 5, 12),
                    ("Situp", 3, 9,
                    ("Bicep Curls", 4, 10)
                });

            List <Workout> User1Workouts = new List<Workout> { a,a,a };

            repository.Add(User.Create("User1", "Pass1", User1Workouts));
            return repository;
        }
    }
}
