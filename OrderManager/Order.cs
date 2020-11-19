using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace OrderManager
{
    public class Order
    {
        public string Item { get; set; }
        public string Store { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ArrivalDate { get; set; }

        public Order(string item, string store, double price, string orderDate, string arrivalDate)
        {
            Item = item.ToUpper();
            Store = store.ToUpper();
            Price = Math.Round(price, 2, MidpointRounding.AwayFromZero);
            OrderDate = DateTime.Parse(orderDate);
            ArrivalDate = DateTime.Parse(arrivalDate);
        }

        public void Display()
        {
            Console.WriteLine();
            Console.WriteLine("--------------------------------------------------------");
            Console.WriteLine($" Item: {Item}");
            Console.WriteLine($" From: {Store}");
            Console.WriteLine($" Price: ${Price}");
            Console.WriteLine($" Ordered on: {OrderDate.ToLongDateString()}");
            Console.WriteLine($" Arriving by: {ArrivalDate.ToLongDateString()}");
            Console.WriteLine("--------------------------------------------------------"); ;
        }

        public static Order CreateOrder(string str)
        {
            string[] arr = str.Split(',');
            // trim excess spaces around each string
            return new Order(arr[0].Trim(), arr[1].Trim(), Double.Parse(arr[2].Trim()), arr[3].Trim(), arr[4].Trim());
        }

        public bool HasArrived()
        {
            return (ArrivalDate - DateTime.Now).Days < 0;
        }

        public string ArrivalStatus()
        {
            if (this.HasArrived())
            {
                return "Status: Received";
            } else
            {
                return $"Status: Arriving in {(ArrivalDate - DateTime.Now).Days} days";
            }
        }



    }
}
