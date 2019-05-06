using System;

namespace Lesson2_Task3dop
{
    class Program
    {
        static void Main(string[] args)
        //Реализовать умножение и деление на 2 и 4 числа 16 используя операторы сдвига >> и << (т.е. без использования стандартных * /).
        {
            int n;
            int num = 16;
            Console.WriteLine($"Исходное число равно: {num}");
            n = num << 1;//умножение на 2.
            Console.WriteLine($"Число {num} после умножения на 2:\t{n}");
            n = num << 2;//умножение на 4.
            Console.WriteLine($"Число {num} после умножения на 4:\t{n}");
            n = num >> 1;//деление на 2.
            Console.WriteLine($"Число {num} после деления на 2:\t{n}");
            n = num >> 2;//деление на 4.
            Console.WriteLine($"Число {num} после деления на 4:\t{n}");
        }
    }
}
