using System;

namespace Practice_CSharp.OfflineBook
{
    public class BAlgorithms46
    {
        bool HasNegative(int[] array)
        {
            foreach (int number in array) 
            {
                if(number < 0)
                {
                    return true;
                }
            }
            return false;
        }

        int IndexOfBestWeapon(int[] weaponData) 
        {
            int bestIndex = 0;
            for (int i = 1; i < weaponData.Length; i++)
            {
                if (weaponData[i] > weaponData[bestIndex])
                {
                    bestIndex = i;
                }
            }
            return bestIndex;
        }

        int PhoneSearch(bool[] objects)
        {
            int phoneIndex = -1;
            for (int i = 0; i < objects.Length; i++)
            {
                if (objects[i])
                {
                    return i;
                }
            }
            return phoneIndex;
        }

        public void Run()
        {
            //Decision - Check if array has Negative value
            int[] numbers = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            foreach (int number in numbers) { Console.Write(number + " "); }
            Console.WriteLine();
            bool negativeIndicator = HasNegative(numbers);
            if(negativeIndicator)
            {
                Console.WriteLine("Array has Negative number.");
            }
            else 
            {
                Console.WriteLine("Array has only Positive numbers.");
            }

            //Maximum Search - Get index of biggest element
            int[] damages = { 20, 50, 10, 200, 50, 140 };
            foreach (int number in damages) {  Console.Write(number + " "); }
            Console.WriteLine();
            Console.WriteLine("The best weapon is: {0}", IndexOfBestWeapon(damages));

            //Find - Find first true element in Array
            bool[] phoneOrNot = { false, false, false, true, false, false };
            int indexOfPhone = PhoneSearch(phoneOrNot);
            if(indexOfPhone == -1)
            {
                Console.WriteLine("Phone not found.");
            }
            else
            {
                Console.WriteLine("Phone is at index: {0}", indexOfPhone);
            }

            //Sort - Sort elements in an Array
            int[] array = { 0, 9, 2, 7, 10, 3, 4, 6, 8, 1, 5 };
            foreach(int elem in array) {  Console.Write(elem + " "); };
            Console.WriteLine();
            for(int i = array.Length; i >= 0; i--) 
            {
                for(int j = 0; j < i-1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j];
                        array[j] = array[j + 1];
                        array[j + 1] = temp;
                    }
                }
            }
            Console.WriteLine("Sorted array:");
            foreach(var item in array)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

        }
    }
}
