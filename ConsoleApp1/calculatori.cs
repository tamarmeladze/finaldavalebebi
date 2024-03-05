﻿namespace ConsoleApp1
{
    public class Calculator
    {
        public static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("Enter first number");
                double num1 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter second number");
                double num2 = double.Parse(Console.ReadLine());
                Console.WriteLine("Enter +,-,* or /");
                char operation = char.Parse(Console.ReadLine());

                if (operation == '+')
                    Console.WriteLine("{0}+{1}={2}", num1, num2, num1 + num2);
                else if (operation == '-')

                    Console.WriteLine("{0}-{1}={2}", num1, num2, num1 - num2);
                else if (operation == '*')
                    Console.WriteLine("{0}*{1}={2}", num1, num2, num1 * num2);
                else if (operation == '/')
                    if (num2 == 0)
                        Console.WriteLine("can't divide by zero");
                    else
                        Console.WriteLine("{0}/{1}={2}", num1, num2, num1 / num2);
                else
                    Console.WriteLine("Unrecognized character");

                Console.WriteLine("press 'q' to quit or any other key to continue");
                if (Console.ReadLine() == "q")
                    break;
                Console.Clear();
            }
        }

    }
}
