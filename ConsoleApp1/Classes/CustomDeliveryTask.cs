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

        public CustomDeliveryTask() { }
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
            this.OrderCreated += OnCreateOrder;
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

        public delegate void OrderCreatedDel(CustomDeliveryTask deliveryTask);
        public event OrderCreatedDel OrderCreated;

        public override void CreateOrder()
        {
            //Publisher
            Console.WriteLine("Please enter the Order Number");
            string newOrderNumber = Console.ReadLine();
            Console.WriteLine("Please enter the Date");
            string newDate = Console.ReadLine();
            Console.WriteLine("Please enter the Day");
            string newDay = Console.ReadLine();
            Console.WriteLine("Please enter the Time");
            string newTime = Console.ReadLine();
            Console.WriteLine("Please enter the Name");
            string newName = Console.ReadLine();
            Console.WriteLine("Please enter the Telephone");
            string newTelephone = Console.ReadLine();
            Console.WriteLine("Please enter the Cellphone");
            string newCellphone = Console.ReadLine();
            Console.WriteLine("Please enter the Email");
            string newEmail = Console.ReadLine();
            Console.WriteLine("Please enter the Address");
            string newAddress = Console.ReadLine();
            Console.WriteLine("Please enter the Product");
            string newProduct = Console.ReadLine();
            Console.WriteLine("Please enter the Amount");
            string newAmount = Console.ReadLine();
            Console.WriteLine("Please enter the PaymentMethod");
            string newPaymentMethod = Console.ReadLine();
            Console.WriteLine("Please enter the Notes");
            string newNotes = Console.ReadLine();

            Console.WriteLine("How many custom fields do you want to add?");
            int numberOfFields = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfFields; i++)
            {
                Console.WriteLine("Please enter the name of the custom field");
                string fieldName = Console.ReadLine();
                Console.WriteLine("Please enter the value for the custom field");
                string fieldValue = Console.ReadLine();
                AddCustomField(fieldName, fieldValue);
            }

            CustomDeliveryTask deliveryTask = new CustomDeliveryTask(newOrderNumber, newDate, newDay, newTime, newName, newTelephone, newCellphone, newEmail, newAddress, newProduct, newAmount, newPaymentMethod, newNotes );
            DeliveryList.Add(deliveryTask);

            // Call the publisher
            PublishOrderCreated(deliveryTask);
        }

        private void PublishOrderCreated(CustomDeliveryTask deliveryTask)
        {
            // Publisher
            // Emit Event
            OrderCreated?.Invoke(deliveryTask);
        }

        public void OnCreateOrder(CustomDeliveryTask deliveryTask)
        {
            // Subscriber
            Console.WriteLine($"An order was created with the following details: \n" + deliveryTask);
        }
    }
}
