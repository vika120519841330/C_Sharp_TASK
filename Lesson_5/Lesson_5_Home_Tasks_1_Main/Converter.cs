using System;
/*Напишите программу, которая будет выполнять конвертирование валют.
Пользователь вводит:
сумму денег в определенной валюте.
курс для конвертации в другую валюту.
Организуйте вывод результата операции конвертирования валюты на экран.*/
namespace Lesson_5_Home_Tasks_1_Main
{
    class ConverterDemo
    {
        static void Main(string[] args)
        {
            double sum = 0;
            double kurs = 1;
            double res = 1;
            Console.WriteLine("Введите сумму валюты, которую хотите отконвертировать:");
            sum = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введите курс конвертации:");
            kurs = Convert.ToDouble(Console.ReadLine());
            Converter usa = new Converter();
            res = Math.Round((usa.ConvertMeth(sum, kurs)), 2);
            Console.WriteLine($"Результат конвертации {sum:n2} $ равен {res:n} BYN");
        }
    }
    class Converter
    {
        public Converter()
        {
            Sum = 0;
            Kurs = 1;
            Res = 0;
        }
        public double Sum { get; set; }
        public double Kurs { get; set; }
        public double Res { get; set; }
        public double ConvertMeth(double s, double k)
        {
            this.Sum = s;
            this.Kurs = k;
            this.Res = (double)Sum * (double)Kurs;
            return this.Res;
        }
    }
}
