# OrderManager
- Code Louisville C# Final Project

## Description
This is a C# console app that helps me manage my online purchases. I wanted a program that allows me to store order information such as the price and arrival date of each order. This would make it easier to keep track of when orders will arrive. Using this program, a user can add, remove, and sort orders. The program also allows multiple orders to be imported from a CSV file labelled "Input.csv". Finally, order readouts can be exported to a TXT file labelled "Output.txt".

## Feature Requirements met
- Implement a “master loop” console application where the user can repeatedly enter commands/perform actions, including choosing to exit the program
    - master loop for navigation
- Create a dictionary or list, populate it with several values, retrieve at least one value, and use it in your program
    - uses Lists of Orders
- Read data from an external file, such as text, JSON, CSV, etc and use that data in your application
    - reads data from "Input.csv" file
- Implement a log that records errors, invalid inputs, or other important events and writes them to a text file
    - allows a List of Orders to be exported to "Output.txt"
- Use a LINQ query to retrieve information from a data structure (such as a list or array) or file
    - uses LINQ to sort orders by date
- Create 3 or more unit tests for your application
    - "OrderTests.cs" contains over 6 unit tests
