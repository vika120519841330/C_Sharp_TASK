using System;

namespace oldVariant
{
    class Program
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
            Album albA = new Album();

            Console.WriteLine("Список исполнителей:\t");
            foreach (string s in albA.singer)
                Console.WriteLine($"-> {s}");
            Console.WriteLine();

            Console.WriteLine("Список песен:\t");
            foreach (string s in albA.song)
                Console.WriteLine($" -> {s}");
            Console.WriteLine("\n");

            albA.CollectionDictionary();

            Console.WriteLine($"\nИсполнитель песни <<Ласточки>>:  {albA["Ласточки"]}");
            Console.WriteLine($"Ляпис Трубецкой исполняет песню:  {albA[0]}");
            Console.WriteLine($"\nДемонстрация выхода за пределы индексирования:");
            Console.Write($"{albA[5]}");
            Console.Write($"{albA[-2]}");
            Console.WriteLine($"\nДемонстрация обращения к несуществующему элементу массива:");
            Console.WriteLine($"{albA["Аривидерчи"]}");

            Console.WriteLine($"\nДемонстрация применения сортировки списка исполнителей и списка песен:\n");
            Album albB = new Album();
            albB.singer.SortStrings(); // Вызов статического метода расширения(сортировка массива с исполнителями) способом №1
            Console.WriteLine("\n");
            StaticClass.SortStrings(albB.song); // Вызов статического метода расширения(сортировка массива с песнями) способом №2
            Console.WriteLine();

            Console.WriteLine($"\nДемонстрация добавления  НОВОГО элемента в альбом с исполнителями и песнями:\n");
            Album albC = new Album();

            string[] temp1 = new string[albC.singer.Length]; //Временный массив для вызова метода расширения НА СЕБЯ

            temp1.Add(ref albC.singer, ref albC.song, "Михаил Круг", "Владимирский централ"); // Вызов статического метода расширения способом №1
            Console.WriteLine($"Длина обновленного расширенного массива с композициями равна: {albC.singer.Length}");
            Console.WriteLine($"Длина обновленного расширенного массива с исполнителями равна: {albC.song.Length}");
            Console.WriteLine();

            temp1 = new string[albC.singer.Length];

            StaticClass.Add(temp1, ref albC.singer, ref albC.song, "Ночные снайперы", "31 весна"); // Вызов статического метода расширения способом №2
            Console.WriteLine($"Длина обновленного расширенного массива с композициями равна: {albC.singer.Length}");
            Console.WriteLine($"Длина обновленного расширенного массива с исполнителями равна: {albC.song.Length}");
            Console.WriteLine();

            StaticClass.Add(ref albC.singer, ref albC.song, "Madonna", "You see"); // Вызов статического метода (НЕ РАСШИРЯЮЩЕГО)
            Console.WriteLine($"Длина обновленного расширенного массива с композициями равна: {albC.singer.Length}");
            Console.WriteLine($"Длина обновленного расширенного массива с исполнителями равна: {albC.song.Length}");
            Console.WriteLine();

            Console.WriteLine($"Демонстрация обращения к ранее существовавшему элементу альбома ПО ИНДЕКСУ: {albC[1]}");
            Console.WriteLine($"Демонстрация обращения к только что добавленному НОВОМУ элементу альбома ПО ИНДЕКСУ: {albC[7]}");
            Console.WriteLine($"Демонстрация обращения к ранее существовавшему элементу альбома ПО СТРОКЕ: {albC["Бежать"]}");
            Console.WriteLine($"Демонстрация обращения к только что добавленному НОВОМУ элементу альбома ПО СТРОКЕ: {albC["Владимирский централ"]}");
            Console.WriteLine();
        }
    }
    class Player
    {
        readonly string producer;// Поле только для чтения
        ushort ram;

        public Player() //Конструктор по умолчанию
        {
            this.producer = "SONY";
        }
        public Player(ushort r) : this() //Пользовательский конструктор №1
        {
            this.Ram = r;
        }
        public Player(string p, ushort r) //Пользовательский конструктор №2
        {
            this.producer = p;
            this.Ram = r;
        }
        public string Producer //Свойство только для чтения из поля
        {
            get
            {
                return producer;
            }
        }
        public ushort Ram //Свойство для чтения и записи из поля
        {
            get
            {
                return ram;
            }
            set
            {
                if (SetRam(value) == true)
                    ram = value;
                else
                {
                    Console.WriteLine("Объем памяти д.б. равен одному из следующих значений: 16, 32, 64, 128, 256 или 512 Гб!!");
                    ram = 16; // присвоение значения по умолчанию
                }
            }
        }
        // Метод, определяющий  правильность задаваемого обьема памяти
        public bool SetRam(ushort r)
        {
            ushort val = r;
            if (val == 16 || val == 32 || val == 64 || val == 128 || val == 256 || val == 512)
                return true;
            else return false;
        }
    }
    class Album
    {
        public string[] singer; //Обьявление массива, содержащего список исполнителей
        public string[] song; // Обьявление массива, содержащего список песен

        public Album() // Конструктор по умолчанию
        {
            singer = this.FillAlbumSinger();
            song = this.FillAlbumSong();
        }
        // Перегрузка конструкторов
        public Album(string[] si, string[] so) // Пользовательский конструктор
        {
            singer = si;
            song = so;
        }

        //Перегрузка индексаторов
        public string this[int index] //Индексатор для доступа к массиву с песнями ПО ЧИСЛУ
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
                        case "Владимирский централ": return singer[5]; break;
                        case "31 весна": return singer[6]; break;
                        case "You see": return singer[7]; break;
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
        // Закрытый метод для инициализации массива содержащего список исполнителей
        private string[] FillAlbumSinger()
        {
            this.singer = new string[5] { "Ляпис Трубецкой", "Аня Шаркунова", "Lady Gaga", "Т9", "Вячеслав Бутусов" };
            return this.singer;
        }
        // Закрытый метод для инициализации массива содержащего список песен
        private string[] FillAlbumSong()
        {
            this.song = new string[5] { "Ласточки", "Бежать", "Alejandro", "Ода нашей любви", "Одинокая птица" };
            return this.song;
        }
        // Метод для организации коллекции-словаря с наименованиями исполнителей и их песнями соответственно
        public void CollectionDictionary()
        {
            Console.WriteLine("Коллекция-словарь:");
            for (int i = 0; i < singer.Length; i++)
            {
                Console.WriteLine($"Исполнитель: {this[this[i]]} \t  -------> Песня: {this[i]}");
            }
        }
    }
    // Статический класс с методами расширения
    public static class StaticClass
    {
        //Метод расширения для сортировки массива строк string[]
        public static void SortStrings(this string[] arr)
        {
            Console.WriteLine($"\nМассив строк ДО сортировки:");
            foreach (string s in arr)
                Console.Write($"{s}\0");
            Console.WriteLine();

            Array.Sort(arr);

            Console.WriteLine($"\nМассив строк ПОСЛЕ сортировки:");
            foreach (string s in arr)
                Console.Write($"{s}\0");
            Console.WriteLine();
        }
        // Метод для добавления в коллекцию типа Album новых элементов
        public static void Add(ref string[] singer, ref string[] song, string si, string so)
        {
            int lenghtInitial = singer.Length; //локальная переменная хранящая первоначальную длину списка исполнителей/песен
            Array.Resize(ref singer, singer.Length + 1);
            singer[lenghtInitial] = si;
            Console.WriteLine($"Список исполнителей ПОСЛЕ добавления еще одного исполнителя:");
            for (int i = 0; i < singer.Length; ++i)
                Console.WriteLine($"{i}--->{singer[i]}");

            Console.WriteLine();

            Array.Resize(ref song, song.Length + 1);
            song[lenghtInitial] = so;
            Console.WriteLine($"Список песен ПОСЛЕ добавления еще одной композиции:");
            for (int i = 0; i < song.Length; ++i)
                Console.WriteLine($"{i}--->{song[i]}");

            Console.WriteLine();
        }

        // Перегружаемый метод расширения для добавления в коллекцию типа Album новых элементов
        public static void Add(this string[] temp, ref string[] singer, ref string[] song, string si, string so)
        {
            int lenghtInitial = temp.Length; //локальная переменная хранящая первоначальную длину списка исполнителей/песен

            //Расширение списка исполнителей на одну единицу
            Array.Resize(ref singer, singer.Length + 1);
            singer[lenghtInitial] = si;
            Console.WriteLine($"Список исполнителей ПОСЛЕ добавления еще одного исполнителя:");
            for (int i = 0; i < singer.Length; ++i)
                Console.WriteLine($"{i}--->{singer[i]}");
            Console.WriteLine();

            //Расширение списка песен на одну единицу
            Array.Resize(ref song, song.Length + 1);
            song[lenghtInitial] = so;
            Console.WriteLine($"Список песен ПОСЛЕ добавления еще одной композиции:");
            for (int i = 0; i < song.Length; ++i)
                Console.WriteLine($"{i}--->{song[i]}");
            Console.WriteLine();
        }
    }
}
