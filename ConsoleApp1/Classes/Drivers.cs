using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Drivers
    {
        string _Name;
        string _Surname;
        int _EmployeeNo; //May need to change. Currently here as the "unique identifier"
        private List<string> _LicenseTypes;

        string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        int EmployeeNo
        {
            get { return _EmployeeNo; }
            set { _EmployeeNo = value; }
        }

        public List<string> LicenseTypes
        {
            get { return _LicenseTypes; }
        }

        public Drivers(string name, string surname, int employeeNo)
        {
            _Name = name;
            _Surname = surname;
            _EmployeeNo = employeeNo;
            _LicenseTypes = new List<string>();
        }

        private bool IsValidLiscenseType(string licenseType)
        {
            List<string> validLicenseTypes = new List<string> { "Code 8", "Code 10", "Code 11", "Code 14" };
            return validLicenseTypes.Contains(licenseType);
        }

        public void AddLicenseType(string licenseType)
        {
            if (IsValidLiscenseType(licenseType))
            {
                if (!_LicenseTypes.Contains(licenseType))
                {
                    _LicenseTypes.Add(licenseType);
                    Console.WriteLine($"License Type '{licenseType}' added to driver {Name} {Surname}.");
                }
                else
                {
                    Console.WriteLine($"Driver {Name} {Surname} already has '{licenseType}'");
                }
            }
            else
            {
                Console.WriteLine($"'{licenseType}' is not a valid license type.");
            }
        }

        public static Drivers AddDrivers()
        {
            Console.WriteLine("===== Adding Drivers =====");
            Console.Write("Enter the Driver's Name: ");
            string name = Console.ReadLine();

            Console.Write("Enter Driver's Surname: ");
            string surname = Console.ReadLine();

            Console.Write("Enter Driver's Employee Number: ");
            int employeeNo = int.Parse(Console.ReadLine());

            Drivers driver = new Drivers(name, surname, employeeNo);

            while (true)
            {
                Console.Write("Enter the license type (Code 8, Code 10, Code 11, Code 14) or type 'done' to finish.");
                string licenseType = Console.ReadLine();

                if (licenseType.ToLower() == "done")
                {
                    break;
                }
                driver.AddLicenseType(licenseType);
            }
            return driver;
        }

        public void EditDriver()
        {
            Console.WriteLine("===== Editing Drivers =====");
            Console.WriteLine($"Editing Driver {Name} {Surname}");

            Console.Write("New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) Name = newName;
            Console.WriteLine();

            Console.Write("New Surname (leave blank to keep current): ");
            string newSurname = Console.ReadLine();
            if (!string.IsNullOrEmpty(newSurname)) Surname = newSurname;
            Console.WriteLine();

            //add employeeNo edit later zzzzzzZZZZZZZ

            Console.WriteLine("Add License Types (enter 'done' to finish: ");

            while (true)
            {
                Console.Write("Enter License Type: ");
                string licenseType = Console.ReadLine();

                if (licenseType.ToLower() == "done")
                    break;

                AddLicenseType(licenseType);
            }

            Console.WriteLine($"Driver {Name} {Surname} updated.");

        }

        public void ViewDriverAvailability()
        {
            Console.WriteLine("===== View Available Drivers =====");
        }

        //public static SearchDriver()
        //{

        //}
    }
}
