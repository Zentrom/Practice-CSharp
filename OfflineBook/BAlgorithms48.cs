using System;
using System.Linq;

namespace Practice_CSharp.OfflineBook
{
    public class BAlgorithms48
    {
        int FindSmallest(int[] values, int maxValue)
        {
            int result = maxValue;
            for(int i = 0; i < values.Length; i++)
            {
                if (values[i] < result)
                {
                    result = values[i];
                }
            }
            return result;
        }

        int ItemOfFibonacci(int n)
        {
            if (n == 0 || n == 1)
            {
                return 1;
            }
            else
            {
                int left = 1;
                int right = 1;
                int temp;
                for (int i = 0; i < n; i++)
                {
                    temp = left;
                    left = right;
                    right = temp + left;
                }
                return right;
            }
        }

        int[] GerenateRandomArray(Random random, int size)
        {
            int[] result = new int[size];
            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(0, 101);
                Console.Write(result[i] + ", ");
            }
            Console.WriteLine();
            return result;
        }

        int CountDistinctIdenticals(int[] opA, int[] opB)
        {
            int result = 0;
            int[] distincts = new int[opA.Length + opB.Length];
            int emptyIndex = 0;
            for (int i = 0; i < opA.Length; i++)
            {
                for(int j = 0; j < opB.Length; j++)
                {
                    if (opA[i] == opB[j])
                    {
                        if (!distincts.Contains(opA[i]))
                        {
                            distincts[emptyIndex] = opA[i];
                            emptyIndex++;
                            result++;
                        }
                        break;
                    }
                }
            }
            return result;
        }

        int[] SetSubstract(int[] opA, int[] opB)
        {
            int[] result = new int[opA.Length - CountDistinctIdenticals(opA, opB)];
            int emptyIndex = 0;
            for (int i = 0;i < opA.Length; i++)
            {
                bool found = false;
                for(int j = 0;j < opB.Length; j++)
                {
                    if (opA[i] == opB[j])
                    {
                        found = true;
                        break;
                    }
                }
                if (!found)
                {
                    result[emptyIndex] = opA[i];
                    emptyIndex++;
                }
            }
            return result;
        }

        public void Run()
        {
            //Smallest number in Array
            Random random = new Random();
            int[] rndNumbers = GerenateRandomArray(random, 20);
            Console.WriteLine("Smallest values is: {0}", FindSmallest(rndNumbers, 100));

            //Array of first N Fibonacci numbers
            for(int i = 0;i < 10; i++)
            {
                Console.Write(ItemOfFibonacci(i) + ", ");
            }
            Console.WriteLine();

            //Count distinct identical values of 2 Arrays
            int[] set1 = GerenateRandomArray(random, 30);
            int[] set2 = GerenateRandomArray(random, 30);
            Console.WriteLine("There are {0} distinct identical values.", CountDistinctIdenticals(set1, set2));

            //Sets A-B and B-A
            int[] AsubstractB = SetSubstract(set1, set2);
            Console.WriteLine("Substract A-B:");
            foreach(int num in AsubstractB) { Console.Write(num + ", "); }
            Console.WriteLine();
            int[] BsubstractA = SetSubstract(set2, set1);
            Console.WriteLine("Substract B-A:");
            foreach (int num in BsubstractA) { Console.Write(num + ", "); }
            Console.WriteLine();
        }
    }
}
