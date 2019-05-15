using System;

namespace Lesson_3_Task_Main
{
    class MyException : Exception {
        public MyException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class SimpleNum
        /*Ввести с клавиатуры число n большее 0
        Вывести на экран все числа из диапазона от 0 до n, которые являются простыми.
        Продемонстрировать использование цикла while.*/
    {
        int num;
        public SimpleNum()
        {
            //конструктор по умолчанию
        }
        public int Number
        {
            get
            {
                return num;
            }
            set
            {
                if (value <= 0)
                    throw new MyException("Веденное число не соответствует требованию: ПОЛОЖИТЕЛЬНОЕ ЧИСЛО");
                else num = value;
            }
        }
        public bool IsSimpleNum(int k)
        {
            int n = k;
            bool flag = true;
            for (int j = 2; (j <= n) && (flag); j++)
            {
                if ((n % j == 0)&&(j != n))
                {
                    flag = false;
                    return flag;
                }     
            }
            return flag;
        }
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("Введите любое положительное целое число:");
                SimpleNum obj_1 = new SimpleNum();
                try
                { 
                obj_1.Number = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("Веденное число не соответствует требованию: ЦЕЛОЕ ЧИСЛО");
                } 
                int i = 2;
                while (i <= obj_1.Number)
                    {
                    if (obj_1.IsSimpleNum(i))
                        Console.Write(i + " ");
                    i++;
                    }
            }catch (MyException exc)
            {
                Console.WriteLine(exc);
                Console.WriteLine("Попробуйте ввести число еще раз!");
            }
        }
    }
}
