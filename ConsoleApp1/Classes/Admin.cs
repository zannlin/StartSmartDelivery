using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Admin : Roles
    {
        // Hardcoded credentials - Used in development only
        private const string HardcodedUsername = "admin";
        private const string HardcodedPassword = "password123";

        public Admin(string Username, string Password) : base(Username, Password)
        {
        }
        
        public bool Login()
        {
            bool isAuthenticated = false;

            for (int i=3; i>=0; i--)
            {
                Console.Write("Enter Username: ");
                Username = Console.ReadLine();
                Console.Clear();
                Console.Write("Enter Password: ");
                Password = Console.ReadLine();

                if (Username == HardcodedUsername && Password == HardcodedPassword)
                {
                    isAuthenticated = true;
                    Console.Clear();
                    Console.WriteLine("Login Succesful");
                    Console.WriteLine();
                    Console.WriteLine("Press Any Key to Continue.");
                    Console.ReadKey();
                    Console.Clear();
                    break;
                }
                else
                {

                    Console.Clear();
                    Console.WriteLine($"The Username or Password is invalid. Please try again.\n{i} Attempts Remaining!");
                    Console.WriteLine();
                    continue;

                }
            }
            return isAuthenticated;
        }
        public void ViewSystemLogs()
        {
            //TODO
        }
    }
}
