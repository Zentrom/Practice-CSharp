using System;
using System.Collections.Generic;

namespace Practice_CSharp.OfflineBook
{
    public class Book33
    {
        public void Run()
        {
            //Hello World
            Console.WriteLine("Hello World!");
            Console.WriteLine();

            //Age
            Console.WriteLine("What is your name?");
            string name = "Zentrom"; //Console.ReadLine();
            Console.WriteLine(name);
            Console.WriteLine("What is your date of birth? [YYYY.MM.DD]");
            string dateBirth = "1994.09.01"; //Console.ReadLine();
            Console.WriteLine(dateBirth);
            DateTime dateTime = DateTime.Parse(dateBirth);
            double age = DateTime.Now.Subtract(dateTime).Days / 365.25;
            Console.WriteLine(String.Format("Hello {0}, your age is: {1}", name, (int)age));

            if (age >= 20)
            {
                Console.WriteLine("You are older than 20.");
            }
            else
            {
                Console.WriteLine("You are younger than 20.");
            }

            //Arrays
            double[] numbers = new double[10];
            for (int i = 0; i < numbers.Length; i++)
            {
                numbers[i] = (((i + 1) * 3) / 2) - 1;
            }
            foreach (double item in numbers)
            {
                Console.WriteLine(item);
            }

            //List
            List<string> toDoList = new List<string>();
            toDoList.Add("Shop");
            toDoList.Add("ReadNews");
            toDoList.Add("Clean");
            toDoList.Remove("Shop");
        }
    }
}
