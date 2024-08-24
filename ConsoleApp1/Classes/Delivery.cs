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

        public static void AssignVehicleToOrder(string OrderNumber, string Numberplate)
        {
            Delivery DeliveryToAssign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));
           
            if (DeliveryToAssign != null)
            {
               
                Vehicles VehicleToAssign = Vehicles.VehicleList.Find(vehicle =>vehicle.NumberPlate.Equals(Numberplate, StringComparison.OrdinalIgnoreCase));

                if (VehicleToAssign != null)
                {
                
                    DeliveryToAssign.AssignedVehicle = VehicleToAssign;
                    Console.WriteLine($"Vehicle {VehicleToAssign.Make} {VehicleToAssign.Model} with NumberPlate {Numberplate} assigned to Order {OrderNumber}.");
                }
                else
                {
                    throw new VehicleNotFoundException("Vehicle not found in list");
                }
            }
            else
            {
                throw new DeliveryTaskNotFoundException("Order not found");
            }

        }
        public static void AssignDriverToOrder(string OrderNumber, int EmployeeNo)
        {
            Delivery deliveryToAssign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));
            //Search for driver like above

            //if (deliveryToAssign != null)
            //{
            //    // Assign the driver to the found delivery
            //    deliveryToAssign.AssignedDriver = driver;
            //    driver.Availability = false; //Make unavailable
            //    Console.WriteLine($"Driver {driver.Name} {driver.Surname} with the EmployeeNO {driver.EmployeeNo} was assigned to Order {orderNumber}.");
            //}
            //else
            //{
            //    Console.WriteLine("Order not found.");
            //}
        }

        public static void ViewAllDeliveries()
        {
            if (DeliveryList.Count == 0)
            {
                Console.WriteLine("No deliveries available.");
            }
            else
            {
                Console.WriteLine("===== List of Deliveries =====");
                foreach (var delivery in DeliveryList)
                {
                    // Display the delivery task details
                    delivery.AssignedTask.DisplayDetails();

                    // Display the assigned driver
                    if (delivery.AssignedDriver != null)
                    {
                        Console.WriteLine($"Assigned Driver: {delivery.AssignedDriver.Name} {delivery.AssignedDriver.Surname} - EmployeeNo: {delivery.AssignedDriver.EmployeeNo}");
                    }
                    else
                    {
                        Console.WriteLine("Assigned Driver: Unassigned");
                    }

                    // Display the assigned vehicle
                    if (delivery.AssignedVehicle != null)
                    {
                        Console.WriteLine($"Assigned Vehicle: {delivery.AssignedVehicle.Make} {delivery.AssignedVehicle.Model}");
                    }
                    else
                    {
                        Console.WriteLine("Assigned Vehicle: Unassigned");
                    }

                    // Display the delivery status
                    if (!string.IsNullOrEmpty(delivery.DeliveryStatus))
                    {
                        Console.WriteLine($"Delivery Status: {delivery.DeliveryStatus}");
                    }
                    else
                    {
                        Console.WriteLine("Delivery Status: Unassigned");
                    }

                    Console.WriteLine(); // Add a line break between deliveries
                }
            }
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
