using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal static class Menu
    {
        enum MainMenu
        {
            Delivery_Management,
            Vehicle_Management,
            Driver_Management,
            Exit
        }
        enum DeliveryManagement
        {
            Add_Delivery,
            View_Deliveries,
            Search_Deliveries,
            Back
        }
        enum VehicleManagement
        {
            Add_Vehicle,
            Edit_Vehicle,
            View_All_Vechiles,
            View_Available_Vehicles,
            View_Vehicles_under_maintenance,
            Search_Vehicle,
            Back
        }
        enum DriverManagement
        {
            Add_Driver,
            Edit_Driver,
            View_Driver_Availability,
            Search_Driver,
            Back
        }

        public static void StartApp()
        {
            bool FirstRun = true;
            bool Exit = false;
            do
            {
                if (!FirstRun)
                {
                    Console.WriteLine("Press any key to continue");
                    Console.ReadLine();
                }

                Console.Clear();
                int Option_Main;
                DisplayEnum(typeof(MainMenu));
                Console.WriteLine("Please select an option");
                Option_Main = int.Parse(Console.ReadLine());
                switch (Option_Main)
                {
                    case 1://DeliveryManagement
                        Delivery_Management();

                        break;
                    case 2://VehicleManagement
                        Vehicle_Management();
                        break;
                    case 3://Driver_Management
                        Driver_Management();
                        break;
                    case 4://exit
                        Console.Clear();
                        Console.WriteLine("Exiting app. Enjoy your day!");
                        Exit = true;
                        break;
                }

                FirstRun = false;
            } while (Exit != true);

        }
        public static void Delivery_Management()
        {
            DefaultDeliveryTask DefaultDeliveryManager = new DefaultDeliveryTask();
            CustomDeliveryTask CustomDeliveryManager = new CustomDeliveryTask();

            bool back = false;
            do
            {
                int Option_Delivery;
                Console.Clear();
                Console.WriteLine("===== Delivery Management =====");
                DisplayEnum(typeof(DeliveryManagement));
                Console.WriteLine("Please select an option");
                Option_Delivery = int.Parse(Console.ReadLine());
                switch (Option_Delivery)
                {
                    case 1://Add_Delivery
                        Console.WriteLine("Delievery Preset: \n 1. Default \n 2. Custom");

                        int Option_Delivery_Sub = 0;
                        bool validOption = false;

                        while (!validOption)
                        {
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out Option_Delivery_Sub))
                            {
                                if (Option_Delivery_Sub == 1 || Option_Delivery_Sub == 2)
                                {
                                    validOption = true;
                                }
                                else
                                {
                                    Console.WriteLine("Invalid option. Please enter 1 or 2.");
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid input. Please enter a number.");
                            }
                        }

                        if (Option_Delivery_Sub == 1)
                        {
                            Console.Clear();
                            DefaultDeliveryManager.CreateOrder();
                        }
                        else if (Option_Delivery_Sub == 2)
                        {
                            Console.Clear();
                            CustomDeliveryManager.CreateOrder();
                        }

                        break;
                    case 2://View_Deliveries
                        Console.Clear();
            
                        Console.ReadLine();
                        break;
                    case 3://Search_Deliveries
                        Console.Clear();
                  
                        Console.ReadLine();
                        break;
                    case 4://back
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, please select an number between 1 and 4");
                        break;
                }
            } while (back != true);
        }
        public static void Vehicle_Management()
        {
            Vehicles VehicleManager = new Vehicles();
            bool back = false;

            do
            {
                int Option_Vehicle;
                Console.Clear();
                Console.WriteLine("===== Vehicle Management =====");
                DisplayEnum(typeof(VehicleManagement));
                Console.WriteLine("Please select an option");
                Option_Vehicle = int.Parse(Console.ReadLine());
                switch (Option_Vehicle)
                {
                    
                    case 1://Add_Vehicle
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    case 2://Remove_Vehicle
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    case 3://ViewAllVehicles
                        Console.Clear();
                        VehicleManager.ViewAllVehicles();
                        Console.ReadLine();
                        break;
                    case 4://View_Available_Vehicles
                        Console.Clear();
                        VehicleManager.ViewAvailable();
                        Console.ReadLine();
                        break;
                    case 5://View_Vehicles_under_maintenance
                        Console.Clear();
                        VehicleManager.ViewMaintanence();
                        Console.ReadLine();
                        break;
                    case 6://Search_Vehicle
                        Console.Clear();
                        VehicleManager.SearchVehicle();
                        Console.ReadLine();
                        break;
                    case 7://back
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, please select an number between 1 and 7");
                        break;
                }
            } while (back != true);

        }
        public static void Driver_Management()
        {
            List<Drivers> driverList = new List<Drivers>();
            bool back = false;
            do
            {
                Console.Clear();
                int Option_Driver;
                Console.WriteLine("===== Driver Management =====");
                DisplayEnum(typeof(DriverManagement));
                Console.WriteLine("Please select an option");
                Option_Driver = int.Parse(Console.ReadLine());
                switch (Option_Driver)
                {
                    case 1://Add_Driver
                        Console.Clear();
                        Drivers newDriver = Drivers.AddDrivers();
                        driverList.Add(newDriver);
                        Console.WriteLine("Driver added succesfully");
                        Console.ReadLine();
                        break;
                    case 2://Edit_Driver
                        Console.Clear();
                        Console.WriteLine("===== Editing Drivers =====");
                        Console.WriteLine();
                        Console.Write("Enter Employee Number of the driver to edit: ");
                        int editEmployeeNo = int.Parse(Console.ReadLine());
                        Drivers.SearchDriver(driverList,editEmployeeNo);
                        Drivers driverToEdit = Drivers.SearchDriver(driverList, editEmployeeNo);
                        if (driverToEdit != null)
                        {
                            driverToEdit.EditDriver();
                            Console.WriteLine("Driver edited successfully.");
                        }
                        else
                        {
                            Console.WriteLine("Driver not found.");
                        }
                        Console.ReadLine();
                        break;
                    case 3://View_Driver_Availability
                        Console.Clear();
                        Console.WriteLine("===== View Available Drivers =====");
                        Console.WriteLine();
                        Console.WriteLine("Available Drivers:");
                        foreach (var driver in driverList)
                        {
                            if (driver.Availability)  // Only show available drivers
                            {
                                Console.WriteLine(driver.ToString());
                            }
                        }
                        Console.ReadLine();
                        break;
                    case 4://Search_Driver
                        Console.Clear();
                        Console.WriteLine("===== Search Driver =====");
                        Console.WriteLine();
                        Console.Write("Enter Employee Number of the driver to search: ");
                        int searchEmployeeNo = int.Parse(Console.ReadLine());
                        Drivers searchedDriver = Drivers.SearchDriver(driverList, searchEmployeeNo);
                        if (searchedDriver != null)
                        {
                            Console.WriteLine("Driver found:");
                            searchedDriver.ViewDriverAvailability();
                        }
                        else
                        {
                            Console.WriteLine("Driver not found.");
                        }
                        Console.ReadLine();
                        break;
                    case 5://back
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, please select an number between 1 and 5");
                        break;
                }
            } while (back != true);
        }
        public static void DisplayEnum(Type enumName)
        {
            foreach (var option in Enum.GetValues(enumName))
            {
                string item = option.ToString().Replace("_", " ");
                Console.WriteLine($"{(int)option + 1}: {item}");
            }
        }
    }
}
