using ConsoleApp1.Interfaces;
using ConsoleApp1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Vehicles : IVehicles
    {
         private static List<Vehicles> _VehicleList = new List<Vehicles>();
         string _Make;
         string _Model;
         int _Year;
         string _NumberPlate;
         string _Status;
         string _Availability;

        public Vehicles() { }
        public Vehicles(string Make, string Model, int Year, string NumberPlate, string Status,string Availability)
        {
            _Make = Make;
            _Model = Model;
            _Year = Year;
            _NumberPlate = NumberPlate;
            _Status = Status;
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
        public string Status
        {
            get { return _Status; }
            set { _Status = value; }
        }
        public string Availability
        {
            get { return _Availability; }
            set { _Availability = value; }
        }

        public void AddVehicle(Vehicles vehicle)
        {
            _VehicleList.Add(vehicle);
            Console.WriteLine($"{vehicle.Make} {vehicle.Model} with the numberplate {vehicle.NumberPlate} added successfully.");
        }
        public void RemoveVehicle(string NumberPlate)
        {
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
    }
}
