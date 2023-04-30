using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace ConsoleApp4
{
    internal class Program
    {
        class Car
        {
            public string CarName;
            protected double EnginePower;
            private int Engine;
            internal char ModelName;
            protected internal object Wheels;

            public Car(string carName, double enginePower, int engine, char modelName, object wheels)
            {
                CarName = carName;
                EnginePower = enginePower;
                Engine = engine;
                ModelName = modelName;
                Wheels = wheels;
            }
            internal void SetEnginePower(double enginePower)
            {
                EnginePower = enginePower;
                Console.WriteLine($"Engine power of {CarName} set to {enginePower}");
            }

            public double GetEnginePower()
            {
                return EnginePower;
            }

            protected internal void SetWheels(object wheels)
            {
                Wheels = wheels;
                Console.WriteLine($"Wheels of {CarName} set to {wheels}");
            }
        }
        static void Main(string[] args)
        {
            Type carType = typeof(Car);

            Console.WriteLine("Properties of Car class:");
            PropertyInfo[] properties = carType.GetProperties();
            foreach (var property in properties)
            {
                Console.WriteLine($"{property.Name}: {property.PropertyType}");
            }

            Console.WriteLine("\nMethods of Car class:");
            MethodInfo[] methods = carType.GetMethods(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var method in methods)
            {
                Console.WriteLine($"{method.Name}");
            }

            Console.WriteLine("\nFields of Car class:");
            FieldInfo[] fields = carType.GetFields(BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public);
            foreach (var field in fields)
            {
                Console.WriteLine($"{field.Name}: {field.FieldType}");
            }

            Console.WriteLine("\nCalling a method using reflection:");
            Car car = new Car("BMW", 200.0, 4, 'X', "Alloy");
            MethodInfo getEnginePowerMethodInfo = carType.GetMethod("GetEnginePower", BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            double enginePower = (double)getEnginePowerMethodInfo.Invoke(car, null);
            Console.WriteLine($"\nEngine power: {enginePower}");

            Console.ReadKey();
        }
    }
}
