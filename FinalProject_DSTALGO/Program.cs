using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinalProject_DSTALGO
{
    internal class DeliverySystem
    {
        public class CustomItem
        {
            public string Destination { get; }
            public double Weight { get; }
            public int Priority { get; }

            public CustomItem(string stringValue, double doubleValue, int intValue)
            {
                Destination = stringValue;
                Weight = doubleValue;
                Priority = intValue;
            }

            public override string ToString()
            {
                return $"String: {Destination}, Double: {Weight}, Int: {Priority}";
            }
        }
        static void Main(string[] args)
        {

            int choice;

            Stack<CustomItem> deliveryStack = new Stack<CustomItem>();
            Queue<CustomItem> deliveryQueue = new Queue<CustomItem>();
            List<CustomItem> deliveredPackages = new List<CustomItem>();
            Stack<CustomItem> undeliveredStack = new Stack<CustomItem>();

            do
            {
                Console.WriteLine("\n1. Add Package");
                Console.WriteLine("2. View Current Deliveries");
                Console.WriteLine("3. Execute Delivery");
                Console.WriteLine("4. View Delivered Packages");
                Console.WriteLine("5. Exit");
                Console.Write("Enter your choice: ");

                int.TryParse(Console.ReadLine(), out choice);

                switch (choice)
                {
                    case 1:
                        AddPackage(deliveryStack, undeliveredStack);
                        break;
                    case 2:
                        ViewUndeliveredPackages(undeliveredStack);
                        break;
                    case 3:

                        break;
                    case 4:

                        break;
                    case 5:
                        Console.WriteLine("Exiting the Delivery System. Goodbye!");
                        return;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write("\nPress enter to return to choose operation.");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.ReadLine();
                Console.Clear();

            } while (choice != 0);
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid input, please enter a valid integer.");
            Console.WriteLine("program has been terminated...");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.ReadLine();
        }

        static void AddPackage(Stack<CustomItem> deliveryStack, Stack<CustomItem> undeliveredStack)
        {
            Console.Write("Enter destination: ");
            string destination = Console.ReadLine();

            Console.Write("Enter package weight: ");
            double weight = double.Parse(Console.ReadLine());

            Console.Write("Enter priority (1 - highest, 5 - lowest): ");
            int priority = int.Parse(Console.ReadLine());

            
            CustomItem item1 = new CustomItem(destination, weight, priority);

            if(priority == 1)
            {
                deliveryStack.Push(item1);
                undeliveredStack.Push(item1);
            }
            else
            {
                //send to queue
                //send to undelivered queue
            }

        }

        static void ViewUndeliveredPackages(Stack<CustomItem> undeliveredStack)
        {
            Console.WriteLine("\nUndelivered Packages:");

            if (undeliveredStack.Count == 0)
            {
                Console.WriteLine("No undelivered packages.");
                return;
            }

            foreach (CustomItem package in undeliveredStack)
            {
                Console.WriteLine($"Undelivered package to {package.Destination} (Priority: {package.Priority})");
            }
        }
    }
}
