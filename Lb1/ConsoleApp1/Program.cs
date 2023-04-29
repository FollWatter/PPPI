using System;
using System.IO;

namespace ConsoleApp1
{
    class Program
    {
        // Field to store the initial text from the file
        private static string text;

        static void Main(string[] args)
        {
            bool exit = false;
            while (!exit)
            {
                // Display the selection menu
                Console.WriteLine("1) Display number of words from text");
                Console.WriteLine("2) Perform mathematical operation");
                Console.WriteLine("3) Exit");

                // Handle user input
                int selection;
                bool success = int.TryParse(Console.ReadLine(), out selection);

                if (!success || selection < 1 || selection > 3)
                {
                    Console.WriteLine("Invalid selection. Please enter a number between 1 and 3.");
                }
                else
                {
                    switch (selection)
                    {
                        case 1:
                            LoremSplit();
                            break;
                        case 2:
                            MathOperation();
                            break;
                        case 3:
                            exit = true;
                            break;
                    }
                }
            }
        }

        private static void LoremSplit()
        {
            Console.WriteLine("Enter the number of words you want to display:");
            int numberOfWords;
            bool success = int.TryParse(Console.ReadLine(), out numberOfWords);

            if (!success || numberOfWords < 1)
            {
                Console.WriteLine("Invalid input. Please enter a positive integer.");
            }
            else
            {
                string path = @"E:\txt.txt";
                text = File.ReadAllText(path);

                string[] words = text.Split(' ');
                for (int i = 0; i < Math.Min(numberOfWords, words.Length); i++)
                {
                    Console.Write(words[i] + " ");
                }
                Console.WriteLine();
            }
        }

        // Method to display Mathematic Operations
        private static void MathOperation()
        {
            bool exit = false;
            while (!exit)
            {
                Console.WriteLine("1) Addition");
                Console.WriteLine("2) Subtraction");
                Console.WriteLine("3) Multiplication");
                Console.WriteLine("4) Division");
                Console.WriteLine("5) Exit");

                int operation;
                bool success = int.TryParse(Console.ReadLine(), out operation);

                if (!success || operation < 1 || operation > 5)
                {
                    Console.WriteLine("Invalid operation. Please enter a number between 1 and 5.");
                }
                else if (operation == 5)
                {
                    exit = true;
                }
                else
                {
                    Console.WriteLine("Enter first number:");
                    double a;
                    success = double.TryParse(Console.ReadLine(), out a);

                    Console.WriteLine("Enter second number:");
                    double b;
                    success &= double.TryParse(Console.ReadLine(), out b);

                    if (!success)
                    {
                        Console.WriteLine("Invalid input. Please enter a valid number.");
                    }
                    else
                    {
                        double result = 0;
                        switch (operation)
                        {
                            case 1:
                                result = a + b;
                                break;
                            case 2:
                                result = a - b;
                                break;
                            case 3:
                                result = a * b;
                                break;
                            case 4:
                                if (b == 0)
                                {
                                    Console.WriteLine("Division by zero is not allowed.");
                                    continue;
                                }
                                result = a / b;
                                break;
                        }
                        Console.WriteLine("Result: " + result);
                    }
                }
            }
        }
    }
}
