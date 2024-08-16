using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Interfaces
{
    internal interface IVehicles
    {
        string Make { get; set; }
        string Model { get; set; }
        int Year { get; set; }
       // double LoadCapacity { get; set; }
        string NumberPlate { get; set; }
        string Status { get; set; }
        string Availability { get; set; }
    }
}