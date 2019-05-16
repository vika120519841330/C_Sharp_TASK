using System;

namespace Lesson_3_Home_Task_Main_3
{
    class TrafficLight
    {
        public string sign; //сигнал светофора
        public bool operable; //исправность светофора
        public bool changeSign; //смена сигнала светофора
        public bool safe; //безопасность пересечения зоны ПП 
        public int choice; // поле случайного выбора одного варианта из нескольких
        public string Signal(int ch)
        {
            int value = ch;
            switch (value)
            {
                case 1:
                    sign = "red";
                    Console.WriteLine("Сигнал светофора КРАСНЫЙ");
                    break;
                case 2:
                    sign = "yello";
                    Console.WriteLine("Сигнал светофора ЖЕЛТЫЙ");
                    break;
                case 3:
                    sign = "green";
                    Console.WriteLine("Сигнал светофора ЗЕЛЕНЫЙ");
                    break;
            }
            return sign;
        }
        public bool Operability(int ch)
        {
            int value = ch;
            if (value == 1)
            {
                operable = true;
                Console.WriteLine("ДА! Светофор исправен");
            }
            else if (value == 2)
            {
                operable = false;
                Console.WriteLine("НЕТ! Светофор НЕ исправен");
            }
            return operable;
        }
        public bool ChangeSignal(int ch)
        {
            int value = ch;
            if (value == 1)
            {
                changeSign = true;
                Console.WriteLine("Сигнал светофора сменил цвет");
            }
            else if (value == 2)
            {
                changeSign = false;
                Console.WriteLine("Сигнал светофора НЕ сменил цвет");
            }
            return changeSign;
        }
        public bool Safety(int ch)
        {
            int value = ch;
            if (value == 1)
            {
                safe = true;
                Console.WriteLine("Пересечение зоны ПП безопасно");
            }
            else if (value == 2)
            {
                safe = false;
                Console.WriteLine("Пересечение зоны ПП НЕ безопасно");
            }
            return safe;
        }
        public int RendomChoice_1_2()
        {
            Random rand = new Random();
            choice = rand.Next(1, 2);
            Console.WriteLine($"Поле случайного выбора = {choice}");
            return choice;
        }
        public int RendomChoice_1_2_3()
        {
            Random rand = new Random();
            choice = rand.Next(1, 4);
            Console.WriteLine($"Поле случайного выбора = {choice}");
            return choice;
        }
    }
    class PassCrossWalk
    {
        static void Main(string[] args)
        {
            int ch_1;
            int ch_2;
            int ch_3;
            string s;
            bool change;

            TrafficLight TrLig = new TrafficLight();

            Console.WriteLine("Светофор исправен?");

            ch_1 = TrLig.RendomChoice_1_2();

            if (!(TrLig.Operability(ch_1)))
            {
                Console.WriteLine("Выход из программы и переход к алгоритму" +
                   " \"Пересечение НЕрегулируемого ПП\"");
                return;
            }
            else
            {
                ch_2 = TrLig.RendomChoice_1_2_3();
                s = TrLig.Signal(ch_2);

                while (s.CompareTo("green")!=0)
                {
                  ch_3 = TrLig.RendomChoice_1_2();
                  change = TrLig.ChangeSignal(ch_3);
                  if (change == true)
                    {
                        ch_2 = TrLig.RendomChoice_1_2_3();
                        s = TrLig.Signal(ch_2);
                    }
                }

                Console.WriteLine("Пересечение зоны ПП БЕЗОПАСНО?");

                for (ch_1 = TrLig.RendomChoice_1_2(); !(TrLig.Safety(ch_1)); ch_1 = TrLig.RendomChoice_1_2())
                {
                    Console.WriteLine("Стойте на месте! Пересечение зоны ПП НЕ безопасно!");
                }
                Console.WriteLine("Пересечение зоны ПП безопасно! Можете перейти дорогу!");
            }
        }
    }
}
