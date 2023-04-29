using System;
using System.IO;
using System.Net;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;

namespace ConsoleApp2
{
    class Program
    {
        static void Main()
        {
            string path = @"E:\txt.txt";

            if (File.Exists(path))
            {
                string fileContent = File.ReadAllText(path);
                Console.WriteLine("File contents:");
                Console.WriteLine(fileContent);
            }
            else
            {
                Console.WriteLine("File does not exist");
            }
            WebClient client = new WebClient();
            string result = client.DownloadString("https://moodle3.chmnu.edu.ua/login/index.php");
            Console.WriteLine(result);

            List<string> myList = new List<string>();

            myList.Add("1");
            myList.Add("2");
            myList.Add("3");
            myList.Add("4");
            myList.Add("5");

            foreach (string item in myList)
            {
                Console.WriteLine(item);
            }
            int[] numbers = { 1, 2, 3, 4, 5 };

            int sum = numbers.Where(n => n % 3 == 0).Sum();

            Console.WriteLine("Sum of even numbers: " + sum);

            var rng = new RNGCryptoServiceProvider();

            byte[] buffer = new byte[4];

            rng.GetBytes(buffer);
            int randomNumber = Math.Abs(BitConverter.ToInt32(buffer, 0)) % 10 + 1;

            Console.WriteLine("Random number: " + randomNumber);
            Console.ReadLine();
        }
    }
}
