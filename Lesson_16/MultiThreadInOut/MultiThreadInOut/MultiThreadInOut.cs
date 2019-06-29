/* Необходимо создать приложение, в котором создаются 3 потока и одновременно выполняют чтение из отдельных файлов(т.е. 1й дочерний поток из 1го файла,
2й дочерний поток из 2го файла, 3й дочерний поток из 3го файла). Каждый поток, выполнив чтение из «своего» файла сразу должен приступить к сохранению 
прочитанной информации в один общий для всех потоков файл №4, который изначально – пустой.
Учитывая, что все дочерние потоки читают/пишут одновременно, то необходимо использовать доступные средства синхронизации(например, lock),
чтобы разграничить этап финальной корректной записи в конечный файл(т.е.в конечном файле не должно быть перемешивания
информации из-за одновременной записи потоками в файл). Sleep использовать нельзя. Главный поток может ожидать окончания работы дочерних потоков,
а может и завершить свою работу сразу после запуска дочерних потоков – на ваше усмотрение.Информация в файлах –
несколько строк текста – например – куплеты вашей любимой песни.*/

using System;
using System.IO;
using System.Threading;
using System.Collections.Generic;

namespace MultiThread
{
    class Program
    {
        public static string path0 = @"D:\SongDirrectory";
        public static string path1 = @"D:\SongDir\File_1.txt";
        public static string path2 = @"D:\SongDir\File_2.txt";
        public static string path3 = @"D:\SongDir\File_3.txt";
        public static string path4 = @"D:\SongDir\File_4.txt";
        public static object obj = new object();
        public static List<string> ArrCouplet= new List<string>();
   
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
                using (StreamWriter sw = new StreamWriter(path4))
                {
                    foreach (string c in (List<string>)ArrCouplet)
                        sw.WriteLine(c);
                }
                Console.WriteLine($"Поток ID: {Thread.CurrentThread.ManagedThreadId} завершил запись куплета в общий файл!");
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
        public static void Main()
        {
            Console.WriteLine($"Главный поток ID: {Thread.CurrentThread.ManagedThreadId} начал работу");

            // Создание дирректории для хранения файлов
            Directory.CreateDirectory(path0);

            //Просмотр инфо по дирректории 
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
            Console.WriteLine($"Начать запись в файл File_1!");
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

            // СЧИТЫВАНИЕ 3-МЯ ПОТОКАМИ ИЗ 3-Х ФАЙЛОВ ОДНОВРЕМЕННО
            // Создание трех параллельных потоков
            var thread01 = new Thread(new ParameterizedThreadStart(ReedFiles));
            var thread02 = new Thread(new ParameterizedThreadStart(ReedFiles));
            var thread03 = new Thread(new ParameterizedThreadStart(ReedFiles));

            // Запуск трех параллельных потоков
            thread01.Start(path1);
            thread02.Start(path2);
            thread03.Start(path3);

            // Ожидание главным потоком, завершения работы всех трех вторичных потоков.
            thread01.Join();
            thread02.Join();
            thread03.Join();

            // ЗАПИСЬ 3-МЯ ПОТОКАМИ ПООЧЕРЕДНО В ПУСТОЙ 4-ЫЙ ФАЙЛ
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

            Console.WriteLine($"Главный поток ID: {Thread.CurrentThread.ManagedThreadId} завершился.");

            // Задержка.
           // Console.ReadKey();
        }
    }
}
