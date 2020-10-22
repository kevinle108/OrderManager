using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace OrderManager.Tests
{
    [TestClass()]
    public class OrderTests
    {
        [TestMethod()]
        public void OrderTest()
        {
            string item = "basketball";
            string store = "dick's sporting goods";
            double price = 15.99;
            string orderDate = "05/12";
            string arrivalDate = "05/25";

            var order = new Order(item,store,price,orderDate,arrivalDate);

            Assert.AreEqual(item.ToUpper(), order.Item);
            Assert.AreEqual(store.ToUpper(), order.Store);
            Assert.AreEqual(price, order.Price);
            Assert.AreEqual(DateTime.Parse(orderDate), order.OrderDate);
            Assert.AreEqual(DateTime.Parse(arrivalDate), order.ArrivalDate);
        }

        public void DaysUntilArrive() 
        { 
        }

        public void Arrived()
        {
        }

        public void Cancelled()
        {
        }

        public void SortArrivingFirst()
        {
        }
    }
}