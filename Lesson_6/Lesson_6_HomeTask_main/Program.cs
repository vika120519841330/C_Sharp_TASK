using System;

namespace Lesson_6_HomeTask_main
{
    class PlayerDemo
    {
        static void Main(string[] args)
        {
            // Использование членов класса Player
            Player play_A = new Player();
            play_A.Ram = 128;
            Console.WriteLine($"Значение поля Ram для play_A: {play_A.Ram}");
            Console.WriteLine($"Значение поля Producer для play_A: {play_A.Producer}");
            Console.WriteLine();

            Player play_B = new Player(256);
            Console.WriteLine($"Значение поля Ram для play_B: {play_B.Ram}");
            Console.WriteLine($"Значение поля Producer для play_B: {play_B.Producer}");
            Console.WriteLine();

            Player play_С = new Player("ASUS", 512);
            Console.WriteLine($"Значение поля Ram для play_С: {play_С.Ram}");
            Console.WriteLine($"Значение поля Producer для play_С: {play_С.Producer}");
            Console.WriteLine();

            //Использование членов класса Album
            Album albA = new Album ();
            string[] listSinger = albA.FillAlbumSinger();
            Console.WriteLine("Список исполнителей:\t");
            foreach (string s in listSinger)
                Console.WriteLine($"-> {s}");
            Console.WriteLine();

            string[] listSong = albA.FillAlbumSong();
            Console.WriteLine("Список песен:\t");
            foreach (string s in listSong)
                Console.WriteLine($" -> {s}");
            Console.WriteLine("\n");

            albA.CollectionDictionary();

            Console.WriteLine($"\nИсполнитель песни <<Ласточки>>:  {albA["Ласточки"]}");
            Console.WriteLine($"\nЛяпис Трубецкой исполняет песню:  {albA[0]}");
            Console.WriteLine($"\nДемонстрация выхода за пределы индексирования:  {albA[5]}");
            Console.WriteLine($"\nДемонстрация выхода за пределы индексирования:  {albA[-2]}");
            Console.WriteLine($"\nДемонстрация обращения к несуществующему элемента массива:  {albA["Аривидерчи"]}");
        }
    }
    class Player
    {
        readonly string producer;
        ushort ram;

        public Player() //конструктор по умолчанию
        {
            this.producer = "SONY";
        }
       public Player(ushort r) : this() //пользовательский конструктор №1
        {
            this.Ram = r;
        }
        public Player (string p, ushort r) //пользовательский конструктор №2
        {
            this.producer = p;
            this.Ram = r;
        }
        public string Producer //свойство только для чтения из поля
        {
            get
            {
                return producer;
            }
        }
        public ushort Ram //свойство для чтения и записи из поля
        {
            get
            {
                return ram;
            }
            set
            {
                if (GetRam(value) == true)
                    ram = value;
                else
                {
                    Console.WriteLine("Объем памяти д.б. равен одному из следующих значений: 16, 32, 64, 128, 256 или 512 Гб!!");
                    ram = 16; // присвоение значения по умолчанию
                }
            }
        }
        // Метод, определяющий  правильность задаваемого обьема памяти
        public bool GetRam(ushort r)
        {
            ushort val = r;
            if (val == 16 || val == 32 || val == 64 || val == 128 || val == 256 || val == 512)
                return true;
            else return false;
        }
    }
    class Album 
    {
        string[] singer; //обьявление массива, содержащего список исполнителей
        string[] song; //обьявление массива, содержащего список песен

        //перегрузка индексаторов
        public string this[int index] //индексатор для доступа к массиву с песнями ПО ЧИСЛУ
        {
            get
            {
                if ((index < 0) || (index >= this.song.Length)) // при выполнении ХОТЯ БЫ ОДНОГО УСЛОВИЯ нарушаются границы массива и выдается уведомление об этом
                {
                    Console.WriteLine("Индекс должен находится в пределах длины АЛЬБОМА!!");
                    return null;
                }  
                else
                    return song[index];
            }
            set
            {
                song[index] = value;
            }
        }
        public string this[string index] //индексатор для доступа к массиву с исполнителями ПО СТРОКЕ
        {
            get
            {
                if (index is string)
                {
                    switch (index)
                    {
                        case "Ласточки": return singer[0]; break;
                        case "Бежать": return singer[1]; break;
                        case "Alejandro": return singer[2]; break;
                        case "Ода нашей любви": return singer[3]; break;
                        case "Одинокая птица": return singer[4]; break;
                        default:
                            Console.WriteLine("Такой песни нет в альбоме!!");
                            return null;
                    }
                }
                else
                {
                    Console.WriteLine("Значение индекса д.б. строкового типа!!");
                    return null;
                }     
            }
        }
        // Метод для инициализации массива содержащего список исполнителей
        public string[] FillAlbumSinger()
        {
            this.singer = new string[5] { "Ляпис Трубецкой", "Аня Шаркунова", "Lady Gaga", "Т9", "Вячеслав Бутусов" };
            return this.singer;
        }
        // Метод для инициализации массива содержащего список песен
        public string[] FillAlbumSong()
        {
            this.song = new string[5] { "Ласточки", "Бежать", "Alejandro", "Ода нашей любви", "Одинокая птица" };
            return this.song;
        }
        // Метод для организации коллекции-словаря с наименованиями исполнителей и их песен соответственно
        public void CollectionDictionary()
        {
            Console.WriteLine("Коллекция-словарь:");
            for (int i = 0; i < singer.Length; i++)
            {
                Console.WriteLine($"Исполнитель: {this[this[i]]} \t  -------> Песня: {this[i]}");
            } 
        }
    }
}


