using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace v2
{
    class Program
    {
        public static string path0 = @"D:\SongDirrectory";
        public static string path1 = @"D:\SongDirrectory\File_1.txt";
        public static string path2 = @"D:\SongDirrectory\File_2.txt";
        public static string path3 = @"D:\SongDirrectory\File_3.txt";
        public static string path4 = @"D:\SongDirrectory\File_4.txt";
        public static List<string> ArrCouplet = new List<string>();
        public static object obj = new object();

        // Метод чтения куплетов из файлов №1, 2 и 3 в один общий массив строк
        public static void ReedFiles(object path)
        {
            lock (obj)
            {
                Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId} начал считывание данных.");
                using (StreamReader sr = new StreamReader((string)path))
                {
                    while (!sr.EndOfStream)
                        ArrCouplet.Add(sr.ReadLine());
                }
                Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId} завершил считывание данных.");
            }
        }

        // Метод записи в общий файл №4 из общего массива строк
        public static void WriteFile(object ArrCouplet)
        {
            lock (obj)
            {
                Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId} начал запись куплета в общий файл!");
                using (StreamWriter sw = File.AppendText(path4))
                {
                    foreach (string c in (List<string>)ArrCouplet)
                        sw.WriteLine(c);
                }
                Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId} завершил запись куплета в общий файл!");
                ((List<string>)ArrCouplet).Clear();
            }
        }

        //Метод для отображения онформации о дирректории с файлами
        public static void ShowInfoDir(DirectoryInfo d)
        {
            if (d.Exists)
            {
                foreach (FileInfo f in d.GetFiles())
                    Console.WriteLine($"File: {f.Name}, size: {f.Length}.");
            }
        }

        // Метод для записи куплета песни в файл
        public static void SongIntoFile(string path, string song)
        {
            using (StreamWriter sw = File.AppendText(path))
            {
                sw.WriteLine(song);
            }
        }
        static void Main(string[] args)
        {
            Console.WriteLine($"Главный поток ID: {Thread.CurrentThread.ManagedThreadId} начал работу");

            // Создание дирректории для хранения файлов
            Directory.CreateDirectory(path0);

            //Просмотр инфо по дирректории с пустыми файлами
            ShowInfoDir(new DirectoryInfo(path0));

            // Запись инф-ции в файлы
            // в File_1
            List<string> CoupletArr1 = new List<string>
            {
                "Все также поднимается солнце.",
                "Но по-другому светит сейчас.",
                "Горели одинокие звёзды не для нас.",
                "Мы на рассвете мир потеряли.",
                "Разрушив между нами мосты.",
                "И в этом только два виноватых.",
                "Я и ты…"
            };
            Console.WriteLine($"Начать запись в файл!");
            foreach (string c in CoupletArr1)
                SongIntoFile(path1, c);
            Console.WriteLine($"Файл File_1 записан!");

            // в File_2
            List<string> CoupletArr2 = new List<string>
            {
                "Дважды в одну реку не войдешь.",
                "Раненое сердце не зашьешь.",
                "Я давно не видел свет в твоих глазах.",
                "Отплывали наши корабли.",
                "Были так несдержанно близки.",
                "Но теперь стоим на разных берегах."
            };
            Console.WriteLine($"Начать запись в файл File_2!");
            foreach (string c in CoupletArr2)
                SongIntoFile(path2, c);
            Console.WriteLine($"Файл File_2 записан!");

            //в File_3
            List<string> CoupletArr3 = new List<string>
           {
                "А все могло бы быть по другому.",
                "Любовь всегда возможно спасти.",
                "Мы выбрали другую дорогу.",
                "Два пути…"
           };
            Console.WriteLine($"Начать запись в файл File_3!");
            foreach (string c in CoupletArr3)
                SongIntoFile(path3, c);
            Console.WriteLine($"Файл File_3 записан!");

            //Просмотр инфо по дирректории после записи куплетов песни в первые три файла
            ShowInfoDir(new DirectoryInfo(path0));

            // Создание трех параллельных потоков для одновременного считывания каждым потоком из своего файла
            var thread01 = new Thread(new ParameterizedThreadStart(ReedFiles));
            var thread02 = new Thread(new ParameterizedThreadStart(ReedFiles));
            var thread03 = new Thread(new ParameterizedThreadStart(ReedFiles));

            // Запуск трех параллельных потоков
            thread01.Start(path1);
            thread02.Start(path2);
            thread03.Start(path3);

            // ЗАПИСЬ 3-МЯ ПОТОКАМИ СИНХРОНИЗИРОВАННО В ПУСТОЙ 4-ЫЙ ФАЙЛ

            // Создание трех параллельных потоков для одновременного считывания каждым потоком из своего файла
            var thread1 = new Thread(new ParameterizedThreadStart(WriteFile));
            var thread2 = new Thread(new ParameterizedThreadStart(WriteFile));
            var thread3 = new Thread(new ParameterizedThreadStart(WriteFile));

            // Запуск трех параллельных потоков
            thread1.Start(ArrCouplet);
            thread2.Start(ArrCouplet);
            thread3.Start(ArrCouplet);

            // Ожидание главным потоком, завершения работы всех трех вторичных потоков.
            thread1.Join();
            thread2.Join();
            thread3.Join();

            //Просмотр инфо по дирректории после записи всех куплетов в общий файл
            ShowInfoDir(new DirectoryInfo(path0));

            Console.WriteLine($"Главный поток ID: {Thread.CurrentThread.ManagedThreadId} завершился.");
        }
    }
}
