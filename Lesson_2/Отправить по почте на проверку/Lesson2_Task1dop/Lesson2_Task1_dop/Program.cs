using System;

namespace Lesson2_Task1_dop
{
    class AnnuityPayment
    {
        static void Main(string[] args)
        {
            try
            {
                double totalCredit;//общая сумма кредита
                double PercentInMonth;//процентная ставка по кредиту в месяц (рассчитывается как годовая, делённая на 12 месяцев)
                int periodCredit;//период кредитования в мес.
                double SumPaidMonth;//общая сумма всех платежей в месяц по кредиту
                double k;// коэффициент аннуитета

                Console.WriteLine("Какую сумму кредита Вы хотели бы взять (введите положительное число):\n");
                totalCredit = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Под какой размер процентной ставки Вы готовы взять кредит (введите положительное число):\n");
                PercentInMonth = (Double.Parse(Console.ReadLine()) / 100 / 12);

                Console.WriteLine("За сколько лет Вы планируете погасить кредит (введите положительное целое число):\n");
                periodCredit = (Int32.Parse(Console.ReadLine())) * 12;

                k = Math.Round((PercentInMonth * Math.Pow((1 + PercentInMonth), periodCredit)) / (Math.Pow((1 + PercentInMonth), periodCredit) - 1), 4, MidpointRounding.AwayFromZero);
                Console.WriteLine($"Коэффициент аннуитета k = {k}\n");

                SumPaidMonth = Math.Round((totalCredit * k), 2, MidpointRounding.AwayFromZero);

                Console.WriteLine($"Сумма ежемесячного фиксированного платежа по кредиту составит:\t {SumPaidMonth}");

                Console.WriteLine();

                Console.WriteLine($"Общая сумма всех платежей за период кредитования составит:\t {SumPaidMonth * periodCredit}");

                Console.WriteLine();

                Console.WriteLine($"Общая сумма переплаты за период по кредиту составит:\t {SumPaidMonth * periodCredit-totalCredit}");
            }
            catch (FormatException)
            {
                Console.WriteLine("Недопустимый формат ввода, попробуйте еще раз!");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Вы ввели недопустимое значение, попробуйте еще раз!");
            }
            catch(Exception exc)
            {
                Console.WriteLine(exc);
            }
        }
    }
}
