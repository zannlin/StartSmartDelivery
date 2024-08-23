using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace StartSmartDelivery
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
                    DialogResult result = MessageBox.Show("Username or password is invalid please try again", "Invalid", MessageBoxButtons.RetryCancel);
                    
                }
            }
        }

        public void ViewSystemLogs()
        {
            //TODO
        }
    }
}
