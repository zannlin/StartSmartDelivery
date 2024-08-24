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


            //Console.WriteLine("ADMIN LOGIN");
            //Console.WriteLine("===========");

            //Admin admin = new Admin(Username: "admin", Password: "password123");

            //bool isAuthenticated = admin.Login();

            //if (isAuthenticated)
            //{
            Console.WriteLine("WELCOME TO STARTSMART DELIVERY SYSTEM!!!");

            var defaultTask = new DefaultDeliveryTask(
    "1001",
    "2024-08-17",
    "Saturday",
    "14:00",
    "John Doe",
    "0123456789",
    "0987654321",
    "john.doe@example.com",
    "Boksburg",
    "Widget A",
    "1000",
    "Credit Card",
    "Handle with care",
    "C123"
);

            var customTask = new CustomDeliveryTask(
    "1002",
    "2024-08-18",
    "Sunday",
    "10:00",
    "Jane Smith",
    "0123456789",
    "0987654321",
    "jane.smith@example.com",
    "Benoni",
    "Gadget B",
    "1500",
    "Cash",
    "Deliver after noon"
);

            customTask.AddCustomField("Special Instructions", "Leave at the back door");
            customTask.AddCustomField("Delivery Type", "Express");

            Truck truck1 = new Truck("Volvo", "FH16", 2020, "ABC1234", 25.5);
            Truck truck2 = new Truck("Scania", "R500", 2019, "XYZ5678", 30.0);
            Truck truck3 = new Truck("Mercedes-Benz", "Actros", 2021, "LMN9101", 28.75);

            var driver1 = new Drivers("John", "Doe", 12345, "Code 10");
            var driver2 = new Drivers("Jane", "Smith", 67890, "Code 8");
            var driver3 = new Drivers("Michael", "Johnson", 11223, "Code 14");


            //This shouldnt be necessary anymore
            //List<DeliveryTask> list = DeliveryTask.DeliveryTaskList;
            //list.Add(defaultTask);
            //list.Add(customTask);

            Menu.StartApp();
            Console.ReadLine();
            //logging.Stop();
            //}

        }
    }
}
