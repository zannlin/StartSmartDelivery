using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Delivery
    {
        static readonly string[] AllowedValues = { "Scheduled", "In Progress", "Cancelled", "Complete" };

        static List<Delivery> _DeliveryList = new List<Delivery>();

        public static List<Delivery> DeliveryList
        {
            get { return _DeliveryList; }
            set { _DeliveryList = value; }
        }

        DeliveryTask _AssignedTask;
        Drivers _AssignedDriver;
        Vehicles _AssignedVehicle;
        string _DeliveryStatus;
                
        public DeliveryTask AssignedTask
        {
            get { return _AssignedTask; }
            set { _AssignedTask = value; }
        }
        public Drivers AssignedDriver
        {
            get { return _AssignedDriver; }
            set { _AssignedDriver = value; }
        }

        public Vehicles AssignedVehicle
        {
            get { return _AssignedVehicle; }
            set { _AssignedVehicle = value; }
        }

        public string DeliveryStatus
        {
            get { return _DeliveryStatus; }
            set
            {
                if (AllowedValues.Contains(value))
                {
                    _DeliveryStatus = value;
                }
                else
                {
                    throw new InvalidDeliveryStatusException("Invalid Delivery Status Entered. Enter 'Scheduled', 'In Progress', 'Cancelled' or 'Complete'");
                }
            }
        }

        public static void AssignDriverToOrder(string orderNumber, Drivers driver)
        {
            DeliveryTask taskToAssign = DeliveryTask.DeliveryTaskList.Find(task => task.OrderNumber.Equals(orderNumber, StringComparison.OrdinalIgnoreCase));

            if (taskToAssign != null)
            {
              

                //((Delivery)taskToAssign).AssignedDriver = driver;
                //Console.WriteLine($"Driver {driver.Fullname} assigned to Order {orderNumber}.");
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }

        public static void ViewAllDeliveries()
        {
            DeliveryTask.ViewAllDeliveryTasks();
        }

        public Delivery() { }

        public Delivery(DeliveryTask AssignedTask)
        {
            _AssignedTask = AssignedTask;
            _DeliveryStatus = "Scheduled";
        }
        public Delivery(DeliveryTask AssignedTask, Drivers AssignedDriver)
        {
            _AssignedTask = AssignedTask;
            _AssignedDriver = AssignedDriver;
            _DeliveryStatus = "Scheduled";
        }

        public Delivery(DeliveryTask AssignedTask, Vehicles AssignedVehicle)
        {
            _AssignedTask = AssignedTask;
            _AssignedVehicle = AssignedVehicle;
            _DeliveryStatus = "Scheduled";
        }

        public Delivery(DeliveryTask AssignedTask, Drivers AssignedDriver, Vehicles AssignedVehicle)
        {
            _AssignedTask = AssignedTask;
            _AssignedDriver = AssignedDriver;
            _AssignedVehicle = AssignedVehicle;
            _DeliveryStatus = "Scheduled";
        }
    }
}
