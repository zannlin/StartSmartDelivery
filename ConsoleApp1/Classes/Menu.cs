using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;

namespace ConsoleApp1.Classes
{
    internal static class Menu
    {
        enum MainMenu
        {
            Delivery_Management,
            Vehicle_Management,
            Driver_Management,
            View_Logs,
            Exit
        }
        enum DeliveryManagement
        {
            Add_Delivery,
            Manage_Vehicle_Assignment,
            Manage_Driver_Assignment,
            View_Deliveries,
            Search_Deliveries,
            Back
        }
        enum VehicleManagement
        {
            Add_Vehicle,
            Remove_Vehicle,
            Edit_Vehicle,
            View_All_Vehicles,
            View_Available_Vehicles,
            View_Vehicles_under_maintenance,
            Search_Vehicle,
            Back
        }
        enum DriverManagement
        {
            Add_Driver,
            Edit_Driver,
            View_All_Drivers,
            View_Driver_Availability,
            Search_Driver,
            Back
        }

        public static void StartApp()
        {
            OperationLogs logging = new OperationLogs();
            logging.Start();

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
                    case 4:
                        ViewLogs(logging);
                        Console.ReadLine();
                        break;
                    case 5://exit
                        Console.Clear();
                        Console.WriteLine("Exiting app. Enjoy your day!");
                        Exit = true;
                        logging.Stop();
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
                string Prompt;
                string OrderNumber;
    
                int Option_Delivery_Sub = 0;
                Console.Clear();
                Console.WriteLine("===== Delivery Management =====");
                DisplayEnum(typeof(DeliveryManagement));
                Console.WriteLine("Please select an option");

                Prompt = "";
                try
                {
                    Option_Delivery = IntTryParse(Prompt, InputRange => InputRange >= 1 && InputRange <= 6, "Value entered must between 1 and 6");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadLine();
                    break;
                }

                switch (Option_Delivery)
                {
                    case 1://Add_Delivery
                        Console.Clear();
                        Console.WriteLine("===== Add Delivery =====");
                        Prompt = "Delivery Preset: \n 1. Default \n 2. Custom";

                        try
                        {
                            Option_Delivery_Sub = IntTryParse(Prompt, InputRange => InputRange == 1 || InputRange == 2, "Value entered must be 1 or 2");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ReadLine();
                            break;
                        }

                        if (Option_Delivery_Sub == 1)
                        {
                            Console.Clear();
                            DefaultDeliveryManager.CreateOrder();
                            Console.ReadLine();
                        }
                        else if (Option_Delivery_Sub == 2)
                        {
                            Console.Clear();
                            CustomDeliveryManager.CreateOrder();
                            Console.ReadLine();
                        }

                        break;
                    case 2: //Manage_Vehicle_Assignment
                        Console.Clear();
                        Console.WriteLine("===== Manage Vehicle Assignment =====");
                        Prompt = "Vehicle Assignment: \n 1. Assign Vehicle to Order \n 2. Unassign Vehicle from Order";
                        
                        try
                        {
                            Option_Delivery_Sub = IntTryParse(Prompt, InputRange => InputRange == 1 || InputRange == 2,"Value entered must be 1 or 2");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ReadLine();
                            break;
                        }

                        if (Option_Delivery_Sub == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("===== Assign Vehicle to Order =====");
                            Console.WriteLine("Please enter the Order number");
                            OrderNumber = Console.ReadLine();
                            Console.WriteLine("Please enter the vehicles license plate");
                            string NumberPlate = Console.ReadLine();
                            Delivery.AssignVehicleToOrder(OrderNumber, NumberPlate);
                        }
                        else if (Option_Delivery_Sub == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("===== Unassign Vehicle to Order =====");
                            Console.WriteLine("Please enter the Order number");
                            OrderNumber = Console.ReadLine();
                            Console.WriteLine("Please enter the vehicles license plate");
                            string NumberPlate = Console.ReadLine();
                            //Delivery.UnAssignVehicleFromOrder(OrderNumber,NumberPlate); - TODO
                        }

                        Console.ReadLine();
                        break;
                    case 3: //Manage_Driver_Assignment
                        Console.Clear();
                        Console.WriteLine("===== Assign Driver to Order =====");
                        Prompt = "Driver Assignment: \n 1. Assign Driver to Order \n 2. Unassign Driver from Order";

                        try
                        {
                            Option_Delivery_Sub = IntTryParse(Prompt, InputRange => InputRange == 1 || InputRange == 2, "Value entered must be 1 or 2");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ReadLine();
                            break;
                        }

                        if (Option_Delivery_Sub == 1)
                        {
                            Console.Clear();
                            Console.WriteLine("===== Assign Driver to Order =====");
                            Console.WriteLine("Please enter the Order number");
                            OrderNumber = Console.ReadLine();
                           
                            Prompt = "Please enter the drivers EmployeeNumber";
                            int EmployeeNumber;
                            try
                            {
                                EmployeeNumber = IntTryParse(Prompt);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.ReadLine();
                                break;
                            }

                            Delivery.AssignDriverToOrder(OrderNumber, EmployeeNumber);
                        }
                        else if (Option_Delivery_Sub == 2)
                        {
                            Console.Clear();
                            Console.WriteLine("===== Unassign Vehicle to Order =====");
                            Console.WriteLine("Please enter the Order number");
                            OrderNumber = Console.ReadLine();

                            Prompt = "Please enter the drivers EmployeeNumber";
                            int EmployeeNumber;
                            try
                            {
                                EmployeeNumber = IntTryParse(Prompt);
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine($"Error: {ex.Message}");
                                Console.ReadLine();
                                break;
                            }
                            //Delivery.UnassignDriverFromOrder(OrderNumber, EmployeeNumber); - TODO
                        }

                        Console.ReadLine();
                        break;
                    case 4://View_Deliveries
                        Console.Clear();
                        Delivery.ViewAllDeliveries();
                        Console.ReadLine();
                        break;
                    case 5://Search_Deliveries
                        Console.Clear();
                        Console.WriteLine("Please enter the Order number");
                        OrderNumber = Console.ReadLine();
                        Delivery Result = Delivery.SearchDeliveries(OrderNumber);
                        Result.GetDetails();
                        Console.ReadLine();
                        break;
                    case 6://back
                        back = true;
                        break;
                    default:
                        Console.WriteLine("Invalid Option, please select an number between 1 and 6");
                        break;
                }
            } while (back != true);
        }
        
        public static void Vehicle_Management()
        {
            Vehicles VehicleManager = new Vehicles();
            Truck truck = new Truck();
            bool back = false;

            do
            {
                int Option_Vehicle;
                string Prompt;
                Console.Clear();
                Console.WriteLine("===== Vehicle Management =====");
                DisplayEnum(typeof(VehicleManagement));
                Console.WriteLine("Please select an option");

                Prompt = "";
                try
                {
                    Option_Vehicle = IntTryParse(Prompt, InputRange => InputRange >= 1 && InputRange <= 8, "Value entered must between 1 and 8");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadLine();
                    break;
                }

                switch (Option_Vehicle)
                {

                    case 1://Add_Vehicle
                        Console.Clear();

                        truck.GetVehicleInfo();
                        Console.ReadLine();
                        break;
                    case 2://Remove_Vehicle
                        Console.Clear();
                        Console.Write("Enter a vehicle license plate: ");
                        VehicleManager.RemoveVehicle(Console.ReadLine());
                        Console.ReadLine();
                        break;
                    case 3://edit vehicle
                        Console.Clear();
                        Console.WriteLine("Enter shit: ");
                        VehicleManager.EditVehicle(Console.ReadLine());
                        Console.ReadLine();
                        break;
                    case 4://ViewAllVehicles
                        Console.Clear();
                        VehicleManager.ViewAllVehicles();
                        Console.ReadLine();
                        break;
                    case 5://View_Available_Vehicles
                        Console.Clear();
                        VehicleManager.ViewAvailable();
                        Console.ReadLine();
                        break;
                    case 6://View_Vehicles_under_maintenance
                        Console.Clear();
                        VehicleManager.ViewMaintanence();
                        Console.ReadLine();
                        break;
                    case 7://Search_Vehicle
                        Console.Clear();
                        Console.WriteLine("===== Searching Vehicles =====");
                        Console.Write("Enter the number plate of the vehicle to search: ");
                        string NumberPlate = Console.ReadLine();
                        Vehicles.SearchVehicle(NumberPlate);
                        Console.ReadLine();
                        break;
                    case 8://back
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
            OperationLogs logging = new OperationLogs();
            Drivers driverManager = new Drivers(logging);
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
                        Console.WriteLine("Driver added succesfully");
                        Console.ReadLine();
                        break;
                    case 2://Edit_Driver
                        Console.Clear();
                        Console.WriteLine("===== Editing Drivers =====");
                        driverManager.EditDriver();
                        Console.ReadLine();
                        break;
                    case 3://View all Drivers
                        Console.Clear();
                        Drivers.ViewAllDrivers();
                        Console.ReadLine();
                        break;
                    case 4://View_Driver_Availability
                        Console.Clear();
                        Console.WriteLine("===== View Available Drivers =====");
                        Console.WriteLine("Available Drivers:");
                        Drivers.ViewDriverAvailability();
                        Console.ReadLine();
                        break;
                    case 5://Search_Driver
                        Console.Clear();
                        Console.WriteLine("===== Search Driver =====");
                        Console.Write("Enter Employee Number of the driver to search: ");
                        int SearchEmployeeNo = int.Parse(Console.ReadLine());

                        try
                        {
                            Drivers searchedDriver = Drivers.SearchDriver(SearchEmployeeNo);
                            Console.WriteLine($"Driver {searchedDriver.Name} {searchedDriver.Surname} is available for work.");
                        }
                        catch (DriverNotFoundException ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                        }

                        Console.ReadLine();
                        break;
                    case 6://back
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

        public static int IntTryParse(string PromptMessage)
        {
            bool Validated = false;

            while (Validated==false)
            {
                Console.WriteLine(PromptMessage);
                Validated = int.TryParse(Console.ReadLine(), out int output);

                if (Validated)
                {
                    return output;
                }
                else
                {
                    throw new InvalidTypeException("The value entered was not an integer");
                }
            }

            return 0; //Should never get here
        }

        //Input type is int. Output is bool for the lambda function. If bool is true, returns the int that was validated.
        public static int IntTryParse(string promptMessage, Func<int, bool> ExtraValidation,string ValidationErrorMessage)
        {
            int result = IntTryParse(promptMessage); // Call the original method

            if (ExtraValidation(result))
            {
                return result;
            }
            else
            {
                throw new FailedValidationException($"The input value failed the extra validation criteria of IntTryParse. Reason being: {ValidationErrorMessage}");
            }
        }

        //TODO - DoubleTryParse. BoolTryParse

        private static void ViewLogs(OperationLogs logging)
        {
            Console.Clear();
            Console.WriteLine("===== Operation Logs =====");

            List<string> logs = logging.GetLogs();

            if (logs.Count == 0)
            {
                Console.WriteLine("No logs available.");
            }
            else
            {
                foreach (var log in logs)
                {
                    Console.WriteLine(log);
                }
            }

            Console.ReadLine();
        }
    }
}
