using System;
using System.Collections.Generic;

namespace Player
{
    class PlayerApply
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

            // Создание  первого пустого (не наполненного треками) альбома
            Album albA = new Album("Альбом №1");
            // Создание песни и добавление ее в первый альбом
            Song song1 = new Song("Песня_2", "Исполнитель_2", 2014);
            Song song2 = new Song("Песня_1", "Исполнитель_1", 2013);
            albA.FillAlbum(song1);
            albA.FillAlbum(song2);
            // Одновременное создание песни с ее добавлением в первый альбом
            albA.FillAlbum("Песня_3", "Испольнитель_3", 2015);
            // Отображение содержимого первого альбома
            albA.ShowAlb();

            Console.WriteLine();

            // Создание нового второго альбома с одновременным копированием в него всего содержимого первого альбома
            Album albB = new Album(albA);
            // Отображение содержимого второго альбома
            albB.ShowAlb();

            Console.WriteLine();

            //Удаление всего содержимого первого альбома
            albA.DeliteAlb();
            // Отображение содержимого первого альбома
            albA.ShowAlb();
            Console.WriteLine();

            // Отображение содержимого второго альбома
            albB.ShowAlb();
            Console.WriteLine();

            // Создание третьего альбома и наполнение его песнями из другого альбома
            Album albC = new Album("Альбом №3");
            albC.FillAlbum(albB["Песня_2"]);
            albC.FillAlbum(albB[1]);
            albC.FillAlbum(albB[2]);

            // Отображение содержимого третьего альбома
            albC.ShowAlb();

            // Сортировка содержимого второго альбома по наименованию песни (методом НЕ РАСШИРЕНИЯ)
            albB.SortAlb();

            // Сортировка содержимого третьего альбома по наименованию песни (методом РАСШИРЕНИЯ - двумя вариантами вызова)
            StaticClass.SortAlbom(albC);
            albC.SortAlbom();

            // Использование расширяющих методов для добавления в альбом песен
            albC.AddSong(new Song("Песня_5", "Исполнитель_5", 2010));
            Song song3 = new Song("Песня_4", "Исполнитель_4", 2016);
            StaticClass.AddSong(albC, song3);

            // Отсортировать обновленный альбом
            albC.SortAlbom();
        }
    }
    public class Player
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

    // Класс, реализующий интерфейс IComparer для сортировки альбома с песнями по наименованию песни
    class MyComparer : IComparer <Song>
    {
        public int Compare(Song s1, Song s2)
        {
            return s1.SongTitle.CompareTo(s2.SongTitle);

        }
    }
    public class Song
    {
        private string songTitle; // закрытое поле Наименование песни
        private string singerName; // закрытое поле Наименование исполнителя
        private int songReleaseYear; // закрытое поле Год выпуска песни

        // Пользовательский конструктор
        public Song(string st, string sn, int sry)
        {
            SongTitle = st;
            SingerName = sn;
            SongReleaseYear = sry;
        }

        // Открытые свойства для закрытых полей
        public string SongTitle { get; set; }
        public string SingerName { get; set; }
        public int SongReleaseYear { get; set; }
    }

    public class Album 
    {
        // Закрытое поле наименования альбома
        private string albumTitle;

        // Открытое свойство, обеспечивающее доступ к наименованию альбома для записи или считывания
        public string AlbumTitle
        {
            get
            {
                return albumTitle;
            }
            set
            {
                albumTitle = value;
            }
        }
        //Закрытая обобщенная коллекция, содержащая список экземпляров класса Song
        private List<Song> songList = new List<Song>();

        //Открытое свойство, обеспечивающее доступ к закрытой коллекции, содержащей список экземпляров класса Song
        public List<Song> SongList
        {
            get
            {
                return songList;
            }
            set
            {
                songList = value;
            }
        }

        // Индексатор для доступа к песне по номеру
        public Song this[int ind]
        {
            get
            {
                if (ind >= 0 && ind < SongList.Count)
                    return SongList[ind];
                else
                {
                    Console.WriteLine($"Номер трека должен находится в пределах от 0 до {SongList.Count-1}");
                    return null;
                }
            }
            set
            {
                if ( (ind >= 0) && (ind < SongList.Count) )
                    SongList[ind] = value;
                else
                {
                    Console.WriteLine($"Номер трека должен находится в пределах от 0 до {SongList.Count-1}");
                    SongList[ind] = null;
                }
            }
        }

        // Индексатор для доступа к содержимому альбома по названию песни
        public Song this[string ind]
        {
            get
            {
                for (int i = 0; i < SongList.Count; i++)
                {
                    if (SongList[i].SongTitle == ind)
                        return SongList[i];  
                }
                Console.WriteLine($"В альбоме нет трека с таким наименованием!!");
                return null;
            }
            set
            {
                int i;
                for (i = 0; i < SongList.Count; i++)
                {
                    if (SongList[i].SongTitle == ind)
                    {
                        SongList[i] = value;
                        return;
                    }      
                }
                Console.WriteLine($"В альбоме нет трека с таким наименованием!!");
                SongList[i] = null;
            }
        }

        // Конструктор по умолчанию
        public Album() 
        {
            AlbumTitle = "Неизвестный альбом";

        }
        // Пользовательский конструктор №1
        public Album(string at)
        {
            AlbumTitle = at;
        }
        // Пользовательский конструктор №2
        public Album(Album anotherAlb) : this()
        {
            this.SongList.AddRange(anotherAlb.SongList);
        }
        // Пользовательский конструктор №3
        public Album(Album anotherAlb, string at) : this (at)
        {
            this.SongList.AddRange(anotherAlb.SongList);
        }


        // Закрытый метод для наполнения альбома песнями (вариант №1)
        public void FillAlbum(string st, string sn, int sry)
        {
            this.SongList.Add(new Song(st, sn, sry));
        }
        // Закрытый метод для наполнения альбома песнями (вариант №2)
        public void FillAlbum(Song s)
        {
            this.SongList.Add(s);
        }
        // Закрытый метод для наполнения альбома песнями (вариант №3 - в конец существующего альбома добавляет новую коллекцию )
        private void FillAlbum(List<Song> otherList)
        {
            this.SongList.InsertRange(this.SongList.Count-1, otherList);
        }

        // Метод для отображения содержимого альбома
        public void ShowAlb()
        {
            Console.WriteLine($"Альбом: <<{this.AlbumTitle}>>");
            if (this.SongList.Count != null)
            {
                foreach (Song s in this.SongList)
                    Console.WriteLine($"Песня:\0<<{s.SongTitle}>>\t\0Исполнитель:\0<<{s.SingerName}>>\t\0Год выпуска песни:\0{s.SongReleaseYear}");
            }
            else Console.WriteLine("Альбом пуст!!");
        }

        // Метод для удаления всего содержимого альбома
        public void DeliteAlb()
        {
            Console.WriteLine($"Вы уверенны, что хотите удалить ВСЁ содержимое альбома {this.AlbumTitle}?" +
                $"\nНажмите плюс + для продолжения");
            if (Console.ReadLine() == "+")
            {
                Console.WriteLine($"Альбом {this.AlbumTitle} очищен");
                this.SongList.Clear();
            }     
        }
        
        // Метод  для сортировки альбома с песнями по наименованию песни
        public void SortAlb()
        {
            Console.WriteLine($"\nСодержимое альбома {this.AlbumTitle} ДО сортировки:");
            this.ShowAlb();
            
            this.SongList.Sort(new MyComparer());

            Console.WriteLine($"\nСодержимое альбома {this.AlbumTitle} ПОСЛЕ сортировки:");
            this.ShowAlb();
        }
    }
    

    // Статический класс с методами расширения
    public static class StaticClass
    {
        //Метод расширения для сортировки альбома с песнями
         public static void SortAlbom(this Album alb)
         {
              Console.WriteLine($"\nСодержимое альбома ДО сортировки:");
              alb.ShowAlb();

              alb.SongList.Sort(new MyComparer());

              Console.WriteLine($"\nСодержимое альбома ПОСЛЕ сортировки:");
              alb.ShowAlb();
        }

        // Метод расширения для добавления в коллекцию типа Album новых элементов
        public static void AddSong(this Album alb, Song s)
        {
            Console.WriteLine($"\nСодержимое альбома ДО добавления еще одной композиции:");
            alb.ShowAlb();

            Console.WriteLine();

            alb.SongList.Add(s);

            Console.WriteLine($"\nСодержимое альбома ПОСЛЕ добавления еще одной композиции:");
            alb.ShowAlb();

            Console.WriteLine();
        }
    }
}


