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
    }
}
