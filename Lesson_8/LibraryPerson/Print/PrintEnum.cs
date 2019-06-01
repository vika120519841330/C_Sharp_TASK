using System;
/*Создайте статический класс с методом void Print (string stroka, int color), который выводит на экран строку заданным цветом.
Используя перечисление, создайте набор цветов,доступных пользователю.
Ввод строки и выбор цвета предоставьте пользователю. Console.ForegroundColor ConsoleColor.Blue*/
namespace Print
{
    // Перечисление, содержащее список доступных для пользователя цветов
    enum ColorEnum : int { Green = 1, Red, Blue };
    class PrintColorDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите текст, который Вы хотите вывести на экран:\0");
            string stroka = Console.ReadLine();
            Console.WriteLine("Введите числовое представление заданного цвета:\0" +
                "1 - зеленый, 2 - красный, 3 - синий");
            int color;
            try
            {
            color = Int32.Parse(Console.ReadLine());
            PrintColor.Print(stroka, color);
            }
            catch (Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
    public static class PrintColor
    {
        // Метод, который выводит на экран строку заданным цветом
        public static void Print(string stroka, int color)
        {
            // Создание и инициализация переменной перечислимого типа значеним целочисленного типа, предварительно приведенным к перечислимому типу

            ColorEnum col = (ColorEnum)color;

            switch (col)
            {
                    case ColorEnum.Green:
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.WriteLine(stroka);
                        break;
                    case ColorEnum.Red:
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.Write(stroka);
                        break;
                    case ColorEnum.Blue:
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write(stroka);
                        break;
                    default:
                    throw new Exception("НЕОБХОДИМО ВЫБРАТЬ ОДИН ИЗ ПРЕДЛОЖЕННЫХ ВАРИАНТОВ ЦВЕТОВ !!");
            }
        }
    }
}
