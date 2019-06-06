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
            /*Console.WriteLine("Демонстрация применения класса Car:\n");
            Car car1 = new Car();
            car1.ShowInfoClass();
            // разгон
            car1.MovingForceUPDown(100);
            car1.MovingForceUPDown(350);
            // замедление
            car1.MovingForceUPDown(150);
            //остановка
            car1.MovingForceUPDown(0);

            Console.WriteLine("\n\nДемонстрация применения класса Yacht:\n");
            Yacht yacht1 = new Yacht();
            yacht1.ShowInfoClass();
            // разгон
            yacht1.MovingForceUPDown(20);
            yacht1.MovingForceUPDown(30);
            // замедление
            yacht1.MovingForceUPDown(10);
            //остановка
            yacht1.MovingForceUPDown(0);

            Console.WriteLine("\n\nДемонстрация применения класса Bicycle:\n");
            Bicycle bicycle1 = new Bicycle();
            bicycle1.ShowInfoClass();
            // разгон
            bicycle1.MovingForceUPDown(30);
            bicycle1.MovingForceUPDown(40);
            // замедление
            bicycle1.MovingForceUPDown(20);
            //остановка
            bicycle1.MovingForceUPDown(0);*/

            Console.WriteLine("\nДемонстрация применения класса Aircraft:\n");
            Aircraft aircraft1 = new Aircraft();
            aircraft1.ShowInfoClass();
            // разгон и набор высоты
            aircraft1.AccelerationBraking(300, 2);
            aircraft1.AccelerationBraking(500, 5);
            aircraft1.AccelerationBraking(600, 7);
            // разгон без набора высоты
            aircraft1.AccelerationBraking(700, 7);
            //снижение высоты без изменения скорости
            aircraft1.AccelerationBraking(700, 6);
            //набор скорости без изменения высоты
            aircraft1.AccelerationBraking(800, 6);
            // приземление
            //aircraft1.AccelerationBraking(0, 0);
        }
    }

    class Transport
    {
        public Transport()
        {
            this.CurrentSpeed = 0;
        }

        // Среда перемещения
        public string EnvironmentOfMoving { get; set; }

        // Максимальная скорость перемещения
        public int MaxSpeed { get; set; }

        // Единица измерения скорости перемещения
        public string UnitOfSpeed { get; set; }

        // Текущая скорость перемещения
        public int CurrentSpeed { get; set; }

        // Необходимая скорость перемещения
        public virtual int NeedSpeed { get; set; }

        // Шаг изменения скорости ТС при увеличении/снижении воздействия на движущую систему ТС
        public int Step { get; set; }

        // Способ усиления воздействия на движущую силу конкретного ТС
        public virtual void ForceUp()
        {
            Console.WriteLine("Усиливать воздействие на движущую силу ТС до тех пор, пока текущая скорость не станет равной заданной");
        }

        // Способ усиления воздействия на движущую силу конкретного ТС
        public virtual void ForceDown()
        {
            Console.WriteLine("Снижать воздействие на движущую силу ТС до тех пор, пока текущая скорость не станет равной заданной");
        }

        // Способ воздействия на движущую силу конкретного ТС для его остановки
        public virtual void ForceStop()
        {
            Console.WriteLine("Снижать воздействие на движущую силу до полной остановки ТС");
        }

        // Метод, отражающий способ воздействия на движущую силу ТС для набора скорости
        public void MoveUp(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Разогнать ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            do
            {
                this.ForceUp();
                CurrentSpeed = CurrentSpeed + Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed < NeedSpeed);
            Console.WriteLine($"Разгон ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed} завершен!");
        }

        // Метод, отражающий способ воздействия на движущую силу ТС для сброса скорости
        public void MoveDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Замедлить ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            do
            {
                this.ForceDown();
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed > NeedSpeed);
            Console.WriteLine($"Снижение скорости ТС до уровня {this.NeedSpeed}\0{this.UnitOfSpeed} завершено!");
        }

        // Метод, отражающий способ воздействия на движущую силу ТС для остановки ТС
        public void MoveStop()
        {
            NeedSpeed = 0;
            Console.WriteLine($"Выполнить полную остановку ТС:");
            do
            {
                this.ForceStop();
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость ТС {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed != NeedSpeed);
            Console.WriteLine($"Выполнена полная остановка ТС!");
        }

        // Метод для изменения (набора/снижения) текущей скорости   - в качестве аргумента передается желаемая скорость перемещения
        public void MovingForceUPDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Требуемая скорость ТС: {this.NeedSpeed}\0{this.UnitOfSpeed}");
            if (CurrentSpeed < NeedSpeed)
            {
                if (NeedSpeed <= MaxSpeed)
                {
                    Console.WriteLine("Набор скорости!");
                    this.MoveUp(s);
                }
                else
                {
                    Console.WriteLine("Движение со скоростью выше предельно допустимой может привести к поломке транспортного средства" +
                    "\0и созданию аварийной ситуации!! Увеличить скорость до максимально допустимой!!");
                    NeedSpeed = MaxSpeed;
                    this.MoveUp(NeedSpeed);
                }
            }
            else if (NeedSpeed == 0)
            {
                Console.WriteLine("Остановить транспортное средство!");
                this.MoveStop();
            }
            else if (CurrentSpeed > NeedSpeed)
            {
                Console.WriteLine("Снижение скорости!");
                this.MoveDown(s);
            }
        }

        // Метод для отображения сведений о тестируемом классе
        public virtual void ShowInfoClass()
        {
            Console.WriteLine($"\nВид транспорта:\0{this.EnvironmentOfMoving}" +
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
            Console.WriteLine("Бросить якорь!");
        }
    }

    class Car : Transport
    {
        public Car () : base ()
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
            MinHeight = 1; 
            UnitOfSpeed = "км/час";
            UnitOfHeight = "км.";
            CurrentHeight = 0;
        }
        public override void ShowInfoClass()
        {
            Console.WriteLine($"\nВид транспорта:\0{this.EnvironmentOfMoving}" +
                $"\nМинимально допустимая скорость полета:\0{this.MinSpeed}\0{this.UnitOfSpeed}" + 
                $"\nМаксимально допустимая скорость полета:\0{this.MaxSpeed}\0{this.UnitOfSpeed}" +
                $"\nМинимально допустимая высота полета:\0{this.MinHeight}\0{this.UnitOfHeight}" +
                $"\nМаксимально допустимая высота полета:\0{this.MaxHeight}\0{this.UnitOfHeight}\n\n");
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
                    Console.WriteLine($"Требуемая скорость полета должна находиться в диапазоне минимально ({MinSpeed}\0{UnitOfSpeed})" +
                        $" и максимально ({MaxSpeed}\0{UnitOfSpeed}) допустимого значения скорости полета!!");
                    needSpeed = MaxSpeed;
                }
                else if ((value < MinSpeed)&&(value > 0))
                {
                    Console.WriteLine("Самолету недостаточно мощности! Скорость ниже минимально допустимой!" +
                        " Подтвердите, что идем на посадку: нажмите << + >>для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needSpeed = value;
                    else needSpeed = MinSpeed;
                }
                else if (value == 0)
                {
                    Console.WriteLine("Подтвердите, что идем на посадку: нажмите << + >> для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needSpeed = value;
                    else needSpeed = MinSpeed;
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
                    Console.WriteLine($"Требуемая высота полета должна находиться в диапазоне минимально ({MinHeight}\0{UnitOfHeight})" +
                        $" и максимально ({MaxHeight}\0{UnitOfHeight}) допустимого значения высоты полета!!");
                    needHeight = MaxHeight;
                }
                else if ((value < MinHeight)&&((value > 0)))
                {
                    Console.WriteLine("Самолет теряет минимально допустимую высоту полета! " +
                        "Подтвердите, что идем на посадку: нажмите << + >> для продолжения");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needHeight = value;
                    else needHeight = MinHeight;
                }
                else if (value == 0)
                {
                    Console.WriteLine("Подтвердите, что идем на посадку: нажмите << + >> для продолжения!");
                    string temp = Console.ReadLine();
                    if (temp == "+")
                        needHeight = value;
                    else needHeight = MinHeight;
                }
            }
        }
        public override void ForceUp()
        {
            Console.WriteLine("Отвести рычаг управления двигателем от себя!");
        }

        public override void ForceDown()
        {
            Console.WriteLine("Потянуть рычаг управления двигателем на себя!");
        }

        public override void ForceStop()
        {
            Console.WriteLine("Перевести рычаг управления двигателем в нейтральное положение! Надавить на педаль тормоза!");
        }

        // Набор высоты
        public void HeightUp(int h)
        {
            this.NeedHeight = h;
            while ((this.CurrentHeight != this.NeedHeight)&& (this.CurrentHeight < this.MaxHeight))
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
            while ((this.CurrentHeight != this.NeedHeight)&&(this.CurrentHeight >= 0))
            {
                Console.WriteLine("Оттолкнуть штурвал от себя!");
                this.CurrentHeight = this.CurrentHeight - 1;
                Console.WriteLine($"Текущая высота полета самолета {this.CurrentHeight}\0{this.UnitOfHeight}");
            }
        }

        // Разгон, взлет, набор высоты, снижение, приземление - в качестве аргумента принимает заданную высоту и скорость полета
        public void AccelerationBraking(int s, int h)
        {
            this.NeedHeight = h;
            this.NeedSpeed = s;
            
            Console.WriteLine($"Требуемая скорость самолета: {this.NeedSpeed}\0{this.UnitOfSpeed}");
            if (CurrentSpeed < NeedSpeed)
            {
                Console.WriteLine("Набор скорости!");
                this.MoveUp(s);
            }
            else if (CurrentSpeed > NeedSpeed)
            {
                Console.WriteLine("Сброс скорости!");
                this.MoveDown(s);
            }
            else if (CurrentSpeed == NeedSpeed)
                Console.WriteLine("Самолет уже достиг требуемой скорости!");
            if (NeedSpeed == 0)
            {
                Console.WriteLine("Идем на посадку!");
                this.HeightDown(0);
                this.MoveStop();
            }

            Console.WriteLine($"Требуемая высота полета самолета: {this.NeedHeight}\0{this.UnitOfHeight}");
            if (CurrentHeight < NeedHeight)
            {
                Console.WriteLine("Набор высоты!");
                this.HeightUp(h);
            }
            else if (CurrentHeight > NeedHeight)
            {
                Console.WriteLine("Сброс высоты!");
                this.HeightDown(h);
            }
            else if (CurrentHeight == NeedHeight)
                Console.WriteLine("Самолет уже достиг требуемой высоты!");
            if (NeedHeight == 0)
            {
                Console.WriteLine("Идем на посадку!");
                Console.WriteLine("Самолет должен полностью приземлиться шасси на землю для выполнения полной остановки ТС!!");
                this.HeightDown(0);
            }
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
            Console.WriteLine("Медленнее либо совсем прекратить крутить педали");
        }
        public override void ForceStop()
        {
            Console.WriteLine("Прекратить крутить педали и нажать на тормоз!");
        }
    }
}
