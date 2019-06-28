//Создать 3х уровневой вложенности конструкцию try-catch, в которой реализованы следующие варианты «пробрасывания» пользовательского исключения MyException:
//созданный и брошенный exception на каждом уровне генерирует новый экземпляр exception, вкладывая через конструктор «текущий экземпляр» exception’a в поле
//InnerException нового создаваемого экземпляра.

using System;

namespace InnerTryCatch_Part_2
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass_1 obj_1 = new MyClass_1();
            try
            {
                obj_1.Meth_1();
            }
            catch (MyException exc)
            {
                Console.WriteLine($"Catch in Main(): \t{exc.Message}");
            }
            finally
            {
                Console.WriteLine("Finally in Main().\n");
            }
        }
    }
    class MyClass_1
    {
        public void Meth_1()
        {
            MyClass_2 obj_2 = new MyClass_2();
            try
            {
                obj_2.Meth_2();
            }
            catch(MyException exc)
            {
                Console.WriteLine($"Catch in Meth_1(): \t{exc.Message}");
                throw new MyException("Exception 3", exc); 
            }
            finally
            {
                Console.WriteLine("Finally in Meth_1().\n");
            }
        }
    }
    class MyClass_2
    {
        public void Meth_2()
        {
            
            try
            {
                throw new MyException("Exception 1");
            }
            catch (MyException exc)
            {
                Console.WriteLine($"Catch in Meth_2(): \t{exc.Message}");
                throw new MyException("Exception 2", exc);
            }
            finally
            {
                Console.WriteLine("Finally in Meth_2().\n");
            }
        }
    }
    class MyException :Exception
    {
        public MyException(string exc) : base (exc)
        {
            Console.WriteLine("Constructor MyException(string)");
        }
        public MyException(string exc, MyException inner) : base(exc, inner)
        {
            Console.WriteLine("Constructor MyException(string, Exception inner)");
        }
    }
}

