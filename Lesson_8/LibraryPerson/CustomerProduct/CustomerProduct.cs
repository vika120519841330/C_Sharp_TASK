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
            Store obj = new Store();
            // Заполнение коллекции Товарами
            obj.AddProduct(1, "Мобильные телефоны");
            obj.AddProduct(2, "Телевизоры");
            obj.AddProduct(3, "Магнитоллы");
            obj.AddProduct(4, "Ноутбуки");

            // Заполнение коллекции Покупателями
            obj.AddCustomer(1, "Иванов", "Иван");
            obj.AddCustomer(2, "Петров", "Петр");
            obj.AddCustomer(3, "Сидоров", "Федор");
            obj.AddCustomer(4, "Ветров", "Виталий");
            obj.AddCustomer(5, "Ильин", "Илья");

            obj.CurCust("Сидоров", "Федор");
            obj.BuyProduct("Телевизоры");
            obj.BuyProduct("Ноутбуки");
            

            obj.CurCust("Ветров", "Виталий");
            obj.BuyProduct("Мобильные телефоны");
            obj.BuyProduct("Телевизоры");
            obj.BuyProduct("Ноутбуки");
            

            obj.CurCust("Петров", "Петр");
            obj.BuyProduct("Мобильные телефоны");


            //obj.LogIn("Иванов", "Иван");


            //obj.LogIn("Ильин", "Илья");

            // Получить список товаров, которые приобретал определенный покупатель
            Console.WriteLine(obj.GetProdByCustName("Ветров", "Виталий"));
            Console.WriteLine(obj.GetProdByCustName("Иванов", "Иван"));
            Console.WriteLine(obj.GetProdByCustName("Сидоров", "Федор"));

            // Получить список покупателей, которые приобретали определенный товар
            Console.WriteLine(obj.GetCustByProdTitle("Мобильные телефоны"));
            Console.WriteLine(obj.GetCustByProdTitle("Телевизоры"));
            Console.WriteLine(obj.GetCustByProdTitle("Магнитоллы"));
            Console.WriteLine(obj.GetCustByProdTitle("Ноутбуки"));
        }
    }
        
    public class Product
    {
        public int ProdId { get; set; }
        public string ProdTitle { get; set; }

        
        // Коллекция покупателей, приобретавших определенный товар (список покупателей конкретного товара)
        private List<Customer> сastListOfProd = new List<Customer>();

        // Свойство для чтения из коллекции покупателей, приобретавших определенный товар 
        public List<Customer> СastListOfProd
        {
            get
            {
                return сastListOfProd;
            }
            set
            {
                сastListOfProd = value;
            }
        }

        // Конструктор, инициализирующий поля экземпляра объекта Товар
        public Product(int id, string pt)
        {
            ProdId = id; ProdTitle = pt;
        }

        // Метод для фиксации факта покупки определенного товара покупателем (пополняет коллекцию конкретного товара новыми покупателями, купившими его)
        public void BuyProduct(Customer c)
        {
            СastListOfProd.Add(c);
        }
    }
    public class Customer
    {
        public int CustomerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        // Коллекция товаров, купленных определенным покупателем 
        private List<Product> prodListOfCust = new List<Product>();

        // Свойство для чтения из коллекции товаров, купленных определенным покупателем
        public List<Product> ProdListOfCust
        {
            get
            {
                return prodListOfCust;
            }
            set
            {
                prodListOfCust = value;
            }
        }
        // Конструктор, иициализирующий поля экземпляра обьекта Покупатель
        public Customer(int id, string ln, string fn)
        {
            CustomerId = id; LastName = ln; FirstName = fn;
        }

        // Метод для фиксации факта покупки товара определенным покупателем (пополняет коллекцию конкретного покупателя новыми товарами, купленными им)
        public void BuyProduct(Product p)
        {
            ProdListOfCust.Add(p);
        }
    }
    public class Store
    {
        // Коллекция экземпляров объекта Товары
        List<Product> prodList = new List<Product>();

        // Коллекция экземпляров объекта Покупатели
        List<Customer> custList = new List<Customer>();

        // Обьявление экземпляра объекта Покупатели (текущее значение)
        Customer currentCust;

        // Метод для добавления в коллекцию Товары нового экземпляра
        public void AddProduct(int id, string pt)
        {
            prodList.Add(new Product(id, pt));
        }

        // Метод для добавления в коллекцию Покупатели нового экземпляра
        public void AddCustomer(int id, string ln, string fn)
        {
            custList.Add(new Customer(id, ln, fn));
        }

        // Метод для поиска покупателя по фамилии и имени
        public Customer GetCustByName(string ln, string fn)
        {
            foreach (Customer c in custList)
            {
                if ((c.LastName == ln) && (c.FirstName == fn))
                    return c;
            }
            return null;
        }
        // Метод для установки текущего указателя в коллекции Покупатели
        public void CurCust(string ln, string fn)
        {
                currentCust = GetCustByName(ln, fn);
        }

        // Метод для поиска товара по наименованию в коллекции Продукты
        public Product GetProdByTitle(string pt)
        {
            foreach (Product p in prodList)
            {
                if (p.ProdTitle == pt)
                    return p;
            }
            return null;
        }

        // Метод вызывает два других перегружаемых метода,  каждый из которых заполняет свою коллекцию необходимыми сведениями
        public void BuyProduct(string pt)
        {
            Product p = GetProdByTitle(pt);
            currentCust.BuyProduct(p); // пополнение индивидуальной коллекции Покупателя новыми Товарами
            p.BuyProduct(currentCust); // пополнение индивидуальной коллекции Товара новыми Покупателями
        }

        // Метод, который возвращает список товаров, купленных определенным покупателем
        public string GetProdByCustName(string ln, string fn)
        {
            Customer c = GetCustByName(ln, fn);
            string s = "Покупатель \0" + c.LastName + "\0" + c.FirstName + "\0" + "приобрел следующие группы товаров:\n";
            if (c.ProdListOfCust.Count != 0)
            {
                foreach (Product p in c.ProdListOfCust)
                {
                    s = s + p.ProdId + "\0" + p.ProdTitle + "\n";
                }
            }
            else
                s = s + "пока еще не приобрел ни одного товара" + "\n";
            return s;
        }

        // Метод, который возвращает список покупателей, которые приобретали указанный товар
        public string GetCustByProdTitle(string pt)
        {
            Product p = GetProdByTitle(pt);

            string s = "Товар \0" + p.ProdTitle + "\0"  + "был приобретен следующими покупателями:\n";
            if (p.СastListOfProd.Count != 0)
            {
                foreach (Customer c in p.СastListOfProd)
                {
                    s = s + c.CustomerId + "\0"+ c.LastName + "\0"+ c.FirstName + "\n";
                }
            }
            else
                s = s + "пока еще не был приобретен ни одним покупателем" + "\n";
            return s;
        }
    }
}
