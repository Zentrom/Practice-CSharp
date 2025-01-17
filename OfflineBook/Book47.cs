using System;

namespace Practice_CSharp.OfflineBook
{
    public class Book47
    {
        int[] FirstNumbersOfAnArray(int length)
        {
            int[] array = new int[length];

            for(int i = 0; i < array.Length; i++)
            {
                if(i%2 == 0)
                {
                    array[i] = -1 * i;
                }
                else
                {
                    array[i] = i;
                }
            }
            return array;
        }

        int ItemOfFibonacci(int n)
        {
            if(n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                int left = 1;
                int right = 1;
                int temp;
                for(int i = 0;i < n;i++)
                {
                    temp = left;
                    left = right;
                    right = temp + left;
                }
                return right;
            }
        }

        bool Contains(string[] collection, string word)
        {
            foreach(string element in collection) 
            {
                if(element == word)
                {
                    return true;
                }
            }
            return false;
        }

        int[] CreateArrayWithRandomValues(Random random,  int count)
        {
            int[] result = new int[count];
            for(int i = 0; i < count; i++)
            {
                result[i] = random.Next(1, 101);
            }
            return result;
        }

        int CountHigherValuesThan(int[] collection, int threshold)
        {
            int count = 0;
            foreach(int item in collection)
            {
                if(item > threshold)
                {
                    count++;
                }
            }
            return count;
        }

        bool HasValue(int[] collection, int data)
        {
            foreach(int item in collection)
            {
                if(item == data)
                {
                    return true;
                }
            }
            return false;
        }

        int[] CreateUnion(int[] opA, int[] opB)
        {
            int countOfCommonItems = 0;
            foreach (int item in opB)
            {
                if(HasValue(opA, item))
                {
                    countOfCommonItems++;
                }
            }
            int unionLength = opA.Length + opB.Length - countOfCommonItems;
            int[] result = new int[unionLength];
            int index;
            for(index = 0; index < opA.Length; index++)
            {
                result[index] = opA[index];
            }
            foreach(int item in opB)
            {
                if(!HasValue(opA, item))
                {
                    result[index] = item;
                    index++;
                }
            }
            return result;
        }

        public void Run()
        {
            //Positive and Negative sequence
            int[] first20 = FirstNumbersOfAnArray(20);
            foreach(int number in first20)
            {
                Console.Write(number + ", ");
            }
            Console.WriteLine();

            //Fibonacci value
            Console.WriteLine(ItemOfFibonacci(5));

            //Check if Array contains word
            string[] sentence = { "rudolph", "the", "red", "nosed", "reindeer" };
            foreach(string elem in sentence) { Console.Write(elem + " "); }
            Console.WriteLine();
            string guess = "red"; //Console.ReadLine()
            bool hasWord = Contains(sentence, guess);
            if (hasWord)
            {
                Console.WriteLine("There is a match.");
            }
            else
            {
                Console.WriteLine("There is no match.");
            }

            //Count values higher than X
            Random sourceOfRandomness = new Random();
            int[] numbers = CreateArrayWithRandomValues(sourceOfRandomness, 10);
            foreach(int number in numbers) {  Console.Write(number + ", "); }
            Console.WriteLine();
            int numbersAboveTen = CountHigherValuesThan(numbers, 10);
            Console.WriteLine("Number of items above 10: {0}", numbersAboveTen);

            //Distinct Union of two Sets
            int[] set1 = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach(int num in set1) {  Console.Write(num + ", "); }
            Console.WriteLine();
            int[] set2 = { 2, 4, 6, 8, 10, 12, 14, 16 };
            foreach(int num in set2) {  Console.Write(num + ", "); }
            Console.WriteLine();
            Console.WriteLine("Union of values: ");
            int[] union = CreateUnion(set1, set2);
            foreach (int num in union) { Console.Write(num + ", "); }
            Console.WriteLine();

        }
    }
}
