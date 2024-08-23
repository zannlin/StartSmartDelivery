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
        public Truck(string Make, string Model, int Year, string NumberPlate, string Status, string Availability, double LoadCapacity):base(Make, Model, Year, NumberPlate, Status, Availability) { 
        _LoadCapacity = LoadCapacity;
        }

        public double LoadCapacity
        {
            get { return _LoadCapacity; }
            set { _LoadCapacity = value; }
        }


    }
}
