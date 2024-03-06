using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

using System.Linq;

namespace finali
{
    class User
    {
        public int UserId { get; } 
        public string Name { get; }
        public string LastName { get; }
        public string PersonalNumber;
        
        public string Password { get; }
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

