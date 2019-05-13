using System;

namespace Lesson2_Task1_dop
{
    class MyException:Exception
    {
        public MyException(string str):base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class AnnuityPayment
    {
        static void Main(string[] args)
        {
            try
            {
                double totalCredit;//общая сумма кредита
                double PercentInMonth;//процентная ставка по кредиту в месяц (рассчитывается как годовая, делённая на 12 месяцев)
                int pC;//период кредитования в годах.
                int periodCredit;//период кредитования в мес.
                double SumPaidMonth;//общая сумма всех платежей в месяц по кредиту
                double k;// коэффициент аннуитета

                Console.WriteLine("Какую сумму кредита Вы хотели бы взять (введите положительное число):\n");
                totalCredit = Convert.ToDouble(Console.ReadLine());
                if (totalCredit <= 0)
                    throw new MyException("Сумма кредита д.б.больше нуля");

                Console.WriteLine("Под какой размер процентной ставки Вы готовы взять кредит (введите положительное число):\n");
                PercentInMonth = (Double.Parse(Console.ReadLine()) / 100 / 12);
                if ((PercentInMonth <= 0) || (PercentInMonth > 0.083))//0.083 это 100%/100/12мес.
                    throw new MyException("Сумма процентной ставки д.б.больше нуля и меньше ста");

                try
                {
                    Console.WriteLine("За сколько лет Вы планируете погасить кредит (введите положительное целое число):\n");
                    pC = Int32.Parse(Console.ReadLine());
                    periodCredit = pC * 12;

                    if ((periodCredit <= 0) || (periodCredit >= (600)))//600 это 50лет*12мес.
                        throw new MyException("Период кредитования д.б. больше нуля и менее 51 года");

                    k = Math.Round((PercentInMonth * Math.Pow((1 + PercentInMonth), periodCredit)) /
                    (Math.Pow((1 + PercentInMonth), periodCredit) - 1), 4, MidpointRounding.AwayFromZero);
                    Console.WriteLine($"\nКоэффициент аннуитета k = {k}\n");

                    SumPaidMonth = Math.Round((totalCredit * k), 2, MidpointRounding.AwayFromZero);
                    Console.WriteLine($"Сумма ежемесячного фиксированного платежа по кредиту составит:\t {SumPaidMonth}");

                    Console.WriteLine($"\nОбщая сумма всех платежей за период кредитования составит:\t" +
                        $" {Math.Round((SumPaidMonth * periodCredit), 2, MidpointRounding.AwayFromZero)}");

                    Console.WriteLine($"\nОбщая сумма переплаты за период по кредиту составит:\t {SumPaidMonth * periodCredit - totalCredit}");

                }
                catch (FormatException)
                {
                    Console.WriteLine("Период кредитования д.б. целым числом");
                }
            }
            catch (MyException exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
