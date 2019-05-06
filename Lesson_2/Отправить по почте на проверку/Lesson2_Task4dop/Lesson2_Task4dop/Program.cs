using System;

namespace Lesson2_Task4dop
{
    class Program
    {
        static void Main(string[] args)
        //Разобраться, почему (double)(0.3 / 0.2) = 1.4999999998, а не 1.5. Вывести в консоль именно результат деления, равный 1.4999999.
        {
            double a = 0.3f;
            Console.WriteLine($"число a = {a}");
            double b = 0.2f;
            Console.WriteLine($"число b = {b}");
            double div =(double)(a / b);
            Console.WriteLine($"Результат операции (double)(0.3 / 0.2)=\t{div}");
        }
    }
}
