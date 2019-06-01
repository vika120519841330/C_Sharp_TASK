using System;
using System.Collections.Generic;

/*Создайте коллекцию, в которую можно добавлять покупателей пользовательского типа Customer.
Из коллекции можно получать категории товаров, которые купил покупатель или по категории определить покупателей.*/
namespace Customer
{
    class Program
    {
        static void Main(string[] args)
        {
            // Создание и инициализации коллекции категорий товаров
            List<Product> prodList = new List<Product>();

            // Создание, инициализация и добавление экземпляра №1 в коллекцию Товары
            Product p1 = new Product();
            prodList.Add(p1);
            // Инициализация добавленного обьекта, уже находящегося в коллекции
            p1.ProductId = 1;
            p1.ProductName = "Мобильные телефоны";

            // Создание, инициализация и добавление экземпляра №2 в коллекцию Товары
            Product p2 = new Product();
            prodList.Add(p2);
            // Инициализация добавленного обьекта, уже находящегося в коллекции
            p2.ProductId = 2;
            p2.ProductName = "Телевизоры";

            // Создание и инициализации коллекции покупателей
            List<Customer> customList = new List<Customer>();

            // Создание, инициализация и добавление экземпляра №1 в коллекцию Покупатели
            Customer c1 = new Customer();
            customList.Add(c1);
            // Инициализация добавленного обьекта, уже находящегося в коллекции
            c1.CustomerId = 1;
            c1.FirstName = "Иван";
            c1.LastName = "Иванов";

            // Создание, инициализация и добавление экземпляра №2 в коллекцию Покупатели
            Customer c2 = new Customer();
            customList.Add(c2);
            // Инициализация добавленного обьекта, уже находящегося в коллекции
            c2.CustomerId = 2;
            c2.FirstName = "Петр";
            c2.LastName = "Петров";

            p1.Customers = customList;
            c1.Products = prodList;

            for (int i = 0; i < customList.Count; i++)
            {
                Console.WriteLine($"Покупатель\0{customList[i].CustomerId}\0{customList[i].FirstName}\0{customList[i].LastName}\0 " +
                    $"приобрел следующие группы товаров:");
                for (int j = 0; j < prodList.Count; j++)
                {
                    Console.WriteLine($"{prodList[j].ProductId}\0{prodList[j].ProductName} ");
                }
            }

            Console.WriteLine("\n");

            for (int i = 0; i < prodList.Count; i++)
            {
                Console.WriteLine($"Товар: {prodList[i].ProductId}\0{prodList[i].ProductName}\0" +
                    $"был приобретен следующими покупателями:");
                for (int j = 0; j < customList.Count; j++)
                {
                    Console.WriteLine($"{customList[j].CustomerId}\0{customList[j].FirstName}\0{customList[j].LastName}");
                }
            }
        }
        public class Customer
        {
            public int CustomerId { get; set; }
            public string FirstName { get; set; }
            public string LastName { get; set; }

            // Заказанные покупателем товары (доступ через автосвойство, которое имеет тип коллекции)
            public List<Product> Products { get; set; }

            // Конструктор пользовательский, инициализирующий свойство коллекцией товаров
            public Customer()
            {
                //Products = new List<Product>();
            }
        }

        public class Product
        {
            public int ProductId { get; set; }
            public string ProductName { get; set; }

            // Список покупателей, заказавших этот товар (доступ через автосвойство, которое имеет тип коллекции)
            public List<Customer> Customers { get; set; }

            // Конструктор пользовательский, инициализирующий свойство коллекцией товаров
            public Product()
            {
                //Customers = new List<Customer>();
            }
        }
    }
}
