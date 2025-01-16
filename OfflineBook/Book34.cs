using System;

namespace Practice_CSharp.OfflineBook
{
    public class Book34
    {
        public void Run()
        {
            //Rectangle Perimeter/Area
            Console.Write("Enter Rectanlge height: ");
            int height = 10; //int.Parse(Console.ReadLine());
            Console.WriteLine(height);
            Console.Write("Enter Rectangle width: ");
            int width = 15; //int.Parse(Console.ReadLine());
            Console.WriteLine(width);
            int perimeter = 2 * (height + width);
            int area = height * width;
            Console.WriteLine("Rectangle perimeter: " + perimeter);
            Console.WriteLine("Rectangle area: " + area);

            //Even or Odd
            Console.Write("Enter a number: ");
            int number = 10; //int.Parse(Console.ReadLine());
            Console.WriteLine(number);
            if(number % 2 == 0)
            {
                Console.WriteLine(String.Format("Number {0} is even.", number));
            }
            else
            {
                Console.WriteLine(String.Format("Number {0} is odd.", number));
            }

            //Positive or Negative or Zero
            Console.Write("Enter a number: ");
            int number2 = 10; //int.Parse(Console.ReadLine());
            Console.WriteLine(number2);
            if(number2 > 0)
            {
                Console.WriteLine(String.Format("Number {0} is positive.", number2));
            }
            else if(number2 < 0)
            {
                Console.WriteLine(String.Format("Number {0} is negative.", number2));
            }
            else
            {
                Console.WriteLine(String.Format("Number {0} is zero.", number2));
            }

            //Array with Random values
            Console.Write("Enter the length of the Array: ");
            int count = 50; //int.Parse(Console.ReadLine());
            Console.WriteLine(count);
            int inclusiveMinimum = 1;
            int exclusiveMaximum = 101;
            int[] array = new int[count];
            Random rnd = new Random();
            for(int i = 0; i < count; i++) 
            {
                array[i] = rnd.Next(inclusiveMinimum, exclusiveMaximum);
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            //Guess the Number
            Random random = new Random();
            int computerNumber = random.Next(1, 11);
            for(int i = 1;i < 11; i++)
            {
                if(i == computerNumber)
                {
                    Console.WriteLine("The number was: " + computerNumber);
                    break;
                }
                else
                {
                    Console.WriteLine("Wrong guess.");
                }
            }

        }
    }
}
