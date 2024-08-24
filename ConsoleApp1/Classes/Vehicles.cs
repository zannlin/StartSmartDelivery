using ConsoleApp1.Interfaces;
using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;
using System.Runtime.CompilerServices;

namespace ConsoleApp1.Classes
{
    internal class Vehicles : IVehicles
    {
        static readonly string[] AllowedValues = { "Available", "Unavailable", "Under Maintenance" };

        private static List<Vehicles> _VehicleList = new List<Vehicles>();

        string _Make;
        string _Model;
        int _Year;
        string _NumberPlate;
        string _Availability;

        public Vehicles() { }
        public Vehicles(string Make, string Model, int Year, string NumberPlate)
        {
            _Make = Make;
            _Model = Model;
            _Year = Year;
            _NumberPlate = NumberPlate;
            Availability = "Available";

            VehicleList.Add(this);
        }

        public static List<Vehicles> VehicleList
        {
            get { return _VehicleList; }
            set { _VehicleList = value; }
        }
        public string Make
        {
            get { return _Make; }
            set { _Make = value; }
        }
        public string Model
        {
            get { return _Model; }
            set { _Model = value; }
        }
        public int Year
        {
            get { return _Year; }
            set { _Year = value; }
        }
        public string NumberPlate
        {
            get { return _NumberPlate; }
            set { _NumberPlate = value; }
        }
        public string Availability
        {
            get { return _Availability; }
            set
            {
                if (AllowedValues.Contains(value))
                {
                    _Availability = value;
                }
                else
                {
                    throw new InvalidAvailabilityException("Invalid Availability Type Entered. Enter 'Available', 'Unavailable' or 'Under Maintenance'");
                }
            }
        }

        public virtual bool AddVehicle(Vehicles vehicle)
        {
            Console.WriteLine("===== Adding Vehicles =====");
            bool NotUnique = false;
            foreach (Vehicles veci in VehicleList)
            {
                if (veci.NumberPlate == vehicle.NumberPlate)
                {
                    NotUnique = true;
                }
            }
            if (!NotUnique)
            {
                return false;
            }
            else
            {
                Console.WriteLine($"{vehicle.Make} {vehicle.Model} with the numberplate {vehicle.NumberPlate} added successfully.");
                return true;
            }
        }
        public void RemoveVehicle(string NumberPlate)
        {
            Console.WriteLine("===== Removing Vehicle =====");
            lock (_VehicleList) ; // Lock the list to prevent other threads from accessing it thus preventing concurrency errors. 
            Vehicles VehicleToRemove = _VehicleList.Find(v => v.NumberPlate == NumberPlate);
            if (VehicleToRemove != null)
            {
                try
                {
                    _VehicleList.Remove(VehicleToRemove);
                    Console.WriteLine($"Vehicle with the number plate '{NumberPlate}' was removed.");
                }
                catch (VehicleNotFoundException Exception)
                {
                    Console.WriteLine($"Error: {Exception.Message}");
                }
            }
        }
        public void ViewAllVehicles()
        {
            if (VehicleList.Count == 0)
            {
                Console.WriteLine("No available vehicles at the moment.");
            }
            else
            {
                Console.WriteLine("===== List of Vehicles =====");
                foreach (var Vehicle in VehicleList)
                {
                    Vehicle.DisplayDetails();
                }
            }
        }
        public void ViewAvailable()
        {
            var availableVehicles = VehicleList.Where(v => v.Availability == "Available").ToList();

            if (availableVehicles.Count == 0)
            {
                Console.WriteLine("No available vehicles at the moment.");
            }
            else
            {
                Console.WriteLine("===== List of Available Vehicles =====");
                foreach (var Vehicle in VehicleList)
                {
                    Vehicle.DisplayDetails();
                }
            }
        }
        public void ViewMaintanence()

        {
            Console.WriteLine("===== Vehicles under Maintanence =====");
            var availableVehicles = VehicleList.Where(v => v.Availability == "Maintanence").ToList();

            if (availableVehicles.Count == 0)
            {
                Console.WriteLine("No available vehicles at the moment.");
            }
            else
            {
                Console.WriteLine("===== List of Vehicles under Maintanence =====");
                foreach (var Vehicle in VehicleList)
                {
                    Vehicle.DisplayDetails();
                }
            }

        }
        public static void SearchVehicle(string NumberPlate)
        {
            Vehicles FoundVehicle = VehicleList.Find(v => v.NumberPlate.Equals(NumberPlate, StringComparison.OrdinalIgnoreCase));

            if (FoundVehicle != null)
            {
                Console.WriteLine("Vehicle found:");
                FoundVehicle.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Vehicle not found.");
            }
        }

        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Make: {Make}, Model: {Model}, Year: {Year}, Number Plate: {NumberPlate}, Availability: {Availability}");
        }

        public virtual void EditVehicle(string numberplate)
        {
            List<string> requiredOption = new List<string>();
            requiredOption.Add("Make");
            requiredOption.Add("Model"); 
            requiredOption.Add("Year");
            requiredOption.Add("NumberPlate");
            requiredOption.Add("Availability");

            Vehicles foundVehicle = VehicleList.Find(v => v.NumberPlate.Equals(NumberPlate, StringComparison.OrdinalIgnoreCase));

            if (foundVehicle != null)
            {
                SearchVehicle(numberplate);
                Console.Write("Enter the value you would like to change: ");
                string change = Console.ReadLine().ToLower();

                int option = 0;
                bool IsCorrect = false;
                while (IsCorrect)
                {
                    foreach (string item in requiredOption)
                    {
                        Console.WriteLine($"Press {requiredOption.IndexOf(item)} to edit {item}");
                    }
                    IsCorrect = int.TryParse(Console.ReadLine(), out option);
                    if (!IsCorrect)
                    {
                        Console.WriteLine("Input is invalid, please try again");
                    }
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
                        Console.Write("Enter vehicle year: ");
                        foundVehicle.Year = int.Parse(Console.ReadLine());
                        break;
                    case 3:
                        Console.Write("Enter vehicle numberplate: ");
                        foundVehicle.NumberPlate = Console.ReadLine();
                        break;
                    case 4:
                        Console.Write("Enter vehicle availability(Available, Unavailable, Under Maintenance): ");
                        foundVehicle.Availability = Console.ReadLine();
                        break;
                    default:
                        Console.WriteLine("Invalid Option entered");
                        break;
                }

            }
            else
            {
                SearchVehicle(numberplate);
            }
        }
    }
}
