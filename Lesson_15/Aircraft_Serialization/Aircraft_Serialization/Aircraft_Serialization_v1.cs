/*Создать класс Aircraft, содержащий информацию о количестве мест, скорости, высоте полета. Добавить методы взлета и посадки.
Выполнить создание экземпляра класса Aircraft с его последующей сериализацией в XML-формате и бинарном формате.
Далее – продемонстрировать восстановление объектов путем десериализации. В процессе выполнения задания необходимо использовать потоковый ввод-вывод (те или иные
представители Stream), инструменты соответствующих видов сериализации.*/

using System;

namespace Aircraft
{
    class Program
    {
        static void Main(string[] args)
        {
            

            Console.WriteLine("\nДемонстрация применения класса Aircraft:");
            Aircraft aircraft1 = new Aircraft("Boing-747");
            aircraft1.ShowInfoClass();

            // взлет
            aircraft1.AccelerationBraking(300, 2);
           
            // приземление
            aircraft1.AccelerationBraking(0, 0);
        }
    }

    class Aircraft
    {
        // Максимальная скорость полета самолета
        public int MaxSpeed { get; set; }

        // Минимально допустимая безопасная скорость полета для данного типа самолетов.
        public int MinSpeed { get; set; }

        // Единица измерения скорости полета самолета
        public string UnitOfSpeed { get; set; }

        // Текущая скорость полета самолета 
        public int CurrentSpeed { get; set; }

        // Шаг изменения скорости перемещения при увеличении/снижении воздействия на движущую систему
        public int Step { get; set; }

        // Максимально допустимая безопасная высота полета для данного типа самолетов, км.
        int MaxHeight { get; set; }

        // Минимально допустимая безопасная высота полета для данного типа самолетов, км.
        int MinHeight { get; set; }

        // Ед.измерения высоты полета
        string UnitOfHeight { get; set; }

        // Текущая высота полета самолета
        public int CurrentHeight { get; set; }

        // Модель самолета
        public string ModelAir { get; set; }

        public Aircraft(string modelAir)
        {
            ModelAir = modelAir;
            MaxSpeed = 800;
            MinSpeed = 200;
            Step = 100;
            MaxHeight = 10;
            MinHeight = 2;
            UnitOfSpeed = "км/час";
            UnitOfHeight = "км.";
            CurrentHeight = 0;
        }
        public void ShowInfoClass()
        {
            Console.WriteLine($"\nСамолет:\0{this.ModelAir}" +
                $"\nМинимально допустимая безопасная скорость полета:\0{this.MinSpeed}\0{this.UnitOfSpeed}" +
                $"\nМаксимально допустимая безопасная скорость полета:\0{this.MaxSpeed}\0{this.UnitOfSpeed}" +
                $"\nМинимально допустимая безопасная высота полета:\0{this.MinHeight}\0{this.UnitOfHeight}" +
                $"\nМаксимально допустимая безопасная высота полета:\0{this.MaxHeight}\0{this.UnitOfHeight}");
        }

        // Необходимая (заданная) скорость полета самолета
        private int needSpeed;
        public int NeedSpeed
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

        // Необходимая (заданная) высота полета самолета
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
  
        // Метод, для набора скорости
        public void MoveUp(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nРазогнать самолета до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            if (NeedSpeed > MaxSpeed)
            {
                Console.WriteLine("Движение со скоростью выше предельно допустимой может привести к поломке транспортного средства" +
                  "\0и созданию аварийной ситуации!! Увеличить скорость до максимально допустимой!!");
                NeedSpeed = MaxSpeed;
            }
            do
            {
                Console.WriteLine("Отвести рычаг управления двигателем от себя! Увеличить подачу топлива для ускорения двигателей!");
                CurrentSpeed = CurrentSpeed + Step;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed < NeedSpeed);
            Console.WriteLine($"Разгон ТС до скорости {this.NeedSpeed}\0{this.UnitOfSpeed} завершен!");
        }

        //  Метод для сброса скорости
        public void MoveDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nЗамедлить самолета до скорости {this.NeedSpeed}\0{this.UnitOfSpeed}:");
            do
            {
                Console.WriteLine("Потянуть рычаг управления двигателем на себя! Сократить подачу топлива для замедления двигателей");
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while (CurrentSpeed > NeedSpeed);
            Console.WriteLine($"Снижение скорости самолета до уровня {this.NeedSpeed}\0{this.UnitOfSpeed} завершено!");
        }

        // Метод для полной остановки 
        public void MoveStop()
        {
            NeedSpeed = 0;
            Console.WriteLine($"\nВыполнить полную остановку самолета:");
            do
            {
                Console.WriteLine("Перевести рычаг управления двигателем в нейтральное положение! Выключить подачу топлива и двигатели! Надавить на педаль тормоза!");
                CurrentSpeed = CurrentSpeed - Step;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            }
            while ((CurrentSpeed != NeedSpeed) || (CurrentSpeed < NeedSpeed));
            Console.WriteLine($"Выполнена полная остановка самолета!");
        }

        // Метод для изменения (набора/снижения) текущей скорости - в качестве аргумента передается желаемая скорость полета
        public void MovingForceUPDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Текущая скорость самолета: {this.CurrentSpeed}\0{this.UnitOfSpeed}");
            if (CurrentSpeed < NeedSpeed)
                this.MoveUp(NeedSpeed);

            else if (NeedSpeed == 0)
            {
                this.MoveStop();
            }
            else if (CurrentSpeed > NeedSpeed)
            {
                this.MoveDown(NeedSpeed);
            }
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

        // Метод для изменения ВЫСОТЫ полета самолета
        public void ChangeHight(int h)
        {
            Console.WriteLine($"\nТребуемая высота полета самолета: {h}\0{this.UnitOfHeight}");
            Console.WriteLine($"\nТекущая высота полета самолета: {this.CurrentHeight}\0{this.UnitOfHeight}");
           
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
        // Метод для изменения СКОРОСТИ полета самолета
        public void ChangeSpeed(int s)
        {
            Console.WriteLine($"\nТребуемая скорость самолета: {s}\0{this.UnitOfSpeed}");
            Console.WriteLine($"\nТекущая скорость самолета: {this.CurrentSpeed}\0{this.UnitOfSpeed}");

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
        }
    }
}

