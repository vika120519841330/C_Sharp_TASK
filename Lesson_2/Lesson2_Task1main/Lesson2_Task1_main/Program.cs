using System;

namespace Lesson2_Task1_main
{
    class MyException: Exception
    {
        public MyException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class DifferentiatePayment
    {
        static void Main(string[] args)
        {
            try
            {
                double totalCredit;//общая сумма кредита
                double ratePercent;//процентная ставка
                double sumMainDebtMonth;//ежемесячный платеж в счет погашения основного долга(тело кредита-фиксированная ежемесячная сумма)
                double sumPercentDebtMonth;//ежемесячный платеж по процентам(вычисляется как остаток основного долга в текущем периоде помноженный на
                                           //процентную ставку, разделенную на количество дней в году (365 или 366) и умноженную на число дней
                                           //в платежном периоде (от 28 до 31).)
                double unpaidMain;//общая сумма неоплаченного основного долга в текущем периоде(уменьшается от месяца к месяцу)
                double totalSumPaid = 0;//общая сумма всех платежей за год по кредиту
                byte numDaysInMonth = 1;//кол-во дней в платежном периоде(месяце)
                byte k = 0;

                Console.WriteLine("Какую сумму кредита Вы хотели бы взять (введите положительное число):");
                totalCredit = Convert.ToDouble(Console.ReadLine());
                if (totalCredit <= 0)
                    throw new MyException("Сумма кредита должна быть больше нуля");

                Console.WriteLine("Под какой размер процентной ставки Вы готовы взять кредит (введите положительное число):");
                ratePercent = Double.Parse(Console.ReadLine());
                if ((ratePercent <= 0)||(ratePercent>=100))
                    throw new MyException("Размер процентной ставки д.б. больше нуля и менее ста");

                sumMainDebtMonth = Math.Round((totalCredit / 12), 2, MidpointRounding.AwayFromZero);

                Console.WriteLine("Ежемесячные выплаты составят:\n");
                for (int i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1:
                            numDaysInMonth = 31;
                            k = 0;
                            break;
                        case 2:
                            numDaysInMonth = 28;
                            k = 1;
                            break;
                        case 3:
                            numDaysInMonth = 31;
                            k = 2;
                            break;
                        case 4:
                            numDaysInMonth = 30;
                            k = 3;
                            break;
                        case 5:
                            numDaysInMonth = 31;
                            k = 4;
                            break;
                        case 6:
                            numDaysInMonth = 30;
                            k = 5;
                            break;
                        case 7:
                            numDaysInMonth = 30;
                            k = 6;
                            break;
                        case 8:
                            numDaysInMonth = 31;
                            k = 7;
                            break;
                        case 9:
                            numDaysInMonth = 30;
                            k = 8;
                            break;
                        case 10:
                            numDaysInMonth = 31;
                            k = 9;
                            break;
                        case 11:
                            numDaysInMonth = 30;
                            k = 10;
                            break;
                        case 12:
                            numDaysInMonth = 31;
                            k = 11;
                            break;
                    }
                    unpaidMain = totalCredit - sumMainDebtMonth * k;

                    sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                    Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг:{sumMainDebtMonth}\tпроценты:{sumPercentDebtMonth}");

                    totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                }
                Console.WriteLine($"\nОбщая сумма всех платежей за год по кредиту составит: {totalSumPaid}");
            }
            catch (MyException exc)
            {
                Console.WriteLine(exc);
            }

        }
    }
}

