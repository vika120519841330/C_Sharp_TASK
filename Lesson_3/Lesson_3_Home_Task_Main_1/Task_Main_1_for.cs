using System;

namespace Lesson_3_Home_Task_Main_1
{
    class Program
    /*Ввести с клавиатуры число n большее 0
    Вывести на экран все числа из диапазона от 0 до n, которые являются простыми.
    Продемонстрировать использование операторов for, break, continue.*/
    {
        static void Main(string[] args)
        {
            int num = 1;
            Console.WriteLine("Введите любое натуральное (положительное целое) число:");
            try { 
                num = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Веденное число не соответствует требованию: ЦЕЛОЕ ЧИСЛО");
                Console.WriteLine("Попробуйте ввести число еще раз!");
            }
            if (num <= 0)
            {
                Console.WriteLine("Веденное число не соответствует требованию: ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
                Console.WriteLine("Попробуйте ввести число еще раз!");
                return;//выход из метода Main при неудачной попытке ввести натуральное число
            }
            bool isSimpleNum = true;
            int i;
            int div;
            for (i = 2; i <= num; i++)
            {
                for (div = 2; div < i; div++)
                    if (i % div == 0)
                    {
                        isSimpleNum = false;
                        break;
                    }
                    else continue;
                if ((isSimpleNum == true)||(i == div))
                    Console.Write($"{i}  ");
            }
        }
    }
}
