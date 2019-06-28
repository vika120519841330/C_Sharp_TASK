//Создать 3х уровневой вложенности конструкцию try-catch, в которой реализованы следующие варианты «пробрасывания» пользовательского исключения MyException:
//cозданный и брошенный exception проходит всю цепочку и обрабатывается на исходном catch-уровне

using System;

namespace InnerTryCatch_Part_1
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
                Console.WriteLine($"Catch in Main: {exc.Message}");
            }
            finally
            {
                Console.WriteLine($"Блок finally в Main.\n");
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
            catch (MyException exc)
            {
                Console.WriteLine($"Catch in Meth_1: {exc.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Блок finally в Meth_1.\n");
            }
        }
    }
    class MyClass_2
    {
        public void Meth_2()
        {
            try
            {
                throw new MyException("Exception !!");
            }
            catch (MyException exc)
            {
                Console.WriteLine($"Catch in Meth_2: {exc.Message}");
                throw;
            }
            finally
            {
                Console.WriteLine($"Блок finally в Meth_2().\n");
            }
        }
    }
    class MyException : Exception
    {
        public MyException(string exc) : base(exc)
        {
            Console.WriteLine("Constructor MyException(string)");
        }
    }
}

