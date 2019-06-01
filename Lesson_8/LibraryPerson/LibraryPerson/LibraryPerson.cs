using System;
using System.Collections.Generic; 

/*Создать класс Person, содержащий открытые свойства Name, Age, а также массив для хранения
списка книг Books.Т.е.экземпляр класса должен хранить «человека» и «список его книг».
Создать список типа List<Person> , содержащий список библиотечных должников. */ 

namespace LibraryPerson
{
    public class PersonDemo
    {
        public static void Main(string[] args)
        {
            // Создание коллекции в виде динамического массива, состоящей из читателей библиотеки
            List<Person> DebtLib = new List<Person>();

            // Создание и нициализация экземпляра класса Person
            Person p1 = new Person();
            p1.Name = "Вика";
            p1.Age = 35;
            p1.Books = new string[4];
            p1.Books[0] = "Шилдт";
            p1.Books[1] = "Дейтел";
            p1.Books[2] = "Стилмен";
            p1.Books[3] = "Нортроп";
            // Добавление созданного и проинициализированного элемента в коллекцию
            DebtLib.Add(p1);

            // Добавление пустого и непроинициализированного элемента  в коллекцию
            DebtLib.Add(new Person());
            // Инициализация добавленного в коллекцию элемента
            DebtLib[1].Name = "Коля";
            DebtLib[1].Age = 55;
            DebtLib[1].Books = new string[3];
            DebtLib[1].Books[0] = "Пушкин";
            DebtLib[1].Books[1] = "Толстой";
            DebtLib[1].Books[2] = "Лермонтов";

            // Создание и добавление нового экземпляра в коллекцию
            Person p2 = new Person();
            DebtLib.Add(p2);
            // Инициализациея доюавленного обьекта уже в коллекции
            p2.Name = "Маша";
            p2.Age = 41;
            p2.Books = new string[2] { "Донцова", "Маринина" };

            //Демонстрация содержимого коллекции

            foreach(Person p in DebtLib)
            {
                Console.WriteLine($"Имя читателя:\0{p.Name}");
                Console.WriteLine($"Возраст читателя:\0{p.Age}");
                Console.Write($"Перечень книг, которые не возвращены обратно в библиотеку:\0");
                for  (int i = 0; i < p.Books.Length; i++)
                {
                    Console.Write(p.Books[i]);
                    if ((i+1)!= p.Books.Length)
                        Console.Write(",");
                }
                Console.WriteLine($"\n");
            }
        }
    }
    public class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }

        public string[] Books;
    }

}
