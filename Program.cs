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
                List<int> files = new List<int>() { 33, 34, 35, 46, 47, 48 };
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
                    case 46:
                        Book46 book46 = new Book46();
                        book46.Run();
                        break;
                    case 47:
                        Book47 book47 = new Book47();
                        book47.Run();
                        break;
                    case 48:
                        Book48 book48 = new Book48();
                        book48.Run();
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
