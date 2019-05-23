using System;
/*Создайте четыре метода для выполнения арифметических операций, с именами: Add– сложение, Sub–вычитание, Mul– умножение, Div– деление. 
 * Каждый метод должен принимать два целочисленных аргумента и выводить на экран результат выполнения арифметической операции соответствующей имени метода.
 * Метод деления Div, должен выполнять проверку попытки деления на ноль. 
 * Требуется предоставить пользователю возможность вводить с клавиатуры значения операндов и знак арифметической операции, для выполнения вычислений.
*/

namespace Lesson_5_Home_Tasks_Main
{
    class CalcDem0
    {
        static void Main(string[] args)
        {
            int a; //1-й операнд
            int b; //2-й операнд
            char s; //знак, интерпретирующий запрашиваемую операцию
            Console.WriteLine("Введите целочисленное значение 1-го операнда");

            try
            {
                a = Int32.Parse(Console.ReadLine());
            }
            catch(System.FormatException)
            {
                Console.WriteLine("Значение операнда №1 должно быть целочисленным");
                Console.WriteLine("Присвоим по умолчанию значение 1 первому операнду");
                a = 1;
            }
            Console.WriteLine("Введите целочисленное значение 2-го операнда");
            try
            {
                b = Convert.ToInt32(Console.ReadLine());
            }
            catch (System.FormatException)
            {
                Console.WriteLine("Значение операнда №2 должно быть целочисленным");
                Console.WriteLine("Присвоим по умолчанию значение 1 второму операнду");
                b = 1;
            }
            Console.WriteLine("Введите условное обозначение для вызова требуемого действия:" +
                "\n+  для сложения" +
                "\n- для вычитания" +
                "\n* для умножения" + 
                "\n/ для деления");
            s = Convert.ToChar(Console.Read());
            Calculator obj = new Calculator();
            obj.DefineAndCallMethod(a, b, s);
        }
    }
    class Calculator
    {
        int numA; //по умолчанию все поля данного класса с модификатором доступа private по умолчанию
        int numB; 
        char sign; 
        int addition;
        int subtract;
        int multiple;
        double devide;

        public int NumA
        {
            get
            {
                return numA;
            }
            set
            {
                numA = value;
            }
        }
        public int NumB
        {
            get
            {
                return numB;
            }
            set
            {
                numB = value;
            }
        }
        public char Sign
        {
            get
            {
                return sign;
            }
            set
            {
                sign = value;
            }
        }
        public int Addition {
            get
            {
                return addition;
            }
            set
            {
                addition = value;
            }
        }
        public int Subtract
        {
            get
            {
                return subtract;
            }
            set
            {
                subtract = value;
            }
        }
        public int Multiple
        {
            get
            {
                return multiple;
            }
            set
            {
                multiple = value;
            }
        }
        public double Devide
        {
            get
            {
                return devide;
            }
            set
            {
                devide = value;
            }
        }


        public void DefineAndCallMethod(int i, int j, char k)
        {
            NumA = i;  
            NumB = j; 
            Sign = k; 

            switch (Sign) //вызов аксессора get свойства
            {
                case '+':
                    this.Add(NumA, NumB);
                    Console.WriteLine($"Результат операции сложения ({NumA}  + {NumB}) = {this.Addition}");
                    break;
                case '-':
                    this.Sub(NumA, NumB);
                    Console.WriteLine($"Результат операции вычитания ({NumA}  - {NumB}) = {this.Subtract}");
                    break;
                case '*':
                    this.Mul(NumA, NumB);
                    Console.WriteLine($"Результат операции умножения ({NumA}  * {NumB}) = {this.Multiple}");
                    break;
                case '/':
                    this.Div(NumA, NumB);
                    Console.WriteLine($"Результат операции деления ({NumA}  / {NumB}) = {this.Devide}");
                    break;
                default:
                    Console.WriteLine("Вы ввели НЕдопустимый символ");
                    return; //Выход из программы при условии ввода пользователем недопустимого символа запрашиваемой операции над операндами
            }
        }
        public int Add(int i, int j)
        {
            this.Addition = i + j;
            return this.Addition;

        }
        public int Sub(int i, int j)
        {
            this.Subtract = i - j;
            return this.Subtract;

        }
        public int Mul(int i, int j)
        {
            this.Multiple = i * j;
            return this.Multiple;

        }
        public double Div(int i, int j)
        {
            if (j != 0)
            {
                this.Devide = (double)i / (double)j;
            }
            else
            {
                Console.WriteLine("Вы ввели недопустимое значение второго операнда для выполнения операции деления (оно д.б. отличным от нуля!!)");
                this.Devide = 0;
            }
            return this.Devide;
        }
    }
}
