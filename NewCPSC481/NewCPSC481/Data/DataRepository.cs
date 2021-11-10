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
            repository.Add(User.Create("User1", "Pass1", 10000));
            return repository;
        }
    }
}
