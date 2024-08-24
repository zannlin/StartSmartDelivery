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
        public bool Availability { get; set; }

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

        public Drivers(string name, string surname, int employeeNo, bool availability)
        {
            _Name = name;
            _Surname = surname;
            _EmployeeNo = employeeNo;
            _LicenseTypes = new List<string>();
            Availability = availability;
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
           
            Console.WriteLine();
            Console.Write("Enter the Driver's Name: ");
            string name = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Enter Driver's Surname: ");
            string surname = Console.ReadLine();

            Console.WriteLine();
            Console.Write("Enter Driver's Employee Number: ");
            int employeeNo = int.Parse(Console.ReadLine());
            
            Console.WriteLine();
            Console.Write("Is the Driver Available? (true/false): ");
            bool availability = bool.Parse(Console.ReadLine());

            Drivers driver = new Drivers(name, surname, employeeNo, availability);

            while (true)
            {
                Console.WriteLine();
                Console.Write("Enter the license type (Code 8, Code 10, Code 11, Code 14) or type 'done' to finish: ");
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
            Console.WriteLine($"Editing Driver {Name} {Surname}");

            Console.Write("New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) Name = newName;
            Console.WriteLine();

            Console.Write("New Surname (leave blank to keep current): ");
            string newSurname = Console.ReadLine();
            if (!string.IsNullOrEmpty(newSurname)) Surname = newSurname;
            Console.WriteLine();

            //no employeeNo edit because it is constant

            Console.WriteLine("Current License Types: " + string.Join(", ", LicenseTypes));
            Console.WriteLine("Add or remove license types? (add/remove/none): ");
            string choice = Console.ReadLine().ToLower();

            if (choice == "add")
            {
                Console.Write("Enter License Type to add: ");
                string licenseType = Console.ReadLine();
                AddLicenseType(licenseType);
            }
            else if (choice == "remove")
            {
                Console.Write("Enter License Type to remove: ");
                string licenseType = Console.ReadLine();
                if (LicenseTypes.Contains(licenseType))
                {
                    LicenseTypes.Remove(licenseType);
                    Console.WriteLine($"License Type '{licenseType}' removed from driver {Name} {Surname}.");
                }
                else
                {
                    Console.WriteLine($"Driver {Name} {Surname} does not have '{licenseType}'");
                }

                Console.WriteLine($"Driver {Name} {Surname} updated.");
            }
        }

        public void ViewDriverAvailability()
        {
            Console.WriteLine($"Driver {Name} {Surname} is available for work.");
        }

        public static Drivers SearchDriver(List<Drivers> driverList, int employeeNo)
        {
            foreach (var driver in driverList)
            {
                if (driver.EmployeeNo == employeeNo)
                {
                    Console.WriteLine($"Found Driver: {driver.Name} {driver.Surname}, Employee No: {driver.EmployeeNo}");
                    Console.WriteLine("License Types: " + string.Join(", ", driver.LicenseTypes));
                    return driver;
                }
            }
            Console.WriteLine($"Driver with Employee No '{employeeNo}' not found.");
            return null;
        }

        public override string ToString()
        {
            string licenseTypes = string.Join(", ", _LicenseTypes);
            return $"Employee No: {_EmployeeNo}, Name: {_Name} {_Surname}, License Types: {licenseTypes}, Available: {Availability}";
        }
    }
}
