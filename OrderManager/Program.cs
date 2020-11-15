using System;
using System.IO;
using System.Collections.Generic;

namespace OrderManager
{
    class Program
    {
        

        static void Main()
        {
            // display heading for program
            Console.WriteLine();
            Console.WriteLine("*******************************************************");
            Console.WriteLine("        Welcome to the Order Manager Program       ");
            Console.WriteLine("*******************************************************");
            Console.WriteLine("This app will help you keep track of your online purchases and when they will arrive");

            // create 2 sample orders 
            Order order0 = Order.CreateOrder("mouse,amazon,12.50,10/16,10/19"); 
            Order order1 = Order.CreateOrder("water bottle,walmart,5.99,10/02,10/24");

            // create an list of orders
            List<Order> orders = new List<Order> { order0, order1 };

            // menu interface
            bool showMenu = true; // used for menu loop
            while (showMenu)
            {
                showMenu = MainMenu(orders);
            }

            Console.WriteLine("Thank you for using the Order Manager Program!");
            Console.WriteLine("Program exiting...");
        }

        private static bool MainMenu(List<Order> orders)
        {

            Console.WriteLine("\r\n------------------------");
            Console.WriteLine("    Navigation Menu");
            Console.WriteLine("------------------------");
            Console.WriteLine("[1] View all orders");

            Console.WriteLine("[2] Add an order");
            Console.WriteLine("[3] Delete an order");

            Console.WriteLine("[4] Import orders");
            Console.WriteLine("[5] Export orders");
            
            Console.WriteLine("[6] Sort orders");
            Console.WriteLine("[7] Order timeline");
            Console.WriteLine("[8] Exit");
            Console.Write("\r\nSelect an option: ");
            

            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You entered 1. Displaying all orders:");
                    DisplayAll(orders);
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "2":
                    Console.Clear();
                    Console.WriteLine("You entered 2. To add an order, please enter the order info in the following format:");
                    Console.WriteLine("item, store, cost (exclude $ sign), order date (month/day), arrival date (month/day)");
                    Console.WriteLine("For example:");
                    Console.WriteLine("computer, target, 495.95, 10/11, 10/19");
                    Console.Write("\r\nEnter a new order: ");
                    ImportOrders(orders);
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "3":
                    Console.WriteLine("You entered 3. Select the order to be delete by entering the number next to the order:");
                    Console.WriteLine();
                    for (int i = 0; i < orders.Count; i++)
                    {
                        Console.WriteLine($"[{i+1}]: {orders[i].Item} from {orders[i].Store} on {orders[i].OrderDate.ToString("MM/dd/yyyy")}");
                    }
                    Console.WriteLine();
                    Console.Write("\r\nSelect an order to delete: ");
                    try
                    {
                        int orderToDelete = Int32.Parse(Console.ReadLine());
                        if (orderToDelete > 0 && orderToDelete <= orders.Count)
                        {
                            Console.WriteLine($"Deleting Order #{orderToDelete}...");
                            Console.WriteLine("...Success!");
                            orders.RemoveAt(orderToDelete - 1);
                        }
                        else
                        {
                            Console.WriteLine("Error: Invalid selection, no orders were deleted");
                        }
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Error2: Invalid selection, no orders were deleted");
                    }


                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;


                case "4":
                    Console.Clear();
                    Console.WriteLine("You entered 4. This will import orders from 'Input.csv' file.");
                    Console.WriteLine("Would you like to continue? (Y/n)");
                    Console.Write("\r\nSelect an option: ");
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            break;
                        case "YES":
                            break;
                        default:
                            Console.WriteLine("Import cancelled. Press the return key to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            return true;
                    }

                    StreamReader file = new StreamReader("Input.csv");
                    string line;
                    int counter = 1;
                    while ((line = file.ReadLine()) != null)
                    {
                        //Console.WriteLine();
                        //Console.WriteLine($"Line: {counter} reads '{line}'");
                        counter++;

                        //add to orders list
                        orders.Add(Order.CreateOrder(line));
                    }
                    Console.WriteLine("...Import successful!");
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;

                case "5":
                    Console.Clear();
                    Console.WriteLine("You entered 5. This will export the list of orders to 'Output.txt' file.");
                    Console.WriteLine("Would you like to continue? (Y/n)");
                    Console.Write("\r\nSelect an option: ");
                    switch (Console.ReadLine().ToUpper())
                    {
                        case "Y":
                            break;
                        case "YES":
                            break;
                        default:
                            Console.WriteLine("Export cancelled. Press the return key to continue...");
                            Console.ReadLine();
                            Console.Clear();
                            return true;
                    }
                    FileStream fs = new FileStream("Output.txt", FileMode.Create);
                    // First, save the standard output.
                    TextWriter tmp = Console.Out;
                    StreamWriter sw = new StreamWriter(fs);
                    Console.SetOut(sw);
                    DisplayAll(orders);
                    Console.SetOut(tmp);
                    Console.WriteLine("...Success! All orders were exported to Output.txt");
                    sw.Close();
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;

                case "6":
                    Console.WriteLine("You entered 6.");
                    return true;
                case "7":
                    Console.WriteLine("You entered 7.");
                    return true;
                case "8":
                    Console.WriteLine("You entered 8.");
                    return false;
                default:
                    Console.Clear();
                    return true;
            }
        }

        private static void ImportOrders(List<Order> orders)
        {
            try
            {
                string inputAddOrder = Console.ReadLine();
                orders.Add(Order.CreateOrder(inputAddOrder));
                Console.WriteLine("...Success! Your order has been added.");

            }
            catch (Exception)
            {

                Console.WriteLine("Error: The format of the order info was not correct.");
            }
        }

        private static void DisplayAll(List<Order> orders)
        {
            orders.ForEach((order) => order.Display());
        }
    }
}
