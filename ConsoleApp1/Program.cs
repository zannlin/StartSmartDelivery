using ConsoleApp1.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter Username: ");
            string Username = Console.ReadLine();
            Console.Write("Enter Password: ");
            string Password = Console.ReadLine();
            Admin Admin=new Admin(Username,Password);
            Console.ReadLine();
        }
    }
}
