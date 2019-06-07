/*Создать класс (Transport), создать несколько производных от него классов (Car, Aircraft, Bicycle).Транспортные средства могут обладать колесами, цветом, массой,
 * быть оснащенными двигателем (или нет), иметь руль, кресла, подогрев сидений и т.д. Набор характеристик, которыми обладают
транспортные средства можно регулировать самостоятельно (но не более 5 для каждого вида).Также можно среди них добавлять и характеристики движения
(скорость, высота, координаты).Транспортные средства умеют передвигаться (ехать, летать, плавать? ), тормозить (уменьшая
скорость), ускоряться (увеличивая скорость). Необходимо реализовать полиморфное поведение методов (т.к. суть движения может быть одна,
но методы по содержанию – разные). Уровень размещения тех или иных свойств в классе, виртуальные или переопределенные должны
быть методы – принять решение самостоятельно в зависимости от конкретного Транспортного средства. Продемонстрировать работу программы.*/

using System;

namespace Transport
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация применения класса Car:");
            Car car1 = new Car();
            car1.ShowInfoClass(car1);
            // разгон
            car1.MovingForceUPDown(100);
            car1.MovingForceUPDown(350);
            // замедление
            car1.MovingForceUPDown(150);
            //остановка
            car1.MovingForceUPDown(0);

            Console.WriteLine("\n\nДемонстрация применения класса Yacht:");
            Yacht yacht1 = new Yacht();
            yacht1.ShowInfoClass(yacht1);
            // разгон
            yacht1.MovingForceUPDown(10);
            yacht1.MovingForceUPDown(30);
            // замедление
            yacht1.MovingForceUPDown(20);
            //остановка
            yacht1.MovingForceUPDown(0);

            Console.WriteLine("\n\nДемонстрация применения класса Bicycle:");
            Bicycle bicycle1 = new Bicycle();
            bicycle1.ShowInfoClass(bicycle1);
            // разгон
            bicycle1.MovingForceUPDown(30);
            bicycle1.MovingForceUPDown(40);
            // замедление
            bicycle1.MovingForceUPDown(20);
            //остановка
            bicycle1.MovingForceUPDown(0);

            Console.WriteLine("\nДемонстрация применения класса Aircraft:");
            Aircraft aircraft1 = new Aircraft();
            aircraft1.ShowInfoClass(aircraft1);
            // разгон и набор высоты
            aircraft1.AccelerationBraking(300, 2);
            aircraft1.AccelerationBraking(400, 5);
            aircraft1.AccelerationBraking(500, 7);
            // разгон без набора высоты
            aircraft1.AccelerationBraking(600, 7);
            //снижение высоты без изменения скорости
            aircraft1.AccelerationBraking(600, 6);
            //набор скорости без изменения высоты
            aircraft1.AccelerationBraking(700, 6);
            //набор скорости и высоты выше максимально допустимых значений
            aircraft1.AccelerationBraking(900, 11);
            //сброс скорости и высоты ниже минимально допустимых значений
            aircraft1.AccelerationBraking(100, 1);
            // приземление
            aircraft1.AccelerationBraking(0, 0); 
        }
    }

    class Transport
    {
        public Transport()
        {
            this.CurrentSpeed = 0; // у всех (производных и базового) классов начальное значение текущей скорости нулевое
        }

        // Вид транспорта относительно среды перемещения
        public string EnvironmentOfMoving { get; set; }

        // Максимальная скорость перемещения
        public int MaxSpeed { get; set; }

        // Единица измерения скорости перемещения
        public string UnitOfSpeed { get; set; }

        // Текущая скорость перемещения
        public int CurrentSpeed { get; set; }

        // Необходимая (заданная) скорость перемещения
        public virtual int NeedSpeed { get; set; }

        // Шаг изменения скорости ТС при увеличении/снижении воздействия на движущую систему ТС
        public int Step { get; set; }

        // Способ усиления воздействия на движущую силу конкретного ТС - подлежит переопределению во всех производных классах
        public virtual void ForceUp()
        {
            Console.WriteLine("Усиливать воздействие на движущую силу ТС до тех пор, пока текущая скорость не станет равной заданной");
        }

        // Способ снижения воздействия на движущую силу конкретного ТС - подлежит переопределению во всех производных классах
        public virtual void ForceDown()
        {
            Console.WriteLine("Снижать воздействие на движущую силу ТС до тех пор, пока текущая скорость не станет равной заданной");
        }

        // Способ воздействия на движущую силу конкретного ТС для его остановки - подлежит переопределению во всех производных классах
        public virtual void ForceStop()
        {
            Console.WriteLine("Прекратить воздействие на движущую силу ТС до полной его остановки");
        }

        // Метод, для набора скорости ТС
        public void MoveUp(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nРазогнать ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            if (NeedSpeed > MaxSpeed)
            {
                Console.WriteLine("Движение со скоростью выше предельно допустимой может привести к поломке транспортного средства" +
                  "\0и созданию аварийной ситуации!! Увеличить скорость до максимально допустимой!!");
                NeedSpeed = MaxSpeed;
            }
            do
            {
                this.ForceUp();
                CurrentSpeed = CurrentSpeed + Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed < NeedSpeed);
            Console.WriteLine($"Разгон ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed} завершен!");
        }

        //  Метод для сброса скорости ТС
        public void MoveDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nЗамедлить ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            do
            {
                this.ForceDown();
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed > NeedSpeed);
            Console.WriteLine($"Снижение скорости ТС до уровня {this.NeedSpeed}\0{this.UnitOfSpeed} завершено!");
        }

        // Метод для остановки ТС
        public void MoveStop()
        {
            NeedSpeed = 0;
            Console.WriteLine($"\nВыполнить полную остановку ТС:");
            do
            {
                this.ForceStop();
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while ((CurrentSpeed != NeedSpeed) || (CurrentSpeed < NeedSpeed));
            Console.WriteLine($"Выполнена полная остановка ТС!");
        }

        // Метод для изменения (набора/снижения) текущей скорости ТС - в качестве аргумента передается желаемая скорость перемещения
        public void MovingForceUPDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Текущая скорость ТС: {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            if (CurrentSpeed < NeedSpeed)
                this.MoveUp(NeedSpeed);

            else if (NeedSpeed == 0)
            {
                this.MoveStop();
            }
            else if(CurrentSpeed > NeedSpeed)
            {
                this.MoveDown(NeedSpeed);
            }
        }

        // Метод для отображения сведений о тестируемом классе
        public virtual void ShowInfoClass(Transport tr)
        {
            Type t = tr.GetType();
            Console.WriteLine($"\nКласс:\0{t.Name}" +
                $"\nВид транспорта:\0{this.EnvironmentOfMoving}" +
                $"\nМаксимально допустимая скорость перемещения:\0{this.MaxSpeed}\0{this.UnitOfSpeed}\n");
            Console.WriteLine();
        }
    }

    class Yacht : Transport
    {
        public Yacht() : base()
        {
            EnvironmentOfMoving = "Водный транспорт";
            MaxSpeed = 40;
            UnitOfSpeed = "узлов в час";
            Step = 10;
        }
        public override void ForceUp()
        {
            Console.WriteLine("Поднять паруса");
        }
        public override void ForceDown()
        {
            Console.WriteLine("Свернуть паруса");
        }
        public override void ForceStop()
        {
            Console.WriteLine("Свернуть паруса и бросить якорь!");
        }
    }

    class Car : Transport
    {
        public Car() : base()
        {
            EnvironmentOfMoving = "Наземный транспорт";
            MaxSpeed = 250;
            UnitOfSpeed = "миль в час";
            Step = 50;
        }

        public override void ForceUp()
        {
            Console.WriteLine("Надавить на педаль газа!");
        }

        public override void ForceDown()
        {
            Console.WriteLine("Отпустить педаль газа! При необходимости притормаживать!");
        }

        public override void ForceStop()
        {
            Console.WriteLine("Надавить на педаль тормоза!");
        }
    }

    class Bicycle : Transport
    {
        public Bicycle() : base()
        {
            EnvironmentOfMoving = "Наземный транспорт";
            MaxSpeed = 50;
            UnitOfSpeed = "км/час";
            Step = 10;
        }
        public override void ForceUp()
        {
            Console.WriteLine("Быстрее крутить педали");
        }
        public override void ForceDown()
        {
            Console.WriteLine("Прекратить крутить педали либо крутить их медленнее. При необходимости притормаживать.");
        }
        public override void ForceStop()
        {
            Console.WriteLine("Прекратить крутить педали и нажать на тормоз!");
        }
    }

    class Aircraft : Transport
    {
        int MinSpeed { get; set; } // минимально допустимая безопасная скорость полета для данного типа самолетов.
        string UnitOfHeight { get; set; } // ед.измерения высоты полета
        int MaxHeight { get; set; } // максимально допустимая безопасная высота полета для данного типа самолетов, км.
        int MinHeight { get; set; } // минимально допустимая безопасная высота полета для данного типа самолетов, км.
        public Aircraft() : base()
        {
            EnvironmentOfMoving = "Воздушный транспорт";
            MaxSpeed = 800;
            MinSpeed = 200;
            Step = 100;
            MaxHeight = 10;
            MinHeight = 2;
            UnitOfSpeed = "км/час";
            UnitOfHeight = "км.";
            CurrentHeight = 0;
        }
        public void ShowInfoClass(Aircraft air)
        {
            Type t = air.GetType();
            Console.WriteLine($"\nКласс:\0{t.Name}" +
                $"\nВид транспорта:\0{this.EnvironmentOfMoving}" +
                $"\nМинимально допустимая безопасная скорость полета:\0{this.MinSpeed}\0{this.UnitOfSpeed}" +
                $"\nМаксимально допустимая безопасная скорость полета:\0{this.MaxSpeed}\0{this.UnitOfSpeed}" +
                $"\nМинимально допустимая безопасная высота полета:\0{this.MinHeight}\0{this.UnitOfHeight}" +
                $"\nМаксимально допустимая безопасная высота полета:\0{this.MaxHeight}\0{this.UnitOfHeight}");
        }

        private int needSpeed;
        public override int NeedSpeed
        {
            get
            {
                return needSpeed;
            }
            set
            {
                if ((value >= MinSpeed) && (value <= MaxSpeed))
                    needSpeed = value;
                else if (value > MaxSpeed)
                {
                    Console.WriteLine($"\nТребуемая скорость полета должна находиться в диапазоне минимально ({MinSpeed}\0{UnitOfSpeed})" +
                        $" и максимально ({MaxSpeed}\0{UnitOfSpeed}) допустимого значения скорости полета!!");
                    Console.WriteLine($"Установить скорость полета равной максимально допустимому значению!");
                    needSpeed = MaxSpeed;
                }
                else if ((value < MinSpeed) && (value > 0))
                {
                    Console.WriteLine("\nСамолету бужет недостаточно мощности! Скорость станет ниже минимально допустимой!" +
                        " Подтвердите снижение скорости полета: нажмите << + >> для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needSpeed = value;
                    else
                    {
                        Console.WriteLine($"Установить скорость полета равной минимально допустимому значению: ({MinSpeed}\0{UnitOfSpeed})!");
                        needSpeed = MinSpeed;
                    }
                }
                else if (value == 0)
                {
                    Console.WriteLine("\nПодтвердите, что необходимо выключить двигатели: нажмите << + >> для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needSpeed = value;
                    else
                    {
                        Console.WriteLine($"Установить скорость полета равной минимально допустимому значению: ({MinSpeed}\0{UnitOfSpeed})!");
                        needSpeed = MinSpeed;
                    }
                }
            }
        }

        // Текущая высота полета самолета
        public int CurrentHeight { get; set; }

        // Необходимая высота полета самолета
        private int needHeight;
        public int NeedHeight
        {
            get
            {
                return this.needHeight;
            }
            set
            {
                if ((value >= MinHeight) && (value <= MaxHeight))
                    needHeight = value;
                else if (value > MaxHeight)
                {
                    Console.WriteLine($"\nТребуемая высота полета должна находиться в диапазоне минимально ({MinHeight}\0{UnitOfHeight})" +
                        $" и максимально ({MaxHeight}\0{UnitOfHeight}) допустимого значения высоты полета!!");
                    Console.WriteLine($"Установить высоту полета равной максимально допустимому значению!");
                    needHeight = MaxHeight;
                }
                else if ((value < MinHeight) && ((value > 0)))
                {
                    Console.WriteLine("\nСамолет потеряет минимально допустимую высоту полета! " +
                        "Подтвердите, снижение: нажмите << + >> для продолжения");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needHeight = value;
                    else
                    {
                        Console.WriteLine($"Установить высоту полета равной минимально допустимому значению: ({MinHeight}\0{UnitOfHeight})!");
                        needHeight = MinHeight;
                    }
                }
                else if (value == 0)
                {
                    Console.WriteLine("\nПодтвердите, что идем на посадку: нажмите << + >> для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needHeight = value;
                    else
                    {
                        Console.WriteLine($"Установить высоту полета равной минимально допустимому значению: ({MinHeight}\0{UnitOfHeight})!");
                        needHeight = MinHeight;
                    }
                }
            }
        }
        public override void ForceUp()
        {
            Console.WriteLine("Отвести рычаг управления двигателем от себя! Увеличить подачу топлива для ускорения двигателей!");
        }

        public override void ForceDown()
        {
            Console.WriteLine("Потянуть рычаг управления двигателем на себя! Сократить подачу топлива для замедления двигателей");
        }

        public override void ForceStop()
        {
            Console.WriteLine("Перевести рычаг управления двигателем в нейтральное положение! Выключить подачу топлива и двигатели! Надавить на педаль тормоза!");
        }

        // Набор высоты
        public void HeightUp(int h)
        {
            this.NeedHeight = h;
            while ((this.CurrentHeight != this.NeedHeight) && (this.CurrentHeight < this.MaxHeight))
            {
                Console.WriteLine("Потянуть штурвал на себя!");
                this.CurrentHeight = this.CurrentHeight + 1;
                Console.WriteLine($"Текущая высота полета самолета {this.CurrentHeight}\0{this.UnitOfHeight}");
            }
        }

        // Сброс высоты
        public void HeightDown(int h)
        {
            this.NeedHeight = h;
            while ((this.CurrentHeight != this.NeedHeight) && (this.CurrentHeight >= 0))
            {
                Console.WriteLine("Оттолкнуть штурвал от себя!");
                this.CurrentHeight = this.CurrentHeight - 1;
                Console.WriteLine($"Текущая высота полета самолета {this.CurrentHeight}\0{this.UnitOfHeight}");
            }
        }

        // Разгон, взлет, набор высоты, снижение, приземление - в качестве аргумента принимает заданную высоту и скорость полета
        public void AccelerationBraking(int s, int h)
        {
            Console.WriteLine($"\nТребуемая скорость самолета: {s}\0{this.UnitOfSpeed}," +
                $"\0требуемая высота полета самолета: {h}\0{this.UnitOfHeight}");
            Console.WriteLine($"\nТекущая скорость самолета: {this.CurrentSpeed}\0{this.UnitOfSpeed}," +
                $"\0текущая высота полета самолета: {this.CurrentHeight}\0{this.UnitOfHeight}");
            // На первом этапе изменим скорость полета
            this.NeedSpeed = s;
            if (CurrentSpeed < NeedSpeed)
            {
                Console.WriteLine("\nНабор скорости!");
                this.MoveUp(this.NeedSpeed);
            }
            else if (CurrentSpeed > NeedSpeed)
            {
                Console.WriteLine("\nСброс скорости!");
                this.MoveDown(this.NeedSpeed);
            }
            else if (CurrentSpeed == NeedSpeed)
                Console.WriteLine("\nСамолет уже достиг требуемой скорости!\n");
            else if (NeedSpeed == 0)
            {
                Console.WriteLine("\nВыключить двигатели!");
                this.MoveStop();
            }
             
            // На втором этапе изменим высоту полета
            this.NeedHeight = h;
            if (CurrentHeight < NeedHeight)
            {
                Console.WriteLine("\nНабор высоты!\n");
                this.HeightUp(this.NeedHeight);
            }
            else if (CurrentHeight > NeedHeight)
            {
                Console.WriteLine("\nСброс высоты!");
                this.HeightDown(this.NeedHeight);
            }
            else if (CurrentHeight == NeedHeight)
                Console.WriteLine("\nСамолет уже достиг требуемой высоты!\n");
            else if (NeedHeight == 0)
            {
                Console.WriteLine("\nСамолет идет на посадку!");
                this.HeightDown(this.NeedHeight);
            }
        }
    }
}

