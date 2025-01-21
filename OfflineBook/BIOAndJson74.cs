using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Http;
using System.Runtime.Serialization;

namespace Practice_CSharp.OfflineBook
{
    public class BIOAndJson74
    {
        public class Person
        {
            public string Name { get; set; }
            public int Age { get; set; }

            public Person(string name, int age) 
            {
                Name = name;
                Age = age;
            }
            public override string ToString()
            {
                return String.Format("Name: {0}, age: {1}", Name, Age);
            }
        }
        static List<Person> CreateData()
        {
            List<Person> result = new List<Person>();
            result.Add(new Person("James", 17));
            result.Add(new Person("Robert", 42));
            result.Add(new Person("Scarlet", 31));
            result.Add(new Person("Kathy", 8));
            return result;
        }

        //System.Runtime.Serialization
        [DataContract]
        public class PersonResponse
        {
            [DataMember(Name = "name")]
            public string Name { get; set; }
            [DataMember(Name = "height")]
            public int Height { get; set; }
            [DataMember(Name = "mass")]
            public int Mass { get; set; }
            [DataMember(Name = "birth_year")]
            public string BirthYear { get; set; }
            [DataMember(Name = "gender")]
            public string Gender { get; set; }
            [DataMember(Name = "homeworld")]
            public string Homeworld { get; set; }
            [DataMember(Name = "films")]
            public List<string> Films { get; set; }
        }

        public void Run()
        {
            //IO with .txt
            string path = @".\";
            string fileName = "persons.txt";
            string filePath = Path.Combine(path, fileName);
            List<Person> data;
            if(File.Exists(filePath))
            {
                data = new List<Person>();
                //using - Variable between () only needed in {}
                using(StreamReader streamReader = new StreamReader(filePath))
                {
                    string line;
                    while((line = streamReader.ReadLine()) != null)
                    {
                        string[] lineData = line.Split(';');
                        data.Add(new Person(lineData[0], int.Parse(lineData[1])));
                    }
                }
                foreach(Person person in data)
                {
                    Console.WriteLine(person.ToString());
                }
            }
            else
            {
                data = CreateData();
                using (StreamWriter streamWriter = new StreamWriter(filePath))
                {
                    foreach(Person person in data)
                    {
                        streamWriter.WriteLine(String.Format("{0};{1}", person.Name, person.Age));
                    }
                }
                Console.WriteLine("Test data created.");
            }

            //JSON(NuGet package) and REST API
            HttpClient client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(@"http://swapi.dev/api/people/1/").Result;
            string resultString = response.Content.ReadAsStringAsync().Result;
            var resultObject = JsonConvert.DeserializeObject(resultString);
            if(resultObject is JObject)
            {
                JObject jObject = resultObject as JObject;
                foreach(var item in jObject.Children())
                {
                    Console.WriteLine(item);
                }
            }
            PersonResponse personJson = JsonConvert.DeserializeObject<PersonResponse>(resultString);
            Console.WriteLine(personJson.Name);
            Console.WriteLine(personJson.Gender);
        }
    }
}
