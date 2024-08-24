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

        public void GetVehicleInfo()
        {
            bool correct = false;
            while (!correct)
            {
                Truck truck = new Truck();
                

                Console.WriteLine("==== Enter Car Details ====\n");
                Console.Write("Enter vehicle make: ");
                Make = Console.ReadLine();
                Console.Write("Enter vehicle model: ");
                Model = Console.ReadLine();
                Console.Write("Enter vehicle year: ");
                Year = int.Parse(Console.ReadLine());
                Console.Write("Enter vehicle numberplate: ");
                NumberPlate = Console.ReadLine();
                Console.Write("Enter vehicle availability(Available, Unavailable, Under Maintenance): ");
                Availability = Console.ReadLine();

                Vehicles vehicles = new Vehicles(Make, Model, Year, NumberPlate, Availability);
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
            if (!NotUnique)
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

    }
}
