using System;
using System.ComponentModel;

namespace Practice_CSharp.OfflineBook
{
    public class BClass63
    {
        private class Dog
        {
            string m_name;
            int m_age;
            public static int NumberOfDogs = 0;
            public int Age { get { return m_age; } set { m_age = value; } }

            public Dog(string name)
            {
                m_name = name;
                m_age = 5;
                NumberOfDogs++;
            }
            //                               GETS CALLED FIRST
            public Dog(string name, int age) : this(name)
            {
                m_age = age;
            }
            
            public void InitNumberOut(out int number)
            {
                //Here number needs to be initialized
                number = m_age;
            }
            public void AddAgeToNumber(ref int number)
            {
                number += m_age;
            }
        }

        //INHERITANCE
        abstract class Animal
        {
            public abstract void Walk();
            public virtual void MakeSound()
            {
                Console.WriteLine("An animal making sound.");
            }
        }
        class Mammal : Animal
        {
            int m_numberOfLegs;

            public Mammal(int numberOfLegs)
            {
                m_numberOfLegs = numberOfLegs;
            }
            public void PrintNumberOfLegs()
            {
                Console.WriteLine($"Number of legs: {m_numberOfLegs}");
            }
            public override void Walk()
            {
                Console.WriteLine("Some mammal walking...");
            }
            public override void MakeSound()
            {
                base.MakeSound();
                Console.WriteLine("Some mammal making sound.");
            }
            public void Eat()
            {
                Console.WriteLine("A mammal eats.");
            }
        }
        class Cat : Mammal
        {
            string m_name;
            public Cat(string name) : base(4)
            {
                m_name = name;
            }
            public new void MakeSound()
            {
                base .MakeSound();
                Console.WriteLine("MIAU!");
            }
            public new void Eat()
            {
                base.Eat();
                Console.WriteLine("A cat eats.");
            }
            public override bool Equals(object obj)
            {
                //if(obj.GetType() == typeof(Cat)) CHECKS IT'S THE SAME CLASS
                if(obj is Cat) //SAME CLASS OR CHILD CLASS
                {
                    Cat cat = obj as Cat;
                    if(cat.m_name == this.m_name)
                    {
                        return true;
                    }
                }
                return false;
            }
        }

        public void Run()
        {
            //Classes
            Dog buddy = new Dog("buddy", 2);
            Dog jack = new Dog("jack");
            Console.WriteLine("Number of dogs: " + Dog.NumberOfDogs);
            
            int number;
            buddy.InitNumberOut(out number); //needs no initial value
            buddy.AddAgeToNumber(ref number); //NEEDS initial value
            Console.WriteLine("buddy's age * 2: " + number);
            Console.WriteLine("jack's age: " + jack.Age);

            //Inheritance
            Mammal m = new Cat("caty");
            m.PrintNumberOfLegs();
            //virtual methods
            Animal a = new Mammal(2);
            Animal a2 = new Cat("Brian");
            a.MakeSound();
            a2.MakeSound();
            //hidden methods with new keyword - Seems to be the default!
            Mammal mammal = new Cat("stinky");
            mammal.Eat();
        }
    }
}
