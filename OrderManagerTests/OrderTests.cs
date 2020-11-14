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
            string item = "picture frMethod()]ame";
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



        //[TestMethod()]
        //public void CreateOrderTest()
        //{
        //    Assert.Fail();
        //}

        //[TestMethod()]
        //public void DaysUntilArrive()
        //{
        //}

        //[TestMethod()]
        //public void Arrived()
        //{
        //}

        //[TestMethod()]
        //public void Cancelled()
        //{
        //}

        //[TestMethod()]
        //public void SortArrivingFirst()
        //{
        //}
    }
}