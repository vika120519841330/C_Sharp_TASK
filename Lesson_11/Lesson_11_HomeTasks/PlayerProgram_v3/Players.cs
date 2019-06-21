using System;
using System.Collections;

namespace Players
{
    class PlayersDemo
    {
        static void Main(string[] args)
        {
            Panasonic panasonic = new Panasonic(Power.StdVoltage.V380);
            panasonic.ShowVoltage();

            Sony sony = new Sony(Power.StdVoltage.V380);
            sony.Voltage = Power.StdVoltage.V127;
            sony.ShowVoltage();
            Samsung samsung = new Samsung(Power.StdVoltage.V110);
            //SamsungInheritor samsung = new SamsungInheritor(Power.StdVoltage.V110);
            samsung.ShowVoltage();

            ArrayList playersList = new ArrayList();
            playersList.Add(panasonic);
            playersList.Add(sony);
            playersList.Add(samsung);


            IPlayer iplRef; // интерфейсная ссылка
            Power powRef; // ссылка на базовый (абстрактный) класс

            foreach (Power p in playersList)
            {
                Console.WriteLine($"Реализация всех методов (определенных или унаследованных) в плеере\0{p.GetType().Name}:");
                iplRef = (IPlayer)p;
                iplRef.Start();
                iplRef.Pause();
                iplRef.Start();
                iplRef.Stop();
                powRef = (Power)p;
                powRef.ShowVoltage();
                Console.WriteLine();
            }
        }
    }
    public interface IPlayer
    {
        void Pause();
        void Start();
        void Stop();
    }

    public class Power
    {
        public enum StdVoltage : int { V110 = 110, V127 = 127, V220 = 220, V380 = 380 };

        private StdVoltage voltage;
        public StdVoltage Voltage
        {
            get
            {
                for (StdVoltage v = StdVoltage.V110; v <= StdVoltage.V380; v++)
                {
                    if (voltage == v)
                    {
                        return voltage;
                    }
                }
                Console.WriteLine("Напряжение д.б. равно одному из следующих значений: 110, 127, 220 или 380 Вольт!!");
                return StdVoltage.V220; // возврат значения по умолчанию
            }
            set
            {
                for (StdVoltage v = StdVoltage.V110; v <= StdVoltage.V380; v++)
                {
                    if (value == (StdVoltage)v)
                        voltage = value;
                }
                if (voltage == 0)
                {
                    Console.WriteLine("Напряжение д.б. равно одному из следующих значений: 110, 127, 220 или 380 Вольт!!");
                    voltage = StdVoltage.V220; // присвоение значения по умолчанию
                }
            }
        }

        // Состояние проигрывателя ( стоп - 0, воспроизведение -1, пауза - 2)
        private int status = 0;
        public int Status
        {
            get
            {
                return status;
            }
            set
            {
                if ((value == 0) || (value == 1) || (value == 2))
                    status = value;
                else
                {
                    Console.WriteLine("Плеер может находится в одном из трех состояний:" +
                        "0 - STOP, 1 - PLAY, 2 - PAUSE");
                    return;
                }
            }
        }
        //public abstract void ShowVoltage();
        public virtual void ShowVoltage()
        {
            Console.WriteLine($"\nПлейер {this.GetType().Name} имеет следующий стандарт электропитания" +
               $" (значение входного напряжения электрического тока)\0{this.Voltage}.\n");
        }
    }
    public class Panasonic : Power, IPlayer
    {
        public Panasonic(StdVoltage v)
        {
            Voltage = v;
        }
        public override void ShowVoltage()
        {
            Console.WriteLine($"\nПлейер {this.GetType().Name} имеет следующий стандарт электропитания" +
                $" (значение входного напряжения электрического тока):\0{this.Voltage}.\n");
        }
        public void Start()
        {
            if ((this.Status == 0) || (this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PLAY>>.");
                this.Status = 1;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<PLAY>>!!");
            }
        }
        public void Pause()
        {
            if (this.Status == 1)
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PAUSE>>.");
                this.Status = 2;
            }
            else
            {
                Console.WriteLine($"Чтобы поставить плейер {this.GetType().Name} на паузу он должен находится в состоянии <<PLAY>>!!");
            }
        }
        public void Stop()
        {
            if ((this.Status == 1) || (this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<STOP>>.");
                this.Status = 0;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<STOP>>!!");
            }
        }
    }
    public class Sony : Power, IPlayer
    {
        public Sony (StdVoltage v)
        {
            Voltage = v;
        }
        public override void ShowVoltage()
        {
            Console.WriteLine($"\nПлейер {this.GetType().Name} имеет следующий стандарт электропитания" +
                $" (значение входного напряжения электрического тока):\0{this.Voltage}.\n");
        }
        public void Start()
        {
            if ((this.Status == 0) || (this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PLAY>>.");
                this.Status = 1;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<PLAY>>!!");
            }
        }
        public void Pause()
        {
            if (this.Status == 1)
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PAUSE>>.");
                this.Status = 2;
            }
            else
            {
                Console.WriteLine($"Чтобы поставить плейер {this.GetType().Name} на паузу он должен находится в состоянии <<PLAY>>!!");
            }
        }
        public void Stop()
        {
            if ((this.Status == 1) || (this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<STOP>>.");
                this.Status = 0;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<STOP>>!!");
            }
        }
    }
    public class Samsung : Power, IPlayer
    {
        public Samsung (StdVoltage v)
        {
            Voltage = v;
        }
        public void Start()
        {
            if ((this.Status == 0)||(this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PLAY>>.");
                this.Status = 1;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<PLAY>>!!");
            }
        }
        public void Pause()
        {
            if (this.Status == 1)
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<PAUSE>>.");
                this.Status = 2;
            }
            else
            {
                Console.WriteLine($"Чтобы поставить плейер {this.GetType().Name} на паузу он должен находится в состоянии <<PLAY>>!!");
            }
        }
        public void Stop()
        {
            if ((this.Status == 1) || (this.Status == 2))
            {
                Console.WriteLine($"Player\0{this.GetType().Name} is <<STOP>>.");
                this.Status = 0;
            }
            else
            {
                Console.WriteLine($"Плейер {this.GetType().Name} уже находится в состоянии <<STOP>>!!");
            }
        }
    }
    /*public class SamsungInheritor : Samsung
    {
        public SamsungInheritor (StdVoltage v) :base(v)
        {
            Voltage = v;
        }

        public override void ShowVoltage()
        {
            Console.WriteLine($"\nПлейер {this.GetType().Name} имеет следующий стандарт электропитания" +
                $" (значение входного напряжения электрического тока)\0{this.Voltage}.\n");
        }
    }*/
}