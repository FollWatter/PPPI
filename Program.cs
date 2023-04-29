using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApp3
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Thread t1 = new Thread(async () => await ThreadMethod1());
            Thread t2 = new Thread(async () => await ThreadMethod2());
            Thread t3 = new Thread(async () => await ThreadMethod3());

            t1.Start();
            t2.Start();
            t3.Start();

            t1.Join();
            t2.Join();
            t3.Join();

            Console.WriteLine("All threads completed");
            Console.ReadKey();
        }
        static async Task ThreadMethod1()
        {
            Console.WriteLine($"ThreadMethod1 is running on thread {Thread.CurrentThread.ManagedThreadId}");
            await Task.Delay(3000);
            Console.WriteLine($"ThreadMethod1 completed on thread {Thread.CurrentThread.ManagedThreadId}");
        }
        static async Task ThreadMethod2()
        {
            Console.WriteLine($"ThreadMethod2 is running on thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 0; i < 5; i++)
            {
                var random = new Random();
                int randomNumber = random.Next(1, 100);
                Console.WriteLine($"Random number generated: {randomNumber} on thread {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(2000);
            }
            Console.WriteLine($"ThreadMethod2 completed on thread {Thread.CurrentThread.ManagedThreadId}");
        }
        static async Task ThreadMethod3()
        {
            Console.WriteLine($"ThreadMethod3 is running on thread {Thread.CurrentThread.ManagedThreadId}");
            for (int i = 1; i <= 10; i++)
            {
                Console.WriteLine($"Number: {i} on thread {Thread.CurrentThread.ManagedThreadId}");
                await Task.Delay(1000);
            }
            Console.WriteLine($"ThreadMethod3 completed on thread {Thread.CurrentThread.ManagedThreadId}");
        }

    }
}

