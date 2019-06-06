using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Book b1 = new Book("Русские народные сказки", "Автор неизвестен", 2011);
            Book b2 = new Book("Руслан и Людмила", "Пушкин А.С.", 1984);
            Book b3 = new Book("Мертвые души", "Гоголь Н.В.", 2010);
            Book b4 = new Book("Преступление и наказание", "Достоевский Ф.М.", 1999);
            Book b5 = new Book("Мастер и маргарита", "Будгаков М.А.", 2011);

            Person p1 = new Person("Вика", 35);
            Person p2 = new Person("Коля", 21);
            Person p3 = new Person("Лера", 67);

            p1.AddBookInPersonBookList(b2);
            p1.AddBookInPersonBookList(b5);
            p2.AddBookInPersonBookList(b1);
            p2.AddBookInPersonBookList(b2);
            p2.AddBookInPersonBookList(b1);
            p3.AddBookInPersonBookList(b3);


            DateTime date1 = new DateTime(2015, 7, 20);
            DateTime date2 = new DateTime(2015, 6, 24);
            DateTime date3 = new DateTime(2014, 9, 2);

            Dictionary<DateTime, Person> DebtLibByDate = new Dictionary<DateTime, Person>();

            DebtLibByDate.Add(date1, p1);
            DebtLibByDate.Add(date2, p2);
            DebtLibByDate.Add(date3, p2);

            List<Person> DebtLibByName = new List<Person>();

            DebtLibByName.Add(p1);
            DebtLibByName.Add(p2);
            DebtLibByName.Add(p3);

            Console.WriteLine("Демонстрация списка должников библиотеки №1\n");

            // Получение коллекции ключей
            ICollection<DateTime> dkeys = DebtLibByDate.Keys;
            // Использовать ключи для получения значений(т.е. персоональных данных читателей)
            foreach (DateTime d in dkeys)
            {
                Console.WriteLine($"Дата посещения:\0{d.Date}");
                Console.WriteLine($"Имя читателя:\0{DebtLibByDate[d].NamePerson}");
                Console.WriteLine($"Возраст читателя:\0{DebtLibByDate[d].AgePerson}");
                Console.WriteLine($"Перечень книг, которые не возвращены обратно в библиотеку:\0");
                for (int i = 0; i < DebtLibByDate[d].PersonBookList.Count; i++)
                    Console.WriteLine($"{i + 1}) {DebtLibByDate[d].PersonBookList[i].TitleBook}, {DebtLibByDate[d].PersonBookList[i].AuthorBook}," +
                        $" {DebtLibByDate[d].PersonBookList[i].YearBook}");
                Console.WriteLine($"\n");
            }


            Console.WriteLine("Демонстрация списка должников библиотеки №2\n");

            foreach (Person p in DebtLibByName)
            {
                Console.WriteLine($"Имя читателя:\0{p.NamePerson}");
                Console.WriteLine($"Возраст читателя:\0{p.AgePerson}");
                Console.WriteLine($"Перечень книг, которые не возвращены обратно в библиотеку:\0");
                for (int i = 0; i < p.PersonBookList.Count; i++)
                    Console.WriteLine($"{i+1}) {p.PersonBookList[i].TitleBook}, {p.PersonBookList[i].AuthorBook}, {p.PersonBookList[i].YearBook}");
                Console.WriteLine($"\n");
            }
        }
    }
    class Person
    {
        public List<Book> PersonBookList = new List<Book>(1);
        public string NamePerson { get; set; }
        public int AgePerson { get; set; }

        public Person(string n, int y)
        {
            NamePerson = n;
            AgePerson = y;
        }
        public void AddBookInPersonBookList(Book b)
        {
            this.PersonBookList.Add(b);
        }
    }
    class Book
    {
        public Book (string t, string a, int y)
        {
            TitleBook = t;
            AuthorBook = a;
            YearBook = y;
        }
        public string TitleBook { get; set; }
        public string AuthorBook { get; set; }
        public int YearBook { get; set; }
    }
}
