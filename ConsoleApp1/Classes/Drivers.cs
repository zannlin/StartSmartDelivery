using ConsoleApp1.Exceptions;
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
        private static List<Drivers> _DriverList = new List<Drivers>();

        private OperationLogs _OperationLogs;

        public Drivers(OperationLogs operationLogs)
        {
            _OperationLogs = operationLogs;
        }

        public static List<Drivers> DriverList
        {
            get { return _DriverList; }
            set { _DriverList = value; }
        }

        public string Name
        {
            get { return _Name; }
            set { _Name = value; }
        }
        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }
        public int EmployeeNo
        {
            get { return _EmployeeNo; }
            set { _EmployeeNo = value; }
        }

        public List<string> LicenseTypes
        {
            get { return _LicenseTypes; }
        }

        public Drivers(string name, string surname, int employeeNo, string licenseType)
        {
            _Name = name;
            _Surname = surname;
            _EmployeeNo = employeeNo;
            _LicenseTypes = new List<string>();
            Availability = true;

            // Validate and add the license type
            while (!IsValidLicenseType(licenseType))
            {
                Console.WriteLine("Invalid license type entered. Please enter a valid license type (Code 8, Code 10, Code 11, Code 14):");
                licenseType = Console.ReadLine();
            }
            _LicenseTypes.Add(licenseType);

            DriverList.Add(this);
        }

        private bool IsValidLicenseType(string licenseType)
        {
            List<string> validLicenseTypes = new List<string> { "Code 8", "Code 10", "Code 11", "Code 14" };
            return validLicenseTypes.Contains(licenseType);
        }

        public void AddLicenseType(string licenseType)
        {
            if (IsValidLicenseType(licenseType))
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
            Console.Write("Enter the Drivers license type. (Code 8, Code 10, Code 11, Code 14) ");
            string licenceType = Console.ReadLine();
            Drivers newDriver = new Drivers(name, surname, employeeNo, licenceType);

            return newDriver;
        }

        public void EditDriver()
        {
            Console.Write("Enter Employee Number of the driver to edit: ");
            int editEmployeeNo = int.Parse(Console.ReadLine());
            Drivers driverToEdit = SearchDriver(editEmployeeNo);

            if (driverToEdit == null)
            {
                Console.WriteLine("Driver not found.");
                return;
            }

            Console.WriteLine($"Editing Driver {driverToEdit.Name} {driverToEdit.Surname}");

            Console.Write("New Name (leave blank to keep current): ");
            string newName = Console.ReadLine();
            if (!string.IsNullOrEmpty(newName)) driverToEdit.Name = newName;
            Console.WriteLine();

            Console.Write("New Surname (leave blank to keep current): ");
            string newSurname = Console.ReadLine();
            if (!string.IsNullOrEmpty(newSurname)) driverToEdit.Surname = newSurname;
            Console.WriteLine();

            // Handle license types
            Console.WriteLine("Current License Types: " + string.Join(", ", driverToEdit.LicenseTypes));
            Console.WriteLine("Do you want to add or remove a license type? (add/remove/none): ");
            string licenseOption = Console.ReadLine().ToLower();

            if (licenseOption == "add")
            {
                Console.Write("Enter License Type to add: ");
                Console.Write("(Code 8, Code 10, Code 11, Code 14) ");
                string licenseTypeToAdd = Console.ReadLine();
                _OperationLogs.LogOperation($"Driver {driverToEdit.Name} added license type {licenseTypeToAdd}");
                driverToEdit.AddLicenseType(licenseTypeToAdd);
            }
            else if (licenseOption == "remove")
            {
                Console.Write("Enter License Type to remove: ");
                Console.Write("(Code 8, Code 10, Code 11, Code 14) ");
                string licenseTypeToRemove = Console.ReadLine();
                if (driverToEdit.LicenseTypes.Contains(licenseTypeToRemove))
                {
                    driverToEdit.LicenseTypes.Remove(licenseTypeToRemove);
                    _OperationLogs.LogOperation($"Driver {driverToEdit.Name} removed license type {licenseTypeToRemove}");
                    Console.WriteLine($"License Type '{licenseTypeToRemove}' removed from driver {driverToEdit.Name} {driverToEdit.Surname}.");
                }
                else
                {
                    Console.WriteLine($"Driver {driverToEdit.Name} {driverToEdit.Surname} does not have '{licenseTypeToRemove}'");
                }
            }

            // Log the edit
            _OperationLogs.LogOperation($"Edited driver {driverToEdit.Name} {driverToEdit.Surname} (Employee No: {driverToEdit.EmployeeNo}).");

            Console.WriteLine($"Driver {driverToEdit.Name} {driverToEdit.Surname} updated successfully.");
        }


        public static void ViewAllDrivers()
        {
            foreach (var driver in DriverList)
            {
                Console.WriteLine(driver.GetDetails());
            }
        }
        public static void ViewDriverAvailability()
        {
            foreach (var driver in DriverList)
            {
                if (driver.Availability)  // Only show available drivers
                {
                    Console.WriteLine(driver.GetDetails());
                }
            }
        }

        public static Drivers SearchDriver(int EmployeeNo)
        {
            Drivers FoundDriver = DriverList.Find(driver => driver.EmployeeNo == EmployeeNo);

            if (FoundDriver != null)
            {
                return FoundDriver;

            }
            else
            {
                throw new DriverNotFoundException("Driver not found");
            }
        }

        public string GetDetails()
        {
            string licenseTypes = string.Join(", ", _LicenseTypes);
            return $"Employee No: {_EmployeeNo}, Name: {_Name} {_Surname}, License Types: {licenseTypes}, Available: {Availability}";
        }
    }
}
