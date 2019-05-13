using System;

namespace Lesson2_Task2dop
{
    class TransformEvenInOdd
    {
        static void Main(string[] args)
        {
            //Реализовать алгоритм, преобразующий все нечетные числа в четные в диапазоне от 0 до 25 c помощью поразрядного оператора &.
            int number;
            for (int i=0; i<26; i++)
            {
                number = i;
                Console.WriteLine($"Преобразуемое число: {number}");
                number = (number & 0xFFFE);//число 0xFFFE в 16-ричной СС соответствует 1111 1111 1111 1110 в двоичной СС
                Console.WriteLine($"Число после преобразования: {number}\n");
            }  
        }
    }
}
