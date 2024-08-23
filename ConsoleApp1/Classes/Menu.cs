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

                        int option = 0;
                        bool validOption = false;

                        while (!validOption)
                        {
                            string input = Console.ReadLine();

                            if (int.TryParse(input, out option))
                            {
                                if (option == 1 || option == 2)
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

                        if (option == 1)
                        {
                            Console.Clear();
                            DefaultDeliveryManager.CreateOrder();
                        }
                        else if (option == 2)
                        {
                            Console.Clear();
                            CustomDeliveryManager.CreateOrder();
                        }

                        break;
                    case 2://View_Deliveries
                        DefaultDeliveryManager.ViewAllDeliveries();
                        break;
                    case 3://Search_Deliveries

                        break;
                    case 4://back
                        back = true;
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
                        Console.ReadLine();
                        break;
                    case 2://Edit_Vehicle
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

                        Console.ReadLine();
                        break;
                    case 3://View_Driver_Availability
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    case 4://Search_Driver
                        Console.Clear();

                        Console.ReadLine();
                        break;
                    case 5://back
                        back = true;
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
