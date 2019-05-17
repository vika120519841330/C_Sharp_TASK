using System;
/*Создать одномерный массив из 10 чисел типа int ,
проинициализировать его как отрицательными, так и положительными числами,
выполнить сортировку массива(использовать именно «ручной труд» и циклы,
а не встроенные средства класса Array для сортировки).*/

namespace Lesson_4_Home_Task_Main_2
{
    class ArrSortDemo
    {
        static void Main(string[] args)
        {
            //Сформируем и заполним случайными числами одномерный массив из 10 элементов
            Console.Write("Исходный массив:");
            int[] arr = new int[10];
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-32768, 32767);
                Console.Write($"  {arr[i]}");
            }
            Console.WriteLine();

            //Отсортируем исходный массив методом вставок
            
            for(int i = 1; i < arr.Length; i++)
            {
                int k = arr[i];
                int j = i; 
                while ((j > 0)&&(arr[j - 1] > k))
                {
                    arr[j] = arr[j - 1];
                    j = j - 1;
                }
                arr[j] = k;
            }
             
            //Выведем отсортированный массив на консоль
            Console.Write("Отсортированный по возрастанию массив:");
            for (int i =0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
            Console.WriteLine();
        }
    }
}
