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
    }
}
