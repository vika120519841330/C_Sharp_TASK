using System;
/*Представьте, что вы реализуете программу для банка, которая помогает определить, погасил ли клиент кредит или нет. 
 Допустим, ежемесячная сумма платежа должна составлять 100 BYN. Клиент должен выполнить 7 платежей,
 но может платить реже большими суммами. Т.е., может двумя платежами по 300 и 400 BYN. Закрыть весь долг.
Создайте метод, который будет в качестве аргумента принимать сумму платежа,
введенную экономистом банка. 
Метод выводит на экран информацию о состоянии кредита (сумма задолженности, сумма переплаты, сообщение об отсутствии долга).*/
namespace Lesson_5_Home_Task_2_Main
{
    class MyException : Exception
    {
        public MyException(string str) : base(str) { }
        public override string ToString()
        {
            return Message;
        }
    }
    class LoanDemo
    {
        static void Main(string[] args)
        {
            double wantToPay;
            Loan creditA = new Loan(700.00, 7); //создание экземпляра обьекта со значением долга по кредиту равным 700
            for (byte i = creditA.PeriodLoan; (i > 0)&&(creditA.SumLoan > 0); i--)
            {
                if (i == 1)
                {
                    Console.WriteLine("\nЭТО ПОСЛЕДНИЙ КРЕДИТНЫЙ ПЛАТЕЖ! Сумма очередного платежа должна покрывать ВСЮ сумму задолженности по кредиту!" +
                        $"т.е. составлять: {creditA.SumLoan:n2}");
                    wantToPay = creditA.SumLoan;
                    creditA.LoanInfo(wantToPay);
                }
                else
                {
                    Console.WriteLine("\nВведите сумму очередного платежа, в счет погашения долга по кредиту:");
                    wantToPay = Convert.ToDouble(Console.ReadLine());
                    creditA.LoanInfo(wantToPay);
                }
            }
        }
    }
    class Loan
    {
        double sum; //поле суммы задолженности по кредиту
        byte period; //поле периодичности платежей
        double repayment; //поле погашаемой суммы по кредиту
        public Loan(double s, byte p) //конструктор класса
        {
            this.SumLoan = s;
            this.PeriodLoan = p;
        }
        public double SumLoan // свойство задолженности по кредиту
        {
            get
            {
                return sum;
            }
            set
            {
                sum = value;
            }
        }
         public byte PeriodLoan// свойство периодичности платежей
        {
            get
            {
                return period;
            }
            set
            {
                period = value;
            }
        }
        public double RepaymentAmount //свойство погашаемой суммы по кредиту
        {
            get
            {
                return repayment;
            }
            set
            {
                if (value < 0)
                {
                    repayment = 0;
                    throw new MyException("Введенная сумма очередного платежа д.б. положительным числом!!\n");
                }
                else
                {
                    repayment = value;
                }
            }
        }

        public void ShowLoadInfo() //метод для отображения на консоли информации о состоянии кредита
        {
            if (this.SumLoan < 0)
                Console.WriteLine($"Сумма переплаты по кредиту составляет:{this.SumLoan:n2}");
            else if (this.SumLoan == 0)
                Console.WriteLine("Задолженность по кредиту отсутствует");
            else Console.WriteLine($"Сумма задолженности по кредиту составляет:{this.SumLoan:n2}");
        }
        public void LoanInfo(double p)//метод для получения информации о состоянии кредита
        {
            Console.WriteLine("Текущая информация о состоянии кредита (ДО осуществления платежа):");
            this.ShowLoadInfo();

            Console.WriteLine();
            try
            {
                this.RepaymentAmount = p;
            }
            catch (MyException exc)
            {
                Console.WriteLine(exc);
            }
            this.SumLoan = this.SumLoan - this.RepaymentAmount;
            Console.WriteLine("Обновленная информация о состоянии кредита (ПОСЛЕ осуществления очередного платежа):");
            this.ShowLoadInfo();
        }
    }
}
