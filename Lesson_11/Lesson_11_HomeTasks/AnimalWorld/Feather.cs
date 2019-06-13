using System;

namespace AnimalWorld
{
    class FeatherDemo
    {
        static void Main(string[] args)
        {
            // Создание первого экземпляра класса Parrot
            Parrot p1 = new Parrot("Tim", 0.5, 10, 4);
            // Создание второго экземпляра класса Parrot
            Parrot p2 = new Parrot("Max", 0.4, 12, 5);

            p1.ShowInfoAboutFeather();
            p2.ShowInfoAboutFeather();

            Parrot p3 = p1 - p2;
            Console.WriteLine($"\nРазность в показателях жизнедеятельности птицы породы {p3.GetType().Name} " +
                $"по кличке <<{p1.Nickname}>> и <<{p2.Nickname}>> следующая:\n" +
                $"в скорости бега:\t{p3.SpeedOfRun}\n" +
                $"в высоте полета:\t{p3.HightOfFlight}\n" +
                $"в продолжительности сна: {p3.PeriodOfSleep}\n");

            Parrot p4 = new Parrot();
            p4 = ++p1;
            p4.Nickname = "Kuzya";
            p4.ShowInfoAboutFeather();

            Parrot p5 = p1 * p2;
            p5.Nickname = "Roma";
            p5.ShowInfoAboutFeather();
        }
    }
    abstract class Feather
    {
        public Feather()
        { }
        public Feather(double run, int fly, int sleep)
        {
            SpeedOfRun = run;
            HightOfFlight = fly;
            PeriodOfSleep = sleep;
        }
        public double SpeedOfRun { get; set; }
        public int HightOfFlight { get; set; }
        public int PeriodOfSleep { get; set; }

        public abstract void Run();
        public abstract void Sleep();
        public abstract void Fly();
    }
    class Parrot : Feather
    {
        public Parrot() : base()
        {
            Nickname = "Without name";
        }
        public Parrot(string name)
        {
            Nickname = name;
        }
        public Parrot(string name, double run, int fly, int sleep) : base(run, fly, sleep)
        {
            Nickname = name;
            SpeedOfRun = run;
            HightOfFlight = fly;
            PeriodOfSleep = sleep;
        }
        public string Nickname { get; set; }
        public override void Run()
        {
            Console.WriteLine($"\nумеет бегать со скоростью {this.SpeedOfRun}\0 м/с.");
        }
        public override void Sleep()
        {
            Console.WriteLine($"\nв среднем спит {this.PeriodOfSleep}\0 часов в сутки.");
        }
        public override void Fly()
        {
            Console.WriteLine($"\nспособна летать на высоте примерно {this.HightOfFlight}\0 метров.");
        }
        public void ShowInfoAboutFeather()
        {
            Console.WriteLine($"\nПтица породы {this.GetType().Name} по кличке <<{this.Nickname}>>:");
            this.Run();
            this.Sleep();
            this.Fly();
            Console.WriteLine();
        }
        public static Parrot operator -(Parrot a, Parrot b)
        {
            Parrot result = new Parrot();
            result.SpeedOfRun = (a.SpeedOfRun > b.SpeedOfRun) ? (a.SpeedOfRun - b.SpeedOfRun) : (b.SpeedOfRun - a.SpeedOfRun);
            result.HightOfFlight = (a.HightOfFlight > b.HightOfFlight) ? (a.HightOfFlight - b.HightOfFlight) : (b.HightOfFlight - a.HightOfFlight);
            result.PeriodOfSleep = result.PeriodOfSleep = (a.PeriodOfSleep > b.PeriodOfSleep) ? (a.PeriodOfSleep - b.PeriodOfSleep) : (b.PeriodOfSleep - a.PeriodOfSleep);
            return result;
        }

        public static Parrot operator ++ (Parrot p)
        {
            return new Parrot() { SpeedOfRun = p.SpeedOfRun + 1, HightOfFlight = p.HightOfFlight + 1, PeriodOfSleep = p.PeriodOfSleep + 1 };
        }

        public static Parrot operator *(Parrot a, Parrot b)
        {
            return new Parrot()
            {
                SpeedOfRun = a.SpeedOfRun * b.PeriodOfSleep,
                HightOfFlight = a.HightOfFlight * b.HightOfFlight,
                PeriodOfSleep = a.PeriodOfSleep * b.PeriodOfSleep
            };
        }
    }
}
