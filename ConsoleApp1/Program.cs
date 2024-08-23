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
            //Console.Write("Enter Username: ");
            //string Username = Console.ReadLine();
            //Console.Write("Enter Password: ");
            //string Password = Console.ReadLine();
            //Admin Admin=new Admin(Username,Password);

            // Create an instance of Deliveries to hold all tasks
   

 
            // Create a Deliveries instance
            var deliveries = new Deliveries();

            // Create a DefaultDeliveryTask using the constructor
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

            // Add DefaultDeliveryTask to the list
            deliveries.AddTask(defaultTask);

            // Create a CustomDeliveryTask using the constructor
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

            // Add custom fields
            customTask.AddCustomField("Special Instructions", "Leave at the back door");
            customTask.AddCustomField("Delivery Type", "Express");

            // Add CustomDeliveryTask to the list
            deliveries.AddTask(customTask);

            // Display all tasks
            deliveries.DisplayAllTasks();

            Console.ReadLine(); // Pause the console to view the output
        }
    }
}
