using System;
/*1
Создать массив размерностью N элементов, заполнить его произвольными целыми
значениями.
Вывести:
наибольшее значение массива,
наименьшее значение массива,
общую сумму элементов,
среднее арифметическое всех элементов,
вывести все нечетные значения.*/
namespace Lesson_4_Home_Tasks_Main
{
    class ArrMinMaxSumMiddleSortDemo
    {
        static void Main(string[] args)
        {
            //Создадим массив из десяти элементов и заполним его случайными числами в диапазоне integer
            int[] arr = new int[10];
           Random rnd = new Random();
           for (int i =  0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(-32768, 32767);
            }
            Console.Write("Исходный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
            Console.WriteLine();

            //Отсортируем исходный массив (методом booble sort) и выведем результат на консоль
            int k;
            for (int i = 1; i < arr.Length; i++)
            {
                for (int j = arr.Length-1; j >= i; j--)
                    if (arr[j - 1] > arr[j])
                    {
                        k = arr[j];
                        arr[j] = arr[j - 1];
                        arr[j - 1] = k;
                    }
            }

            Console.Write("Отсортированный массив: ");
            for (int i = 0; i < arr.Length; i++)
            {
                Console.Write($"{arr[i]}  ");
            }
            Console.WriteLine();

            //Найдем минимальный и максимальный элементы массива
            int min = arr[0];
            int max = arr[arr.Length - 1];
            Console.WriteLine($"Наименьший элемент массива равен: {min}");
            Console.WriteLine($"Наибольший элемент массива равен: {max}");

            //Найдем общую сумму и среднее арифметическое всех элементов массива
            int sum = 0;
            int num = arr.Length;
            double middle;
            for (int i = 0; i < arr.Length; i++)
            {
                sum = sum + arr[i];
            }
            middle = sum / num;
            Console.WriteLine($"Сумма всех элементов массива равна: {sum}");
            Console.WriteLine($"Среднее арифметическое всех элементов массива равно: {middle}");

            //Выведем на консоль все нечетные значения массива
            Console.Write("Нечетные элементы массива: ");
            for (int i = 0; i < arr.Length; i++)
            {
                if (arr[i] % 2 != 0)
                    Console.Write($"{arr[i]}   ");
            }
            Console.WriteLine();

        }
    }
}
