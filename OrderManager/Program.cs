using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;

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
            Console.WriteLine("[7] Arrival status");
            Console.WriteLine("[8] Exit");
            Console.Write("\r\nSelect an option: ");
            
            switch (Console.ReadLine())
            {
                case "1":
                    Console.Clear();
                    Console.WriteLine("You entered 1. Displaying all orders:");
                    if (orders.Count > 0)
                    {
                        DisplayAll(orders);
                    }
                    else
                    {
                        Console.WriteLine("\r\nThe Order List is empty, no orders to display...\r\n");
                    }
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
                    AddOrder(orders);
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "3":
                    Console.Clear();
                    Console.WriteLine("You entered 3. Select the order to be delete by entering the number next to the order:");
                    Console.WriteLine();
                    if (orders.Count > 0)
	                {
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
                            Console.WriteLine("Error: Invalid selection, no orders were deleted");
                        }                       
	                }
                    else
	                {
                        Console.WriteLine("The Order List is empty, no orders to delete...\r\n");
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
                    //int counter = 1;
                    while ((line = file.ReadLine()) != null)
                    {
                        //Console.WriteLine();
                        //Console.WriteLine($"Line: {counter} reads '{line}'");
                        //counter++;
                        orders.Add(Order.CreateOrder(line)); //add to orders list
                    }
                    file.Close();
                    Console.WriteLine("...Import successful!");
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "5":
                    Console.Clear();
                    Console.WriteLine("You entered 5. This will export the list of orders to 'Output.txt' file.");
                    if (orders.Count > 0)
                    {
                        Console.WriteLine("Would you like to continue? (Y/n)");
                        ExportOrders(orders);
                    }
                    else
                    {
                        Console.WriteLine("\r\nThe Order List is empty, no orders to export...\r\n");
                    }
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "6":
                    Console.Clear();
                    Console.WriteLine("You entered 6. How should the orders be sorted?");
                    if (orders.Count > 0)
                    {
                        Console.WriteLine();
                        Console.WriteLine("[1]: By Item Name");
                        Console.WriteLine("[2]: By Store Name");
                        Console.WriteLine("[3]: By Price");
                        Console.WriteLine("[4]: By Date Ordered");
                        Console.WriteLine("[5]: By Date Arriving");
                        Console.Write("\r\nSelect an option: ");
                        List<Order> sortedOrders;
                        switch (Console.ReadLine())
                        {
                            case "1":
                                Console.WriteLine("Ok. Sort by Item Name, in which order?");
                                Console.WriteLine("[1]: ascending to descending");
                                Console.WriteLine("[2]: descending to ascending");
                                Console.Write("\r\nSelect an option: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        sortedOrders = orders.OrderBy(x => x.Item).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    case "2":
                                        sortedOrders = orders.OrderByDescending(x => x.Item).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    default:
                                        InvalidSelectionPrompt();
                                        return true;
                                }
                                break;
                            case "2":
                                Console.WriteLine("Ok. Sort by Store Name, in which order?");
                                Console.WriteLine("[1]: ascending to descending");
                                Console.WriteLine("[2]: descending to ascending");
                                Console.Write("\r\nSelect an option: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        sortedOrders = orders.OrderBy(x => x.Store).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    case "2":
                                        sortedOrders = orders.OrderByDescending(x => x.Store).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    default:
                                        InvalidSelectionPrompt();
                                        return true;
                                }
                                break;
                            case "3":
                                Console.WriteLine("Ok. Sort by Price, in which order?");
                                Console.WriteLine("[1]: lowest to highest");
                                Console.WriteLine("[2]: highest to lowest");
                                Console.Write("\r\nSelect an option: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        sortedOrders = orders.OrderBy(x => x.Price).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    case "2":
                                        sortedOrders = orders.OrderByDescending(x => x.Price).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    default:
                                        InvalidSelectionPrompt();
                                        return true;
                                }
                                break;
                            case "4":
                                Console.WriteLine("Ok. Sort by Date Ordered, in which way?");
                                Console.WriteLine("[1]: oldest to newest");
                                Console.WriteLine("[2]: newest to oldest");
                                Console.Write("\r\nSelect an option: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        sortedOrders = orders.OrderBy(x => x.OrderDate).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    case "2":
                                        sortedOrders = orders.OrderByDescending(x => x.OrderDate).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    default:
                                        InvalidSelectionPrompt();
                                        return true;
                                }
                                break;
                            case "5":
                                Console.WriteLine("Ok. Sort by Date Arriving, in which way?");
                                Console.WriteLine("[1]: oldest to newest");
                                Console.WriteLine("[2]: newest to oldest");
                                Console.Write("\r\nSelect an option: ");
                                switch (Console.ReadLine())
                                {
                                    case "1":
                                        sortedOrders = orders.OrderBy(x => x.ArrivalDate).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    case "2":
                                        sortedOrders = orders.OrderByDescending(x => x.ArrivalDate).ToList();
                                        DisplaySortAndAskExport(sortedOrders);
                                        break;
                                    default:
                                        InvalidSelectionPrompt();
                                        return true;
                                }
                                break;
                            default:
                                InvalidSelectionPrompt();
                                return true;
                        }
                    }
                    else
                    {
                        Console.WriteLine("\r\nThe Order List is empty, no orders to sort...\r\n");
                    }
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "7":
                    Console.Clear();
                    Console.WriteLine("You entered 7. Displaying order status:");
                    if (orders.Count > 0)
                    {
                        for (int i = 0; i < orders.Count; i++)
                        {
                            Console.WriteLine();
                            Console.WriteLine($"{orders[i].Item} from {orders[i].Store}\r\n{orders[i].ArrivalStatus()}");
                        }
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.WriteLine("\r\nThe Order List is empty, no orders to display...\r\n");
                    }
                    Console.WriteLine("Press the return key to continue...");
                    Console.ReadLine();
                    Console.Clear();
                    return true;
                case "8":
                    Console.WriteLine("You entered 8. Exiting program...");
                    return false;
                default:
                    Console.Clear();
                    return true;
            }
        }

        private static void InvalidSelectionPrompt()
        {
            Console.WriteLine("Invalid selection! Press the return key to continue...");
            Console.ReadLine();
            Console.Clear();
        }

        private static void DisplaySortAndAskExport(List<Order> sortedOrders)
        {
            DisplayAll(sortedOrders);
            Console.WriteLine();
            Console.WriteLine("Would you like to export this sorted list to 'Output.txt'? (Y/n)");
            ExportOrders(sortedOrders);
        }

        private static void ExportOrders(List<Order> orders)
        {
            Console.Write("\r\nSelect an option: ");
            switch (Console.ReadLine().ToUpper())
            {
                case "Y":
                case "YES":
                    FileStream fs = new FileStream("Output.txt", FileMode.Create);
                    // First, save the standard output.
                    TextWriter tmp = Console.Out;
                    StreamWriter sw = new StreamWriter(fs);
                    Console.SetOut(sw);
                    DisplayAll(orders);
                    Console.SetOut(tmp);
                    Console.WriteLine("...Success! All orders were exported to Output.txt");
                    sw.Close();
                    fs.Close();
                    break;
                default:
                    Console.WriteLine("Export cancelled...");
                    break;
            }
        }

        private static void AddOrder(List<Order> orders)
        {
            try
            {
                string inputAddOrder = Console.ReadLine();
                Order order = Order.CreateOrder(inputAddOrder);
                if (order.OrderDate > order.ArrivalDate)
	            {
                    Console.WriteLine("Error: The Arrival Date cannot occur before the Order Date...");
	            }
                else
	            {
                    orders.Add(order);
                    Console.WriteLine("...Success! Your order has been added.");
	            }
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
