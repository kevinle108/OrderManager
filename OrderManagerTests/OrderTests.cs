using OrderManager;
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

            var order = new Order(item, store, price, orderDate, arrivalDate);

            Assert.AreEqual(item.ToUpper(), order.Item);
            Assert.AreEqual(store.ToUpper(), order.Store);
            Assert.AreEqual(price, order.Price);
            Assert.AreEqual(DateTime.Parse(orderDate), order.OrderDate);
            Assert.AreEqual(DateTime.Parse(arrivalDate), order.ArrivalDate);
        }

        [TestMethod()]
        public void OrderTest1()
        {
            string item = "book";
            string store = "Amazon";
            double price = 8.75;
            string orderDate = "10/15";
            string arrivalDate = "10/18";

            var order = new Order(item, store, price, orderDate, arrivalDate);

            Assert.AreEqual(item.ToUpper(), order.Item);
            Assert.AreEqual(store.ToUpper(), order.Store);
            Assert.AreEqual(price, order.Price);
            Assert.AreEqual(DateTime.Parse(orderDate), order.OrderDate);
            Assert.AreEqual(DateTime.Parse(arrivalDate), order.ArrivalDate);
        }

        [TestMethod()]
        public void OrderTest2()
        {
            string item = "picture frame";
            string store = "walgreens";
            double price = 3.99;
            string orderDate = "10/28";
            string arrivalDate = "10/30";

            var order = new Order(item, store, price, orderDate, arrivalDate);

            Assert.AreEqual(item.ToUpper(), order.Item);
            Assert.AreEqual(store.ToUpper(), order.Store);
            Assert.AreEqual(price, order.Price);
            Assert.AreEqual(DateTime.Parse(orderDate), order.OrderDate);
            Assert.AreEqual(DateTime.Parse(arrivalDate), order.ArrivalDate);
        }

        [TestMethod()]
        public void HasArrivedTest()
        {
            string item = "picture frame";
            string store = "walgreens";
            double price = 3.99;
            string orderDate = "10/28";
            string arrivalDate = "10/30";

            var order = new Order(item, store, price, orderDate, arrivalDate);
            var testResult = order.HasArrived();
            Assert.IsTrue(testResult);
            
        }

        [TestMethod()]
        public void HasArrivedTest1()
        {
            string item = "picture frame, walgreens, 3.99, 10/28, 10/30";
            Order order = Order.CreateOrder(item);
            order.ArrivalDate = DateTime.Today.AddDays(1); // change the arrival date to tomorrow
            var testResult = order.HasArrived();
            Assert.IsFalse(testResult);

        }

        [TestMethod()]
        public void ArrivalStatus()
        {
            string item = "picture frame, walgreens, 3.99, 10/28, 10/30";
            Order order = Order.CreateOrder(item);
            string expected = "Status: Recieved";
            Assert.AreEqual(order.ArrivalStatus(), expected);
        }

        [TestMethod()]
        public void ArrivalStatus1()
        {
            string item = "picture frame, walgreens, 3.99, 10/28, 10/30";
            Order order = Order.CreateOrder(item);
            order.ArrivalDate = DateTime.Today.AddDays(1); // change the arrival date to tomorrow
            string expected = $"Status: Arriving in {(order.ArrivalDate - DateTime.Now).Days} days";
            Assert.AreEqual(order.ArrivalStatus(), expected);
        }
    }
}