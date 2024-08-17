using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal abstract class DeliveryTask
    {
        public string OrderNumber { get; set; }

        public string Date { get; set; }
        public string Day { get; set; }
        public string Time { get; set; }

        string _FullnameOrCompany;

        //Fullname and Company name being created as public serves as Alternate names for the same Field
        public string Fullname
        {
            get { return _FullnameOrCompany; }
            set { _FullnameOrCompany = value; }
        }

        public string CompanyName
        {
            get { return _FullnameOrCompany; }
            set { _FullnameOrCompany = value; }
        }
        public string Telephone { get; set; }
        public string Cellphone { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Product { get; set; }
        public string Amount { get; set; }
        public string PaymentMethod { get; set; }
        public string Notes { get; set; }

        public DeliveryTask(string orderNumber,string date, string day, string time,string name, string telephone, string cellphone, string email,string address, string product, string amount, string paymentMethod, string notes)
        {
            OrderNumber = orderNumber;
            Date = date;
            Day = day;
            Time = time;
            _FullnameOrCompany= name;
            Telephone = telephone;
            Cellphone = cellphone;
            Email = email;
            Address = address;
            Product = product;
            Amount = amount;
            PaymentMethod = paymentMethod;
            Notes = notes;
        }
        public virtual void DisplayDetails()
        {
            Console.WriteLine($"Order Number: {OrderNumber}");
            Console.WriteLine($"Date: {Date}");
            Console.WriteLine($"Day: {Date}");
            Console.WriteLine($"Time: {Time}");
            Console.WriteLine($"Name: {_FullnameOrCompany}");
            Console.WriteLine($"Telephone: {Telephone}");
            Console.WriteLine($"Cellphone: {Cellphone}");
            Console.WriteLine($"Email: {Email}");
            Console.WriteLine($"Address: {Address}");
            Console.WriteLine($"Product: {Product}");
            Console.WriteLine($"Amount: R{Amount}");
            Console.WriteLine($"PaymentMethod: {PaymentMethod}");
            Console.WriteLine($"Notes: {Notes}");
        }
    }
}
