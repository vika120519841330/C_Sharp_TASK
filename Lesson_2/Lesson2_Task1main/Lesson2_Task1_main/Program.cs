using System;

namespace Lesson2_Task1_main
{
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
                byte numDaysInMonth;//кол-во дней в платежном периоде(месяце)
                double totalSumPaid = 0;//общая сумма всех платежей за год по кредиту

                Console.WriteLine("Какую сумму кредита Вы хотели бы взять (введите положительное число):");
                totalCredit = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Под какой размер процентной ставки Вы готовы взять кредит (введите положительное число):");
                ratePercent = Double.Parse(Console.ReadLine());

                sumMainDebtMonth = Math.Round((totalCredit / 12), 2, MidpointRounding.AwayFromZero);

                Console.WriteLine("Ежемесячные выплаты составят:\n");
                for (int i = 1; i <= 12; i++)
                {
                    switch (i)
                    {
                        case 1:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 2:
                            numDaysInMonth = 28;
                            unpaidMain = totalCredit - sumMainDebtMonth;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 3:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit - sumMainDebtMonth * 2;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 4:
                            numDaysInMonth = 30;
                            unpaidMain = totalCredit - sumMainDebtMonth * 3;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 5:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit - sumMainDebtMonth * 4;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 6:
                            numDaysInMonth = 30;
                            unpaidMain = totalCredit - sumMainDebtMonth * 5;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\tв т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 7:
                            numDaysInMonth = 30;
                            unpaidMain = totalCredit - sumMainDebtMonth * 6;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 8:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit - sumMainDebtMonth * 7;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 9:
                            numDaysInMonth = 30;
                            unpaidMain = totalCredit - sumMainDebtMonth * 8;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 10:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit - sumMainDebtMonth * 9;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 11:
                            numDaysInMonth = 30;
                            unpaidMain = totalCredit - sumMainDebtMonth * 10;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                        case 12:
                            numDaysInMonth = 31;
                            unpaidMain = totalCredit - sumMainDebtMonth * 11;
                            sumPercentDebtMonth = Math.Round((unpaidMain * ratePercent / 100 / 365 * numDaysInMonth), 2, MidpointRounding.AwayFromZero);
                            Console.WriteLine($"Месяц {i}: {(sumMainDebtMonth + sumPercentDebtMonth)}\t в т.ч.: основной долг: {sumMainDebtMonth}\t проценты: {sumPercentDebtMonth}");
                            totalSumPaid = totalSumPaid + (sumMainDebtMonth + sumPercentDebtMonth);
                            break;
                    }

                }
                Console.WriteLine();
                Console.WriteLine($"Общая сумма всех платежей за год по кредиту составит: {totalSumPaid}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Недопустимый формат ввода, попробуйте еще раз!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимое значение, попробуйте еще раз!");
            }
        }
    }
}

