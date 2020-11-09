using System;
using System.IO;
using System.Collections.Generic;

namespace OrderManager
{
    class Program
    {
        

        static void Main()
        {
            bool showMenu = true;
            while (showMenu)
            {
                showMenu = MainMenu();
            }

            Console.WriteLine("Thank you for using the Order Manager Program!");
            Console.WriteLine("Program exiting...");

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

        private static bool MainMenu()
        {
            Console.WriteLine();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("        Welcome to the Order Manager Program       ");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("This app will help you manage your online purchases");
            Console.WriteLine("\r\nSelect an option to begin:");
            Console.WriteLine("[1] View orders");
            Console.WriteLine("[2] Add an order");
            Console.WriteLine("[3] Import orders");
            Console.WriteLine("[4] Search for an order");
            Console.WriteLine("[5] Delete an order");
            Console.WriteLine("[6] Sort orders");
            Console.WriteLine("[7] Order timeline");
            Console.WriteLine("[8] Exit");
            Console.Write("\r\nSelect an option: ");
            

            switch (Console.ReadLine())
            {
                case "1":
                    Console.WriteLine("You entered 1!");
                    return true;
                case "2":
                    Console.WriteLine("You entered 2!");
                    return true;
                case "3":
                    Console.WriteLine("You entered 3!");
                    return true;
                case "4":
                    Console.WriteLine("You entered 4!");
                    return true;
                case "5":
                    Console.WriteLine("You entered 5!");
                    return true;
                case "6":
                    Console.WriteLine("You entered 6!");
                    return true;
                case "7":
                    Console.WriteLine("You entered 7!");
                    return true;
                case "8":
                    Console.WriteLine("You entered 8!");
                    return false;
                default:
                    return true;
            }
        }
    }
}
