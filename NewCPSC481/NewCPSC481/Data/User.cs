using System.Collections.Generic;

namespace NewCPSC481.Data
{
    public class User
    {
        public string DeviceId { get; set; }
        public string Password { get; set; }
        
        public List<int> StepsTaken {get; set; }
        
        public User() => StepsTaken = new List<int>();

        public static User Create(string deviceId, string password, int steps)
        {
            return new User
            {
                DeviceId = deviceId,
                Password = password,
                StepsTaken = new List<int> {steps}
            };
        }
    }
}
