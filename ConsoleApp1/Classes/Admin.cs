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

            //Should you wish to limit the attempts - change while condition 
            bool isAuthenticated = false;
            while (!isAuthenticated)
            {
                if (Username == HardcodedUsername && Password == HardcodedPassword)
                {
                    isAuthenticated = true;
                    Console.WriteLine("Success");
                }
                else
                {
                    Console.WriteLine("The Username or Password is invalid. Please try again.");
                    Console.Write("Enter Username: ");
                    Username = Console.ReadLine();
                    Console.Write("Enter Password: ");
                    Password = Console.ReadLine();
                }
            }
        }

        public void ViewSystemLogs()
        {
            //TODO
        }
    }
}
