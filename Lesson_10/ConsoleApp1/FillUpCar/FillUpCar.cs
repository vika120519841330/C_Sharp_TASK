using System;

namespace FillUpCar
{
    class FillUpCarDemo
    {
        static void Main(string[] args)
        {
            // Метод, который проверяет возможность приведения экземпляра обьекта, передаваемого в качестве аргумента к базовому классу Car
            // и в случае удачного приведения, вызывает для этого экземпляра метод FillUpCar
            void Refuel(object obj)
            {
                Type temp = obj.GetType();

                Console.WriteLine($"Демонстрация метода Refuel после приведения аргумента типа object ({temp.Name})" +
                        " к базовому классу Car (UPCASTING):");
                if (!(obj is Car))
                    Console.WriteLine($"Сannot cast type {temp.Name} to Car\n");
                else
                    ((Car)obj).FillUpCar();// UPCASTING
                Console.WriteLine();

                Console.WriteLine($"Демонстрация метода Refuel после приведения  аргумента типа object ({temp.Name})" +
                        " к производному классу Toyota (DOWNCASTING):");
                if (!(obj is Toyota))
                    Console.WriteLine($"Сannot cast type {temp.Name} to Toyota\n");
                else
                    ((Toyota)obj).FillUpCar();// DOWNCASTING
                Console.WriteLine();

                Console.WriteLine($"Демонстрация метода Refuel после приведения  аргумента типа object ({temp.Name})" +
                       " к производному классу Kamaz (DOWNCASTING):");
                if (!(obj is Kamaz))
                    Console.WriteLine($"Сannot cast type {temp.Name} to Kamaz\n");
                else
                    ((Kamaz)obj).FillUpCar();// DOWNCASTING
                Console.WriteLine();

                Console.WriteLine($"Демонстрация метода Refuel после приведения  аргумента типа object ({temp.Name})" +
                       " к производному классу Geely (DOWNCASTING):");
                if (!(obj is Geely))
                    Console.WriteLine("Сannot cast types to Geely\n");
                else
                    ((Geely)obj).FillUpCar();// DOWNCASTING
            }

            object o = new Toyota("Toyota Yaris");
            Console.WriteLine($"Вызов метода Refuel для {(o.GetType()).Name}:\n");
            Refuel(o);
            
            o = new Kamaz("Kamaz-4308");
            Console.WriteLine($"Вызов метода Refuel для {(o.GetType()).Name}:\n");
            Refuel(o);

            Console.WriteLine($"Вызов метода Refuel для {(o.GetType()).Name}:\n");
            o = new Geely("Geely Emgrand X7");
            Refuel(o);

            Console.WriteLine($"Вызов метода Refuel для {(o.GetType()).Name}:\n");
            o = new Car();
            Refuel(o);
        }
    }
    class Car
    {
        protected string Title { get; set; }

        public Car()
        {
            this.Title = "<<Car's title>>";
        }
        public Car(string t)
        {
            this.Title = t;
        }
        public void FillUpCar()
        {
            Console.WriteLine($"The car {this.Title} filled up!\n");
        }
    }
    class Toyota : Car
    {
        public Toyota() : base() { }

        public Toyota(string t) : base(t)
        {
            this.Title = t;
        }

        private string MadeIn
        {
            get
            {
                return "made in Japan";
            }
        }
        public new void FillUpCar()
        {
            Console.WriteLine($"The car {this.Title}\0{this.MadeIn}");
            base.FillUpCar();
        }
    }
    class Kamaz : Car 
    {
        public Kamaz() : base() { }
        public Kamaz(string t) : base(t)
        {
            this.Title = t;
        }
        private string LengthOfTreiler
        {
            get
            {
                return "has lenght of treiler about 5 meters.";
            }
        }
        public new void FillUpCar()
        {
            Console.WriteLine($"The car {this.Title}\0{this.LengthOfTreiler}");
            base.FillUpCar();
        }
    }
    class Geely : Car
    {
        public Geely() : base() { }
        public Geely(string t) : base(t)
        {
            Title = t;
        }
        private int NumberOfSeats
        {
            get
            {
                return 7;
            }
        }
        public new void FillUpCar()
        {
            Console.WriteLine($"The car {this.Title}\0 has\0{this.NumberOfSeats} seats");
            base.FillUpCar();
        }
    }
}

