using System;

namespace OrderManager
{
    class Program
    {
        public static Order CreateOrder(string str)
        {
            string[] arr = str.Split(',');
            return new Order(arr[0], arr[1], Double.Parse(arr[2]), arr[3], arr[4]);
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
        }
    }
}
