using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace ConsoleApp1.Classes
{
    internal class DefaultDeliveryTask : DeliveryTask
    {

        public string CustomerCode { get; set; }

        public DefaultDeliveryTask() { }
        public DefaultDeliveryTask(string orderNumber, string date, string day, string time, string name, string telephone, string cellphone, string email, string address, string product, string amount, string paymentMethod, string notes, string customerCode) : base(orderNumber, date, day, time, name, telephone, cellphone, email,address, product, amount, paymentMethod, notes)
        {
            CustomerCode = customerCode;
            this.OrderCreated += OnCreateOrder;
            PublishOrderCreated(this);
        }

        public override void DisplayDetails()
        {
            base.DisplayDetails();
            Console.WriteLine($"CustomerCode: {CustomerCode}");
        }

        public delegate void OrderCreatedDel(DefaultDeliveryTask deliveryTask);
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
            Console.WriteLine("Please enter the Customer Number");
            string newCustomerCode = Console.ReadLine();

            DefaultDeliveryTask deliveryTask = new DefaultDeliveryTask(newOrderNumber, newDate, newDay, newTime, newName, newTelephone, newCellphone, newEmail, newAddress, newProduct, newAmount, newPaymentMethod, newNotes, newCustomerCode);
            Delivery newDelivery = new Delivery(deliveryTask);
            Delivery.DeliveryList.Add(newDelivery);
            // Call the publisher
            PublishOrderCreated(deliveryTask);
        }

        private void PublishOrderCreated(DefaultDeliveryTask deliveryTask)
        {
            // Publisher
            // Emit Event
            OrderCreated?.Invoke(deliveryTask);
        }

        public void OnCreateOrder(DefaultDeliveryTask deliveryTask)
        {
            // Subscriber
            Console.Clear();
            Console.WriteLine($"An order was created with the following details:");
            deliveryTask.DisplayDetails();
        }

    }
}
