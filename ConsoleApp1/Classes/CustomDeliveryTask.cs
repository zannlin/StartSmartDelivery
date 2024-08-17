using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class CustomDeliveryTask : DeliveryTask
    {
        public Dictionary<string, string> CustomFields { get; set; }

        public CustomDeliveryTask(
       string orderNumber,
       string date,
       string day,
       string time,
       string name,
       string telephone,
       string cellphone,
       string email,
       string address,
       string product,
       string amount,
       string paymentMethod,
       string notes
   ) : base(orderNumber, date, day, time, name, telephone, cellphone, email,address, product, amount, paymentMethod, notes)
        {
            CustomFields = new Dictionary<string, string>();
        }

        public void AddCustomField(string fieldName, string fieldValue)
        {
            CustomFields[fieldName] = fieldValue;
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();

            foreach (var field in CustomFields)
            {
                Console.WriteLine($"{field.Key}: {field.Value}");
            }
        }
    }
}
