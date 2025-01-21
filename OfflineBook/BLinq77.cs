using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace Practice_CSharp.OfflineBook
{
    public class BLinq77
    {
        class SomeType
        {
            public string Text { get; set; }
            public int Number { get; set; }
        }

        class Book
        {
            public string Title { get; set; }
            public string Author { get; set; }
            public int ReleaseYear { get; set; }
            public Book(string title, string author, int releaseYear)
            {
                Title = title;
                Author = author;
                ReleaseYear = releaseYear;
            }
            public override string ToString()
            {
                return String.Format("Title: {0}, Author: {1}, Release: {2}", Title, Author, ReleaseYear);
            }
        }

        public void Run()
        {
            //Compile time deduction
            var instance = new SomeType { Text = "Text", Number = 13 };
            //Runtime deduction
            dynamic ins = new SomeType { Text = "Something", Number = 14 };

            //Add properties during Runtime
            dynamic obj = new ExpandoObject();
            obj.FirstName = "John";
            obj.Age = 30;
            Console.WriteLine(obj.FirstName);
            Console.WriteLine(obj.Age);
            //Iterate through
            IDictionary<string, object> dictionary = obj as IDictionary<string, object>;
            foreach (var row in dictionary)
            {
                Console.WriteLine(String.Format("Property: {0}, Value: {1}", row.Key, row.Value));
            }
            //Add method during Runtime
            obj.GetBatmanName = (Func<string>)(() =>
            {
                return String.Format("{0} Batman", obj.FirstName);
            });
            Console.WriteLine(obj.GetBatmanName());

            //LINQ - Query Lists
            List<Book> books = new List<Book>();
            books.Add(new Book("Horror at midnight", "C. S. McDavid", 1995));
            books.Add(new Book("Who needs enemy, if I have friends?", "Colins Sorrow", 2010));
            books.Add(new Book("Things you cannot make without money.", "Colins Sorrow", 1990));
            books.Add(new Book("Fly, rocket fly!", "Elon Musk", 2030));
            books.Add(new Book("Ghost in the kernel", "III. Kevin D. Mitnick", 2045));
            books.Add(new Book("Blood of elves", "C. S. McDavid", 1985));
            books.Add(new Book("Unforgiven sins", "C. S. McDavid", 1990));
            books.Add(new Book("Martian blade", "C. S. McDavid", 2000));
            books.Add(new Book("Distant skies", "Elon Musk", 2045));
            IEnumerable<Book> mcdavidBooks = books.Where(x => x.Author == "C. S. McDavid");
            foreach (Book book in mcdavidBooks)
            {
                Console.WriteLine(book);
            }
            var mcdavidBookDatas = books.Where(x => x.Author == "C. S. McDavid")
                .Select(x => new { x.Title, x.ReleaseYear });
            foreach (var item in mcdavidBookDatas)
            {
                Console.WriteLine("Title: {0}, Release: {1}", item.Title, item.ReleaseYear);
            }
            var booksWithReleaseDates =
                from book in books
                    orderby book.ReleaseYear
                    select new { book.Title, book.ReleaseYear };
            foreach (var book in booksWithReleaseDates)
            {
                Console.WriteLine("{0}: {1}", book.Title, book.ReleaseYear);
            }
            //Getting one value
            int ghostInTheKernelRelease =
                (from book in books
                 where book.Title == "Ghost in the kernel"
                 select book.ReleaseYear)
                 .FirstOrDefault();
            Console.WriteLine("Ghost in the kernel release: {0}", ghostInTheKernelRelease);
            var firstBookOfElonMusk =
                (from book in books
                 where book.Author == "Elon Musk"
                 orderby book.ReleaseYear ascending
                 select book.Title).First();
            Console.WriteLine("Elon's first book: {0}", firstBookOfElonMusk);
            var q = from book in books
                    group book by book.Author into row
                    select new {Author = row.First().Author, Books = row.Count()};
            q.ToList().ForEach(x =>
            {
                Console.WriteLine("{0}: {1}", x.Author, x.Books);
            });
        }
    }
}
