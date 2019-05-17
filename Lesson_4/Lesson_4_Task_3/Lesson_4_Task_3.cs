using System;
/*Создать квадратную диагональную единичную матрицу размерности 7 х 7 элементов и
вывести ее на экран(в консоль).*/
namespace Lesson_4_Task_3
{
    class Matrix
    {
        static void Main(string[] args)
        {
            int[,] arr = new int [7, 7];
            Console.WriteLine($"Двумерный массив элементов 7х7:");
            for (int i = 0; i < 7; i++)
            {
                for (int j = 0; j < 7; j++)
                {
                    if (i == j)
                        arr[i, j] = 1;
                    else
                        arr[i, j] = 0;
                    Console.Write($"{arr[i, j]}    ");
                }
                Console.WriteLine("\n");
            }
        }
    }
}
