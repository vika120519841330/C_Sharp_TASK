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

            Aircraft aircraft1 = new Aircraft();

            aircraft1.ShowInfoAir();

            // Подписка на событие Takeoff
            aircraft1.Takeoff += new TakeoffEventHandler(aircraft1.TakeoffHandler);
            // Подписка на событие Boarding
            aircraft1.Boarding += new BoardingEventHandler(aircraft1.BoardingHandler);

            TakeoffEventArgs argTakeoff = new TakeoffEventArgs(250, 5, 600);
            // взлет - вызов события Takeoff
            aircraft1.OnTakeoff(argTakeoff);
            aircraft1.ShowInfoAir();

            // посадка - вызов события Boarding
            BoardingEventArgs argBoard = new BoardingEventArgs(120);
            aircraft1.OnBoarding(argBoard);
            aircraft1.ShowInfoAir();

        }
    }

    // Делегат, поддерживающий событие ВЗЛЕТ
    public delegate void TakeoffEventHandler(object sender, TakeoffEventArgs arg);

    // Делегат, поддерживающий событие ПОСАДКА
    public delegate void BoardingEventHandler(object sender, BoardingEventArgs arg);

    // Класс аргументов события ВЗЛЕТ
    public class TakeoffEventArgs : EventArgs
    {
        // Курс самолета (от 0 до 360 градусов)
        private int course;
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if ((value >= 0) && (value <= 360))
                    course = value;
                else
                    Console.WriteLine("Курс самолета должен находиться в пределах от 0 до 360 градусов!!");
            }
        }
        // Высота полета самолета (от 2 до 10 километров - безопасный полет)
        private int height;
        public int Height
        {
            get
            {
                return height;
            }
            set
            {
                if ((value >= 2) && (value <= 10))
                    height = value;
                else
                    Console.WriteLine("Безопасная высота полета самолета должна находиться в пределах от 2 до 10 км.!!");
            }
        }
        // Скорость полета самолета (от 200 до 800 к/ч- безопасный полет)
        private int speed;
        public int Speed
        {
            get
            {
                return speed;
            }
            set
            {
                if ((value >= 200) && (value <= 800))
                    speed = value;
                else
                    Console.WriteLine("Безопасная скорость полета должна находиться в диапазоне от 200 до 800 км/ч!!");
            }
        }
        public TakeoffEventArgs(int c, int h, int s)
        {
            this.Course = c;
            this.Height = h;
            this.Speed = s;
        }
    }
    // Класс аргументов события ПОСАДКА
    public class BoardingEventArgs : EventArgs
    {
        // Курс посадочной полосы для приземления самолета (от 0 до 360 градусов)
        private int course;
        public int Course
        {
            get
            {
                return course;
            }
            set
            {
                if ((value >= 0) && (value <= 360))
                    course = value;
                else
                    Console.WriteLine("Курс самолета должен находиться в пределах от 0 до 360 градусов!!");
            }
        }
        // Высота полета самолета (при посадке конечное значение д.б. равно нулю)
        public int Height { get; set; }

        // Скорость полета самолета (при посадке конечное значение д.б. равно нулю)
        public int Speed { get; set; }

        public BoardingEventArgs(int c)
        {
            this.Course = c;
            this.Height = 0;
            this.Speed = 0;
        }
    }

    public class Aircraft
    {
        // Текущая скорость полета самолета, км/ч
        public int CurrentSpeed { get; set; }

       // Текущая высота полета самолета, км.
        public int CurrentHeight { get; set; }

        // Курс самолета, градусы
        private int CurrentCourse { get; set; }

        // Модель самолета
        public string ModelAir { get; set; }
        // Колличество посадочных мест в самолете
        public int NumOfSeats { get; set; }

        public Aircraft()
        {
            ModelAir = "Boing-747";
            NumOfSeats = 255;
            CurrentHeight = 0;
            CurrentSpeed = 0;
            CurrentCourse = 0;

        }

        // Событие ВЗЛЕТ
        public event TakeoffEventHandler Takeoff;
        // Метод, запускающий событие ВЗЛЕТ
        public void OnTakeoff(TakeoffEventArgs arg)
        {
            Console.WriteLine($"\n*********************Самолет\0{this.ModelAir}\0взлетает!!");
            Takeoff?.Invoke(this, arg);
        }
        //Обработчик события ВЗЛЕТ
        public void TakeoffHandler(object sender, TakeoffEventArgs arg)
        {
            this.ChangeSpeed(arg.Speed);
            this.ChangeHight(arg.Height);
            this.ChangeCourse(arg.Course);
        }
       
        // Событие ПОСАДКА
        public event BoardingEventHandler Boarding;
        // Метод, запускающий событие  ПОСАДКА
        public void OnBoarding(BoardingEventArgs arg)
        {
            Console.WriteLine($"\n*********************Самолет\0{this.ModelAir}\0идет на посадку!!");
            Boarding?.Invoke(this, arg);
        }
        //Обработчик события ПОСАДКА
        public void BoardingHandler(object sender, BoardingEventArgs arg)
        {
            this.ChangeCourse(arg.Course);
            this.ChangeHight(arg.Height);
            this.ChangeSpeed(arg.Speed); 
        }
        public void ShowInfoAir()
        {
            Console.WriteLine($"\nСамолет:\0{this.ModelAir}" +
                $"\nТекущая скорость полета:\0{this.CurrentSpeed}\0км/ч" +
                $"\nТекущая высота полета:\0{this.CurrentHeight}\0км." +
                $"\nТекущий курс полета:\0{ this.CurrentCourse}\0градусов");
        }

        // Необходимая (заданная) скорость полета самолета
        private int needSpeed;
        private int NeedSpeed
        {
            get
            {
                return needSpeed;
            }
            set
            {
                needSpeed = value;
            }
        }

        // Необходимая (заданная) высота полета самолета
        private int needHeight;
        private int NeedHeight
        {
            get
            {
                return needHeight;
            }
            set
            {
                needHeight = value;
            }
        }

        // Необходимый (заданный) курс полета самолета
        private int needCourse;
        private int NeedCourse
        {
            get
            {
                return needCourse;
            }
            set
            {
                needCourse = value;
            }
        }
        

        // Метод для изменения курса движения самолета 
        private void ChangeCourse(int c)
        {
            NeedCourse = c;
            Console.WriteLine($"\nТребуемый курс полета самолета: {this.NeedCourse}\0градусов.");
            Console.WriteLine($"\nТекущий курс полета самолета: {this.CurrentCourse}\0градусов.");
            Console.WriteLine($"\nНаправить самолет по заданному курсу {this.NeedCourse}\0градусов!");
            if (CurrentCourse < NeedCourse)
            {
                Console.WriteLine("Повернуть штурвал влево!");
                CurrentCourse = CurrentCourse + 60;
                Console.WriteLine($"Текущий курс полета самолета {this.CurrentCourse}\0градусов");
            }
            else if (CurrentCourse > NeedCourse)
            {
                Console.WriteLine("Повернуть штурвал вправо!");
                CurrentCourse = CurrentCourse - 60;
                Console.WriteLine($"Текущий курс полета самолета {this.CurrentCourse}\0градусов");
            }
            else if (CurrentCourse == NeedCourse)
            {
                Console.WriteLine("Самолет уже находится на заданном курсе!");
               
            }
            Console.WriteLine($"Направление самолета по заданному курсу {this.NeedCourse}\0градусов завершено!");
        }

        // Метод, для набора скорости
        private void MoveUp(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nРазогнать самолета до скорости {this.NeedSpeed}\0км/ч:");
            do
            {
                Console.WriteLine("Отвести рычаг управления двигателем от себя! Увеличить подачу топлива для ускорения двигателей!");
                CurrentSpeed = CurrentSpeed + 100;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0км/ч.");
            }
            while (CurrentSpeed < NeedSpeed);
            Console.WriteLine($"Разгон ТС до скорости {this.NeedSpeed}\0км/ч завершен!");
        }

        //  Метод для сброса скорости
        private void MoveDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"\nЗамедлить самолета до скорости {this.NeedSpeed}\0км/ч:");
            do
            {
                Console.WriteLine("Потянуть рычаг управления двигателем на себя! Сократить подачу топлива для замедления двигателей");
                CurrentSpeed = CurrentSpeed - 100;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0км/ч.");
            }
            while (CurrentSpeed > NeedSpeed);
            Console.WriteLine($"Снижение скорости самолета до уровня {this.NeedSpeed}\0км/ч завершено!");
        }

        // Метод для полной остановки 
        private void MoveStop()
        {
            NeedSpeed = 0;
            Console.WriteLine($"\nВыполнить полную остановку самолета:");
            do
            {
                Console.WriteLine("Перевести рычаг управления двигателем в нейтральное положение! Выключить подачу топлива и двигатели! Надавить на педаль тормоза!");
                CurrentSpeed = CurrentSpeed - 100;
                Console.WriteLine($"Текущая скорость самолета {this.CurrentSpeed}\0км/ч.");
            }
            while ((CurrentSpeed != NeedSpeed) || (CurrentSpeed < NeedSpeed));
            Console.WriteLine($"Выполнена полная остановка самолета!");
        }

        // Метод для изменения (набора/снижения) текущей скорости - в качестве аргумента передается желаемая скорость полета
        private void MovingForceUPDown(int s)
        {
            NeedSpeed = s;
            Console.WriteLine($"Текущая скорость самолета: {this.CurrentSpeed}\0км/ч.");
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
        private void HeightUp(int h)
        {
            this.NeedHeight = h;
            while (this.CurrentHeight != this.NeedHeight)
            {
                Console.WriteLine("Потянуть штурвал на себя!");
                this.CurrentHeight = this.CurrentHeight + 1;
                Console.WriteLine($"Текущая высота полета самолета {this.CurrentHeight}\0км.");
            }
        }

        // Сброс высоты
        private void HeightDown(int h)
        {
            this.NeedHeight = h;
            while ((this.CurrentHeight != this.NeedHeight) && (this.CurrentHeight >= 0))
            {
                Console.WriteLine("Оттолкнуть штурвал от себя!");
                this.CurrentHeight = this.CurrentHeight - 1;
                Console.WriteLine($"Текущая высота полета самолета {this.CurrentHeight}\0км.");
            }
        }

        // Метод для изменения ВЫСОТЫ полета самолета
        public void ChangeHight(int h)
        {
            Console.WriteLine($"\nТребуемая высота полета самолета: {h}\0км.");
            Console.WriteLine($"\nТекущая высота полета самолета: {this.CurrentHeight}\0км.");

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
            Console.WriteLine($"\nТребуемая скорость самолета: {s}\0км.");
            Console.WriteLine($"\nТекущая скорость самолета: {this.CurrentSpeed}\0км.");

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

