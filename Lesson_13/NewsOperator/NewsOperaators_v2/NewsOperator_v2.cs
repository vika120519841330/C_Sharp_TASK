/*Разработать класс-издатель NewsOperator предоставляющий услуги  рассылки информации по категориям(новости, погода, спорт, происшествия,
юмор). Также разработать классы-подписчики(не более 3х) для демонстрации подписки и обработки событий.*/

using System;

namespace NewsOperator
{
    // Класс аргументов события
    public class NewsEventArgs : EventArgs
    {
        public string Message { get; set; }
        public NewsEventArgs(string mess)
        {
            Message = mess;
        } 
    }

    // Делегат поддерживающий событие
    public delegate void NewsEventHandler(object source, NewsEventArgs arg);
    
    // Класс-издатель
    public class NewsOperator
    {
        // Событие
        public event NewsEventHandler SomeNewsEvent;

       
        // Метод, инициирующий рассылку сообщения о наступлении определенной категории события всем, кто на нее подписан
        public void InvokeEvent(NewsEventArgs arg)
        {
            SomeNewsEvent?.Invoke(this, arg);
        }
    }

    // Классы-подписчики 
    public class Subscriber_1
    {
        // Обработчик события
        public void Handler_1(object source, NewsEventArgs arg)
        {
            if ((arg.Message == "ACCIDENTS") || (arg.Message == "HUMOR"))
                Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<{arg.Message}>>\n");
        }
        
    }
    public class Subscriber_2
    {
        // Обработчик события  
        public void Handler_2(object source, NewsEventArgs arg)
        {
            if( (arg.Message == "NEWS") || (arg.Message == "HUMOR") )
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<{arg.Message}>>>\n");
        }
       
    }
    public class Subscriber_3
    {
        // Обработчик события  
        public void Handler_3(object source, NewsEventArgs arg)
        {
            if ( (arg.Message == "WEATHER") || (arg.Message == "SPORT") )
                Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<{arg.Message}>>>\n");
        }
    }
    public class MyClass
    {
        static public string Title = "Рассылка подписчикам уведомлений о появлении новой информации определеной категории";

        public MyClass()
        {
            // Создание обьекта класса-издателя
            NewsOperator sourceEvent = new NewsOperator();
        
            // Создание обьектов классов-подписчиков
            Subscriber_1 s1 = new Subscriber_1();
            Subscriber_2 s2 = new Subscriber_2();
            Subscriber_3 s3 = new Subscriber_3();

            // Подписка обьектов классов-подписчиков на события
            sourceEvent.SomeNewsEvent += new NewsEventHandler(s1.Handler_1);
            sourceEvent.SomeNewsEvent += new NewsEventHandler(s2.Handler_2);
            sourceEvent.SomeNewsEvent += new NewsEventHandler(s3.Handler_3);

            // Активизация процесса рассылки уведомлений о 
            NewsEventArgs arg_news = new NewsEventArgs("NEWS");
            sourceEvent.InvokeEvent(arg_news);

            NewsEventArgs arg_sport = new NewsEventArgs("SPORT");
            sourceEvent.InvokeEvent(arg_sport);

            NewsEventArgs arg_humor = new NewsEventArgs("HUMOR");
            sourceEvent.InvokeEvent(arg_humor);

            NewsEventArgs arg_accid = new NewsEventArgs("ACCIDENTS");
            sourceEvent.InvokeEvent(arg_accid);

            NewsEventArgs arg_weather = new NewsEventArgs("WEATHER");
            sourceEvent.InvokeEvent(arg_weather);
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = MyClass.Title;
            Console.ForegroundColor = ConsoleColor.Blue;

            new MyClass();

            Console.ReadLine();
        }
    }
}
