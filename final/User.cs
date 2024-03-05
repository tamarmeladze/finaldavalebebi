using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using System.Linq;

namespace finali
{ 
    class User
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PersonalNumber { get; set; }
        public string Password { get; set; }
        public double Balance { get; set; }

        public User(int userId, string name, string lastName, string personalNumber, string password, double balance)
        {
            UserId = userId;
            Name = name;
            LastName = lastName;
            PersonalNumber = personalNumber;
            Password = password;
            Balance = balance;
        }
    }
}
