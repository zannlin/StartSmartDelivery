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
        public Vehicles(string Make, string Model, int Year, string NumberPlate, string Availability)
        {
            _Make = Make;
            _Model = Model;
            _Year = Year;
            _NumberPlate = NumberPlate;
            _Availability = Availability;
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
            lock (_VehicleList); // Lock the list to prevent other threads from accessing it thus preventing concurrency errors. 
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
                foreach (var vehicle in VehicleList)
                {
                    DisplayDetails();
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
                foreach (var vehicle in availableVehicles)
                {
                    DisplayDetails();
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
                foreach (var vehicle in availableVehicles)
                {
                    DisplayDetails();
                }
            }

        }
        public void SearchVehicle()
        {
            Console.WriteLine("===== Searching Vehicles =====");
            Console.Write("Enter the number plate of the vehicle to search: ");
            string numberPlate = Console.ReadLine();

            // Find the vehicle with the matching number plate
            Vehicles foundVehicle = VehicleList.Find(v => v.NumberPlate.Equals(numberPlate, StringComparison.OrdinalIgnoreCase));

            if (foundVehicle != null)
            {
                Console.WriteLine("Vehicle found:");
                DisplayDetails();
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
    }
}
