using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace finali
{
    class Program
    {
        static string usersFilePath = "userebi.json";
        static string logFilePath = "logebi.json";

        static List<User> users;
        static List<string> logs;

        static void Main(string[] args)
        {
            users = LoadData<List<User>>(usersFilePath) ?? new List<User>();
            logs = LoadData<List<string>>(logFilePath) ?? new List<string>();

            while (true)
            {
                Console.WriteLine("\n1. Register\n2. Login\n3. Exit");
                Console.Write("Enter your choice: ");
                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        Register();
                        break;
                    case "2":
                        Login();
                        break;
                    case "3":
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Invalid choice");
                        break;
                }
            }
        }

        static void Register()
        {
            Console.Write("Enter your name: ");
            string name = Console.ReadLine();
            Console.Write("Enter your last name: ");
            string lastName = Console.ReadLine();
            Console.Write("Enter your personal number:");
            string personalNumber = Console.ReadLine();

            if (personalNumber.Length != 11)
            {
                Console.WriteLine("Personal number must be 11 digits long");
                return;
            }

            if (users.Exists(user => user.PersonalNumber == personalNumber))
            {
                Console.WriteLine("User with this personal number already exists.");
                return;
            }


            string password = GenerateRandomPassword();

            int userId = users.Count + 1; // Assign unique ID
            User newUser = new User(userId, name, lastName, personalNumber, password, 0);
            users.Add(newUser);
            SaveData(users, usersFilePath);
            Console.WriteLine($"User registered successfully! Your personal number is: {personalNumber}, and your password is: {password}");
        }

        static void Login()
        {
            Console.Write("Enter your personal number: ");
            string personalNumber = Console.ReadLine();

            User currentUser = users.Find(user => user.PersonalNumber == personalNumber);
            if (currentUser != null)
            {
                Console.Write("Enter your password: ");
                string password = Console.ReadLine();

                if (currentUser.Password == password)
                {
                    Console.WriteLine($"Welcome, {currentUser.Name}!");
                    while (true)
                    {
                        Console.WriteLine("\n1. Check Balance\n2. Deposit\n3. Withdraw\n4. View Transaction History\n5. Logout");
                        Console.Write("Enter your choice: ");
                        string option = Console.ReadLine();

                        switch (option)
                        {
                            case "1":
                                CheckBalance(currentUser);
                                break;
                            case "2":
                                Deposit(currentUser);
                                break;
                            case "3":
                                Withdraw(currentUser);
                                break;
                            case "4":
                                ViewTransactionHistory(currentUser);
                                break;
                            case "5":
                                Console.WriteLine("Logged out successfully.");
                                return;
                            default:
                                Console.WriteLine("Invalid choice");
                                break;
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Invalid password.");
                }
            }
            else
            {
                Console.WriteLine("User not found.");
            }
        }

        static void CheckBalance(User currentUser)
        {
            Console.WriteLine($"Your balance: {currentUser.Balance}");
            LogAction($"{currentUser.Name} {currentUser.LastName} checked the balance.", currentUser.UserId);
        }

        static void Deposit(User currentUser)
        {
            Console.Write("Enter deposit amount: ");
            double amount;
            if (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return;
            }

            currentUser.Balance += amount;
            SaveData(users, usersFilePath);
            Console.WriteLine($"Deposit successful. Your new balance: {currentUser.Balance}");
            LogAction($"{currentUser.Name} {currentUser.LastName} deposited {amount:C} into the account.", currentUser.UserId);
        }

        static void Withdraw(User currentUser)
        {
            Console.Write("Enter withdrawal amount: ");
            double amount;
            if (!double.TryParse(Console.ReadLine(), out amount) || amount <= 0)
            {
                Console.WriteLine("Invalid amount");
                return;
            }

            if (currentUser.Balance < amount)
            {
                Console.WriteLine("Insufficient funds");
                return;
            }

            currentUser.Balance -= amount;
            SaveData(users, usersFilePath);
            Console.WriteLine($"Withdrawal successful. Your new balance: {currentUser.Balance}");
            LogAction($"{currentUser.Name} {currentUser.LastName} withdrew {amount:C} from the account.", currentUser.UserId);
        }

        static void ViewTransactionHistory(User currentUser)
        {
            foreach (var log in logs)
            {
                Console.WriteLine(log);
            }
        }

        static string GenerateRandomPassword()
        {
            Random rnd = new Random();
            return rnd.Next(1000, 10000).ToString("D4");
        }

        static void LogAction(string action, int userId)
        {
            string logEntry = $"{DateTime.Now:dd.MM.yyyy HH:mm:ss} - {action} User ID: {userId}";
            logs.Add(logEntry);
            SaveData(logs, logFilePath);
            Console.WriteLine(logEntry); // Print log message to console
        }

        static T LoadData<T>(string filePath)
        {

            if (File.Exists(filePath))
            {
                string json = File.ReadAllText(filePath);
                return JsonConvert.DeserializeObject<T>(json);
            }


            return default(T);
        }

        static void SaveData<T>(T data, string filePath)
        {

            string json = JsonConvert.SerializeObject(data, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(filePath, json);

        }
    }
}

    