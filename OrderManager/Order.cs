using System;
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
            Price = price;
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
            return new Order(arr[0], arr[1], Double.Parse(arr[2]), arr[3], arr[4]);
        }



    }
}
