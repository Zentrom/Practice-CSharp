using System;
using System.Collections;
using System.Collections.Generic;

namespace Practice_CSharp.OfflineBook
{
    public class BContainers53
    {
        List<KeyValuePair<string, int>> usersData = new List<KeyValuePair<string, int>>();

        string ReadPassword()
        {
            string result = string.Empty;
            //ConsoleKeyInfo keyInfo;
            //while ((keyInfo = Console.ReadKey(true)).Key != ConsoleKey.Enter)
            //{
            //    Console.Write("*");
            //    result += keyInfo.KeyChar.ToString();
            //}
            //Console.WriteLine();
            result = "ASDFGH";
            return result;
        }

        KeyValuePair<string, int> GetUserCredentials(string userName, string password)
        {
            return new KeyValuePair<string, int>(userName, password.GetHashCode());
        }

        bool ValidateUser(string userName) 
        {
            foreach (KeyValuePair<string,int> item in usersData)
            {
                if (item.Key == userName)
                {
                    return true;
                }
            }
            return false;
        }

        bool CheckPassword(int givenHash, int storedHash)
        {
            return givenHash == storedHash;
        }

        public void Run()
        {
            //Stack
            Stack<KeyValuePair<int, string>> browserHistory = new Stack<KeyValuePair<int, string>>();
            string[] urls = { "facebok.com", "youtube.com", "gmail.com", "stackoverflow.com" };
            for (int i = 0; i < urls.Length; i++)
            {
                KeyValuePair<int, string> current = new KeyValuePair<int, string>(i, urls[i]);
                browserHistory.Push(current);
                Console.WriteLine("{0} was pushed to stack with id {1}", current.Value, current.Key);
            }
            for (int i = 0;i < urls.Length; i++)
            {
                KeyValuePair<int, string> current = browserHistory.Pop();
                Console.WriteLine("Reading: url: {0}, stack id: {1}", current.Value, current.Key);
            }

            //LinkedList
            LinkedList<string> dwarves = new LinkedList<string>();
            LinkedListNode<string> thorin = new LinkedListNode<string>("Thorin");
            LinkedListNode<string> fili = new LinkedListNode<string>("Fili");
            LinkedListNode<string> kili = new LinkedListNode<string>("Kili");
            LinkedListNode<string> balin = new LinkedListNode<string>("Balin");
            LinkedListNode<string> dwalin = new LinkedListNode<string>("Dwalin");
            LinkedListNode<string> oin = new LinkedListNode<string>("Oin");
            LinkedListNode<string> gloin = new LinkedListNode<string>("Gloin");
            dwarves.AddFirst(thorin);
            dwarves.AddAfter(thorin, fili);
            dwarves.AddAfter(fili, kili);
            dwarves.AddBefore(kili, dwalin);
            dwarves.AddBefore(kili, oin);
            dwarves.AddLast(gloin);
            dwarves.AddLast(balin);
            LinkedListNode<string> currentDwarf = dwarves.First;
            while(currentDwarf != null)
            {
                string nextName = currentDwarf.Next == null ? "empty" : currentDwarf.Next.Value;
                string previousName = currentDwarf.Previous == null ? "empty" : currentDwarf.Previous.Value;
                Console.WriteLine("Current dwarf: {0}, Next: {1}, Previous: {2}",
                    currentDwarf.Value, nextName, previousName);
                currentDwarf = currentDwarf.Next;
            }

            //HashSet - (StartAdress + Value = Index)
            HashSet<string> hashSet = new HashSet<string>();
            hashSet.Add("1. item");
            hashSet.Add("2. item");
            hashSet.Add("3. item");
            hashSet.Add("4. item");
            foreach(string item in hashSet) { Console.WriteLine(item); }
            bool hashSetContainsFirstItem = hashSet.Contains("1. item");
            bool hashSetContainsFifthItem = hashSet.Contains("5. item");
            Console.WriteLine("The HashSet contains {0} elements.", hashSet.Count);

            //Login Program using hashed password
            Console.WriteLine("*Welcome to wonderland.*");
            Console.WriteLine("Please register.");
            Console.Write("Name: ");
            string name = "Zentrom"; //Console.ReadLine()
            Console.WriteLine(name);
            Console.Write("Password: ");
            string password = ReadPassword();
            Console.WriteLine(password);
            usersData.Add(GetUserCredentials(name, password));
            Console.WriteLine("Registration completed.");
            Console.WriteLine("Please sign in with your password.");
            bool signedIn = false;
            while (!signedIn)
            {
                Console.Write("Name: ");
                string temp_userName = "Zentrom"; //Console.ReadLine();
                Console.WriteLine(temp_userName);
                Console.Write("Password: ");
                string temp_password = ReadPassword();
                Console.WriteLine(temp_password);
                if (ValidateUser(temp_userName))
                {
                    int userPasswordHash = 0;
                    foreach(KeyValuePair<string,int> item in usersData)
                    {
                        if(item.Key == temp_userName)
                        {
                            userPasswordHash = item.Value;
                        }
                    }
                    if(CheckPassword(temp_password.GetHashCode(), userPasswordHash))
                    {
                        signedIn = true;
                        Console.WriteLine("Welcome to wonderland.");
                        break;
                    }
                }
                Console.WriteLine("Incorrect name or password.");
            }


        }
    }
}
