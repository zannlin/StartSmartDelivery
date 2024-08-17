using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class DefaultDeliveryTask : DeliveryTask
    {
        public string CustomerCode { get; set; }
        public DefaultDeliveryTask(string orderNumber, string date, string day, string time, string name, string telephone, string cellphone, string email, string address, string product, string amount, string paymentMethod, string notes, string customerCode) : base(orderNumber, date, day, time, name, telephone, cellphone, email,address, product, amount, paymentMethod, notes)
        {
            CustomerCode = customerCode;
        }


        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"CustomerCode: {CustomerCode}");
        }
    }
}
