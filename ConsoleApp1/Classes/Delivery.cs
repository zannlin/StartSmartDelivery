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
                try
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
                catch (InvalidDeliveryStatusException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }
            }
        }


        public static void AssignVehicleToOrder(string OrderNumber, string Numberplate)
        {
            Delivery DeliveryToAssign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));

            try
            {
                if (DeliveryToAssign != null)
                {

                    Vehicles VehicleToAssign = Vehicles.VehicleList.Find(vehicle => vehicle.NumberPlate.Equals(Numberplate, StringComparison.OrdinalIgnoreCase));
                    VehicleToAssign.Availability = "Unavailable";
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
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DeliveryTaskNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void UnassignVehicleFromOrder(string OrderNumber, string Numberplate)
        {
            Delivery DeliveryToUnassign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));

            try
            {
                if (DeliveryToUnassign != null)
                {
                    Vehicles VehicleToUnassign = Vehicles.VehicleList.Find(vehicle => vehicle.NumberPlate.Equals(Numberplate, StringComparison.OrdinalIgnoreCase));

                    if (VehicleToUnassign != null)
                    {
                        if (DeliveryToUnassign.AssignedVehicle == VehicleToUnassign)
                        {
                            DeliveryToUnassign.AssignedVehicle = null;
                            VehicleToUnassign.Availability = "Available";
                            Console.WriteLine($"Vehicle {VehicleToUnassign.Make} {VehicleToUnassign.Model} with NumberPlate {Numberplate} has been unassigned from Order {OrderNumber}.");
                        }
                        else
                        {
                            throw new VehicleNotAssignedException("Vehicle is not assigned to this order");
                        }
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
            catch (VehicleNotAssignedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (VehicleNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DeliveryTaskNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void AssignDriverToOrder(string OrderNumber, int EmployeeNo)
        {
            Delivery DeliveryToAssign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));

            try
            {

   
            if (DeliveryToAssign != null)
            {

                Drivers DriverToAssign = Drivers.DriverList.Find(driver => driver.EmployeeNo == EmployeeNo);
                DriverToAssign.Availability = false;

                if (DriverToAssign != null)
                {
                    DeliveryToAssign.AssignedDriver = DriverToAssign;

                    Console.WriteLine($"Driver {DriverToAssign.Name} {DriverToAssign.Surname} with the EmployeeNO {DriverToAssign.EmployeeNo} was assigned to Order {OrderNumber}.");
                }
                else
                {
                    throw new DriverNotFoundException("Vehicle not found in list");
                }
            }
            else
            {
                throw new DeliveryTaskNotFoundException("Order not found");
            }
            }
            catch (DriverNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DeliveryTaskNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }

        public static void UnassignDriverFromOrder(string OrderNumber, int EmployeeNo)
        {
            Delivery DeliveryToUnassign = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));

            try
            {
                if (DeliveryToUnassign != null)
                {
                    Drivers DriverToUnassign = Drivers.DriverList.Find(driver => driver.EmployeeNo == EmployeeNo);

                    if (DriverToUnassign != null)
                    {
                        if (DeliveryToUnassign.AssignedDriver == DriverToUnassign)
                        {
                            DeliveryToUnassign.AssignedDriver = null;
                            DriverToUnassign.Availability = true;
                            Console.WriteLine($"Driver {DriverToUnassign.Name} {DriverToUnassign.Surname} with EmployeeNo {EmployeeNo} has been unassigned from Order {OrderNumber}.");
                        }
                        else
                        {
                            throw new DriverNotAssignedException("Driver is not assigned to this order");
                        }
                    }
                    else
                    {
                        throw new DriverNotFoundException("Driver not found in list");
                    }
                }
                else
                {
                    throw new DeliveryTaskNotFoundException("Order not found");
                }
            }
            catch (DriverNotAssignedException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DriverNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (DeliveryTaskNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
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
                    delivery.GetDetails();
                }
            }
        }

        public void GetDetails()
        {
            // Display the delivery task details
            if (AssignedTask != null)
            {
                AssignedTask.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Delivery Task: Unassigned");
            }

            // Display the assigned driver
            if (AssignedDriver != null)
            {
                Console.WriteLine($"Assigned Driver: {AssignedDriver.Name} {AssignedDriver.Surname} - EmployeeNo: {AssignedDriver.EmployeeNo}");
            }
            else
            {
                Console.WriteLine("Assigned Driver: Unassigned");
            }

            // Display the assigned vehicle
            if (AssignedVehicle != null)
            {
                Console.WriteLine($"Assigned Vehicle: {AssignedVehicle.Make} {AssignedVehicle.Model}");
            }
            else
            {
                Console.WriteLine("Assigned Vehicle: Unassigned");
            }

            // Display the delivery status
            if (!string.IsNullOrEmpty(DeliveryStatus))
            {
                Console.WriteLine($"Delivery Status: {DeliveryStatus}");
            }
            else
            {
                Console.WriteLine("Delivery Status: Unassigned");
            }

            Console.WriteLine(); // Add a line break between deliveries
        }

        public static Delivery SearchDeliveries(string OrderNumber)
        {
            Delivery foundDelivery = DeliveryList.Find(delivery => delivery.AssignedTask.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));
            try
            {
                if (foundDelivery != null)
                {
                    return foundDelivery;
                }
                else
                {
                    throw new DeliveryTaskNotFoundException("Order not found");
                }
            }
            catch (DeliveryTaskNotFoundException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            return null;
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
