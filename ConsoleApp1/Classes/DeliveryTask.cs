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
        static List<DeliveryTask> _DeliveryTaskList = new List<DeliveryTask>();

        public static List<DeliveryTask> DeliveryTaskList
        {
            get { return _DeliveryTaskList; }
            set { _DeliveryTaskList = value; }
        }
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

        public DeliveryTask() { }
        public DeliveryTask(string orderNumber, string date, string day, string time, string name, string telephone, string cellphone, string email, string address, string product, string amount, string paymentMethod, string notes)
        {
            OrderNumber = orderNumber;
            Date = date;
            Day = day;
            Time = time;
            _FullnameOrCompany = name;
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
            Console.WriteLine($"Order Number: {OrderNumber}\n" +
                              $"Date: {Date}\n" +
                              $"Day: {Day}\n" +
                              $"Time: {Time}\n" +
                              $"Name: {_FullnameOrCompany}\n" +
                              $"Telephone: {Telephone}\n" +
                              $"Cellphone: {Cellphone}\n" +
                              $"Email: {Email}\n" +
                              $"Address: {Address}\n" +
                              $"Product: {Product}\n" +
                              $"Amount: R{Amount}\n" +
                              $"PaymentMethod: {PaymentMethod}\n" +
                              $"Notes: {Notes}");
        }

        public abstract void CreateOrder();
        public static void ViewAllDeliveryTasks()
        {
            if (DeliveryTaskList.Count == 0)
            {
                Console.WriteLine("No Delivery Tasks available.");
            }
            else
            {
                Console.WriteLine("===== List of Delivery Tasks =====");
                foreach (var delivery in DeliveryTaskList)
                {
                    delivery.DisplayDetails();
                    Console.WriteLine();
                }
            }
        }

        public static void SearchDelieveryTasks()
        {
            Console.WriteLine("===== Searching Delivery Tasks =====");
            Console.Write("Enter the Order Number of the Delivery Task to search: ");
            string OrderNumber = Console.ReadLine();

            // Find the vehicle with the matching number plate
            DeliveryTask FoundDelivery = DeliveryTaskList.Find(v => v.OrderNumber.Equals(OrderNumber, StringComparison.OrdinalIgnoreCase));

            if (FoundDelivery != null)
            {
                Console.WriteLine("Order found:");
                FoundDelivery.DisplayDetails();
            }
            else
            {
                Console.WriteLine("Order not found.");
            }
        }
    }


}
