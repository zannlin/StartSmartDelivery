using ConsoleApp1.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal abstract class Roles : IRoles
    {
        string _Username;
        string _Password;

        public string Username { get { return _Username; } set { _Username = value; } }
        public string Password { get { return _Password; } set { _Password = value; } }
        public Roles(string Username, string Password)
        {
            _Username = Username;
            _Password = Password;
        }
    }
}
