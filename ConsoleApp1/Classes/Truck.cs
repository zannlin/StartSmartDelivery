using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Truck : Vehicles
    {
        private double _LoadCapacity;

        public Truck() { }
        public Truck(string Make, string Model, int Year, string NumberPlate, double LoadCapacity) : base(Make, Model, Year, NumberPlate)
        {
            _LoadCapacity = LoadCapacity;
        }

        public double LoadCapacity
        {
            get { return _LoadCapacity; }
            set { _LoadCapacity = value; }
        }

        public override void GetVehicleInfo()
        {
            bool correct = false;
            while (!correct)
            {
                Truck truck = new Truck();
                Vehicles vehicles = new Vehicles();

                Console.WriteLine("==== Enter Car Details ====\n");
                Console.Write("Enter vehicle make: ");
                vehicles.Make = Console.ReadLine();
                Console.Write("Enter vehicle model: ");
                vehicles.Model = Console.ReadLine();
                Console.Write("Enter vehicle year: ");
                vehicles.Year = int.Parse(Console.ReadLine());
                Console.Write("Enter vehicle numberplate: ");
                vehicles.NumberPlate = Console.ReadLine();
                Console.Write("Enter vehicle availability(Available, Unavailable, Under Maintenance): ");
                vehicles.Availability = Console.ReadLine();
                
                correct = truck.AddVehicle(vehicles);
            }
            
        }

        public override bool AddVehicle(Vehicles vehicle) //returns a bool to determine if the numberplate is unique or not
        {
            bool NotUnique = false;
            foreach (Vehicles veci in VehicleList)
            {
                if (veci.NumberPlate == vehicle.NumberPlate)
                {
                    NotUnique = true;
                }
            }
            if (NotUnique == false)
            {
                bool validated = false;
                double LoadCap = 0;
                while (validated == false)
                {
                    Console.Write("Enter the load capacity: ");
                    validated = double.TryParse(Console.ReadLine(), out LoadCap);
                    if (!validated)
                    {
                        Console.WriteLine("\nInput invalid, please try again\n");
                    }
                }

                Truck truck = new Truck(vehicle.Make, vehicle.Model, vehicle.Year, vehicle.NumberPlate, LoadCap);
                VehicleList.Add(truck);
                Console.WriteLine($"\n{vehicle.Make} {vehicle.Model} with number plate {vehicle.NumberPlate} added successfully!");
                return true;
            }
            else
            {
                Console.WriteLine("\nThe numberplate entered is not unique" +
                    $"{vehicle.Make} {vehicle.Model} with number plate {vehicle.NumberPlate} not added\n");
                return false;
            }
        }

        public override void DisplayDetails()
        {
            Console.WriteLine($"Make: {Make}, Model: {Model}, Year: {Year}, Number Plate: {NumberPlate}, Availability: {Availability}, Load Capacity: {LoadCapacity}");
        }

        public override void EditVehicle(string numberplate)
        {
            List<string> requiredOption = new List<string>
            {
                "Make",
                "Model",
                "Year",
                "NumberPlate",
                "Availability",
                "LoadCapacity"
            };

            Truck foundVehicle = new Truck();

            foreach (Vehicles vehicle in VehicleList)
            {
                if (vehicle.NumberPlate == numberplate)
                {
                    foundVehicle = (Truck)vehicle;
                }
            }

            if (foundVehicle.Make != null)
            {
                foundVehicle.DisplayDetails();

                int option = 0;
                foreach (string item in requiredOption)
                {
                    Console.WriteLine($"Press {requiredOption.IndexOf(item)} to edit {item}");
                }
                try
                {
                    option = Menu.IntTryParse("Enter the value you would like to change: ");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                    Console.ReadLine();

                }

                switch (option)
                {
                    case 0:
                        Console.Write("Enter vehicle make: ");
                        foundVehicle.Make = Console.ReadLine();
                        break;
                    case 1:
                        Console.Write("Enter vehicle model: ");
                        foundVehicle.Model = Console.ReadLine();
                        break;
                    case 2:
                        try
                        {
                            foundVehicle.Year = Menu.IntTryParse("Enter vehicle year: ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ReadLine();

                        }
                        break;
                    case 3:
                        Console.Write("Enter vehicle numberplate: ");
                        foundVehicle.NumberPlate = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter vehicle availability(Available, Unavailable, Under Maintenance): ");
                        foundVehicle.Availability = Console.ReadLine();
                        break;
                    case 5:
                        try
                        {
                            foundVehicle.LoadCapacity = Menu.DoubleTryParse("Enter vehicle load capacity: ");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Error: {ex.Message}");
                            Console.ReadLine();

                        }
                        break;
                    default:
                        Console.WriteLine("Invalid Option entered");
                        break;
                }

                Console.WriteLine("\nVehicle edited successfully!");

            }
            else
            {
                SearchVehicle(numberplate);
            }
        }

    }
}
