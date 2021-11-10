using System;
using System.Collections.Generic;
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

        private static DataRepository InitializeData()
        {
            var repository = new DataRepository();
            repository.Add(User.Create("User1", "pass1", 10000))
            return repository;
        }
    }
}
