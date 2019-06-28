/* Создать пользовательский класс Person, с полями Age, Name, и выполнить инициализацию полей экземпляра класса через параметризованный конструктор.
При инициализации полей экземпляра класса выполнять проверку соответствия возраста установленным границам: не младше 18 лет и не старше 95 лет. При несоответствии возраста
указанным границам пробрасывать пользовательское исключение AgeUserException. В вызывающем коде выполнять обработку исключений, предполагая, что при
«регистрации»/создании пользователя могут возникнуть исключения типа DivideByZeroException, AgeUserException и другие (заранее неизвестные).
Предусмотреть обработку всех вышеперечисленных вариантов*/

using System;

namespace Lesson_14_HomeTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Title = MyClass.Title;

            Console.ForegroundColor = ConsoleColor.DarkMagenta;

            new MyClass();

            Console.ReadLine();
        }
    }

    class MyClass
    {
        static public string Title = "Демонстрация перехвата и обработки исключений";
        public MyClass()
        {
            int a = 18;
            try
            {
                try
                {
                    try
                    {
                        try
                        {
                            Person p1 = new Person("Сидоров А.А.", 55);
                            //Person p2 = new Person("Иванов И.А.", 17);
                            Person p3 = new Person("Петров А.А.", 20 /(a - 18));
                            //Person p4 = new Person(null, 99); // НИКАК НЕ ПОЛУЧАЕТСЯ СДЕЛАТЬ ТАК, ЧТОБЫ ОБА ИСКЛЮЧЕНИЯ ПЕРЕХВАТЫВАЛИСЬ((
                        }
                        catch (NullReferenceException  exc)
                        {
                            Console.WriteLine("Все поля формы регистрации д.б. заполнены!");
                            Person.MessageBox(exc);
                        }
                    }
                    catch (DivideByZeroException exc)
                    {
                        Console.WriteLine("На ноль делить нельзя!");
                        Person.MessageBox(exc);
                    }
                }
                catch (AgeUserException exc)
                {
                    Console.WriteLine("Указанный возраст не входит в диапазон допустимых значений!");
                    Person.MessageBox(exc);
                }
            }
            catch (Exception exc)
            {
                Console.WriteLine("Какая-то неизвестная ошибка! Убедитесь в корректности заполнения формы регистрации!");
                Person.MessageBox(exc);
            }
        }
    }  

    class AgeUserException : Exception
    {
        public AgeUserException(string mess) : base(mess)
        {
            Console.WriteLine("Исключение типа AgeUserException");
        }
        public override string ToString()
        {
            return Message;
        }
    }

    class Person
    {
        private string name;
        private int age;
        public static int n;
        public string NamePerson
        {
            get
            {
                return name;
            }
            set
            {
                if (value == null)
                    throw new NullReferenceException("Для успешного выполнения регистрирации ОБЯЗАТЕЛЬНО необходимо " +
                                                                            "указать имя пользователя!!\n");
                else
                    name = value;
            }
        }
        public int AgePerson
        {
            get
            {
                return age;
            }
            set
            {
                if ((value < 18) || (value > 95))
                    throw new AgeUserException("Возраст регистрируемого пользователя должен быть не младше 18 и не старше 95 лет!!\n");
                else
                    age = value;
            }

        }
        public Person(string name, int age)
        {
            n++;
            Console.WriteLine($"Попытка регистрации пользователя класса\0{this.GetType().Name}\0№{n}:");
            this.NamePerson = name;
            this.AgePerson = age;
            this.ShowPerson();
        }
        public void ShowPerson()
        {
            Console.WriteLine($"Имя пользователя:\t{this.NamePerson},\nвозраст:\0{this.AgePerson}\n");
        }
        public static void MessageBox(Exception exc)
        {
            Console.WriteLine($"\nПодробности исключительной ситуации\0{exc.GetType().Name}:" +
                                                                $"\n\nSource:\t{exc.Source}" +
                                                                $"\n\nMessage:\t{exc.Message}" +
                                                                $"\n\nTargetSite:\t{ exc.TargetSite}" +
                                                                $"\n\nStackTrace:\t{ exc.StackTrace}" +
                                                                $"\n\nexc:\t{exc}\n");
        }
    }
}