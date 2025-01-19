using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Practice_CSharp.OfflineBook
{
    public class BInterface65
    {
        abstract class Person
        {
            public string Name { get; set; }
        }
        //CAN ONLY HAVE METHODS OR PROPERTY signatures
        interface ITeacher
        {
            string Subject { get; }
            void Teach();
        }
        class HistoryTeacher : Person, ITeacher
        {
            public string Subject
            {
                get { return "History"; }
            }
            public void Teach()
            {
                Console.WriteLine("Teaching: " + Subject);
            }
        }
        class GrammarTeacher: Person, ITeacher
        {
            public string Subject
            {
                get { return "Grammar"; }
            }
            public void Teach()
            {
                Console.WriteLine("Teaching: " + Subject);
            }
        }

        class MyClass<T> : IEnumerable<int>, IComparable where T : IComparable
        {
            List<int> m_list;
            int m_min;
            int m_max;
            public T Data { get; set; }
            public MyClass(T data)
            {
                Data = data;
            }
            public MyClass(Random random)
            {
                m_list = new List<int>();
                Console.Write("MyClass values: ");
                for (int i = 0; i < 10; i++)
                {
                    int value = random.Next(1, 11);
                    m_list.Add(value);
                    Console.Write(value + " ");
                }
                Console.WriteLine();
                m_min = m_list.Min();
                m_max = m_list.Max();
            }
            //IEnumerable
            public IEnumerator<int> GetEnumerator()
            {
                yield return m_min;
                yield return m_max;
            }
            IEnumerator IEnumerable.GetEnumerator()
            {
                return this.GetEnumerator();
            }
            //IComparable
            public int CompareTo(object obj)
            {
                if (obj is MyClass<T>)
                {
                    MyClass<T> myClass = obj as MyClass<T>;
                    if (this.m_min >= myClass.m_min && this.m_max >= myClass.m_max)
                    {
                        return 1;
                    }
                    else
                    {
                        return -1;
                    }
                }
                else throw new ArgumentException("Argument type is not valid!");
            }
            public int BiggerThanTen(T a)
            {
                return a.CompareTo(10);
            }
        }

        public void Run()
        {
            //Interface - Only methods inside the interface can be called
            ITeacher teacher = new GrammarTeacher();
            Console.WriteLine(teacher.Subject);
            teacher.Teach();

            //Find specific objects among different types
            List<object> crowd = new List<object> { 
                "someone looking for a job...",
                new object(),
                "thrash on the street",
                new GrammarTeacher(),
                new HistoryTeacher(),
            };
            List<ITeacher> teachers = new List<ITeacher>();
            foreach (object someOne in crowd) 
            { 
                if(someOne is ITeacher)
                {
                    teachers.Add(someOne as ITeacher);
                }
            }
            foreach (var item in teachers)
            {
                item.Teach();
            }

            //IEnumerable
            Random random = new Random();
            MyClass<int> myClass = new MyClass<int>(random);
            Console.WriteLine("Enumerating MyClass: ");
            foreach(int item in myClass)
            {
                Console.WriteLine(item);
            }

            //IComparable
            MyClass<int> hisClass = new MyClass<int>(random);
            if(myClass.CompareTo(hisClass) > 0)
            {
                Console.WriteLine("MyClass is larger.");
            }
            else
            {
                Console.WriteLine("HisClass is larger.");
            }

            //Generics
            MyClass<string> generic = new MyClass<string>("Something");
            foreach (var item in generic)
            {
                Console.WriteLine(item);
            }
        }
    }
}
