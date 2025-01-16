using Practice_CSharp.OfflineBook;
using System;
using System.Collections.Generic;

namespace Practice_CSharp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int fileToRun;
            do
            {
                Console.WriteLine("Which file to run? (0 to exit!)");
                List<int> files = new List<int>() { 33, 34, 35 };
                foreach (int file in files)
                {
                    Console.WriteLine(file);
                }
                fileToRun = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------------------------------");
                switch (fileToRun)
                {
                    case 33:
                        Book33 book33 = new Book33();
                        book33.Run();
                        break;
                    case 34:
                        Book34 book34 = new Book34();
                        book34.Run();
                        break;
                    case 35:
                        Book35 book35 = new Book35();
                        book35.Run();
                        break;
                    default:
                        break;
                }
                Console.WriteLine("--------------------------------------------------");
            } while (fileToRun != 0);

            Console.ReadLine();
        }
    }
}
