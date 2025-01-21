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
                List<int> files = new List<int>() { 33, 34, 35, 46, 47, 48, 53, 63, 65, 71, 74, 76, 77 };
                foreach (int file in files)
                {
                    Console.WriteLine(file);
                }
                fileToRun = int.Parse(Console.ReadLine());

                Console.WriteLine("--------------------------------------------------");
                switch (fileToRun)
                {
                    case 33:
                        BList33 book33 = new BList33();
                        book33.Run();
                        break;
                    case 34:
                        BRandom34 book34 = new BRandom34();
                        book34.Run();
                        break;
                    case 35:
                        BRandom35 book35 = new BRandom35();
                        book35.Run();
                        break;
                    case 46:
                        BAlgorithms46 book46 = new BAlgorithms46();
                        book46.Run();
                        break;
                    case 47:
                        BAlgorithms47 book47 = new BAlgorithms47();
                        book47.Run();
                        break;
                    case 48:
                        BAlgorithms48 book48 = new BAlgorithms48();
                        book48.Run();
                        break;
                    case 53:
                        BContainers53 book53 = new BContainers53();
                        book53.Run();
                        break;
                    case 63:
                        BClass63 book63 = new BClass63();
                        book63.Run();
                        break;
                    case 65:
                        BInterface65 book65 = new BInterface65();
                        book65.Run();
                        break;
                    case 71:
                        BReference71 book71 = new BReference71();
                        book71.Run();
                        break;
                    case 74:
                        BIOAndJson74 book74 = new BIOAndJson74();
                        book74.Run();
                        break;
                    case 76:
                        BDelegate76 book76 = new BDelegate76();
                        book76.Run();
                        break;
                    case 77:
                        BLinq77 book77 = new BLinq77();
                        book77.Run();
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
