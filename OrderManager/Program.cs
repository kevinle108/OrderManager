using System;
using System.IO;
using System.Collections.Generic;

namespace OrderManager
{
    class Program
    {
        

        static void Main(string[] args)
        {
            MainMenu();
            return;
            Console.WriteLine("Starting program...");
            string test0 = "mouse,amazon,12.50,10/16,10/19";
            string test1 = "water bottle,walmart,5.99,10/02,10/24";
            //Order testOrder = new Order("mouse","amazon",12.99,"10/16","10/19");
            //testOrder.Display();
            Order order0 = Order.CreateOrder(test0);
            Order order1 = Order.CreateOrder(test1);
            List<Order> orders = new List<Order> { order0, order1 };
            orders.ForEach((order) => order.Display());
            Console.WriteLine("Please enter an order:");
            // computer,target,495.95,10/11,10/19
            string input = Console.ReadLine();
            Order orderFromInput = Order.CreateOrder(input);
            orders.Add(orderFromInput);
            orders.ForEach((order) => order.Display());
            File.WriteAllText("output.txt", test0);

            Console.WriteLine();
            Console.WriteLine("Would you like to import orders?");
            input = Console.ReadLine();
            if (input.ToUpper() == "YES" || input.ToUpper() == "Y")
            {
                StreamReader file = new StreamReader("orders.csv");
                string line;
                int counter = 1;
                while ((line = file.ReadLine()) != null)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Line: {counter} reads '{line}'");
                    counter++;

                    //add to orders list
                    orders.Add(Order.CreateOrder(line));
                }
            }
            orders.ForEach((order) => order.Display());

        }

        private static void MainMenu()
        {
            Console.WriteLine("*******************************************************");
            Console.WriteLine("        Welcome to the the Order Manager Program       ");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("This app will help you manage your online purchases");
            Console.WriteLine("Select an option to begin:");
            Console.WriteLine("[1] Add an order");
            Console.WriteLine("[2] Import orders");
            Console.WriteLine("[3] View all orders");
            Console.WriteLine("[4] Search for an order");
            Console.WriteLine("[5] Delete an order");
            Console.WriteLine("[6] Sort orders");
            Console.WriteLine("[7] Order timeline");
        }
    }
}
