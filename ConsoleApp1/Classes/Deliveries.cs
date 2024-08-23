using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1.Classes
{
    internal class Deliveries
    {
        public List<DeliveryTask> Tasks { get; set; }

        public Deliveries()
        {
            Tasks = new List<DeliveryTask>();
        }

        public void AddTask(DeliveryTask task)
        {
            Tasks.Add(task);
        }

        public void DisplayAllTasks()
        {
            foreach (var task in Tasks)
            {
                task.DisplayDetails();
                Console.WriteLine();
            }
        }
    }
}
