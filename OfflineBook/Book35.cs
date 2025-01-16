using System;
using System.Collections.Generic;

namespace Practice_CSharp.OfflineBook
{
    public class Book35
    {
        public void Run()
        {
            //Sphere Surface and Volume
            Console.Write("Enter Sphere radius: ");
            int radius = 10; //int.Parse(Console.ReadLine());
            Console.WriteLine(radius);
            double surface = 4 * Math.PI * Math.Pow(radius, 2);
            Console.WriteLine("Sphere surface is: " + surface);
            double volume = 4 / 3 * Math.PI * Math.Pow(radius, 3);
            Console.WriteLine("Sphere volume is: " + volume);

            //10 Random Numbers Positive or Negative
            Random random = new Random();
            List<int> numbers = new List<int>(10);
            for (int i = 0; i < numbers.Capacity; i++)
            {
                numbers.Add(random.Next(-100, 101));
                Console.Write(numbers[i] + " ");
            }
            Console.WriteLine();
            int positive = 0;
            int negative = 0;
            foreach (int num in numbers)
            {
                if (num > 0)
                {
                    positive++;
                }
                else
                {
                    negative++;
                }
            }
            Console.WriteLine("Positive numbers: " + positive);
            Console.WriteLine("Negative numbers: " + negative);
        }
    }
}
