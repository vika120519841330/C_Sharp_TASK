/*Разработать класс-издатель NewsOperator предоставляющий услуги  рассылки информации по категориям(новости, погода, спорт, происшествия,
юмор). Также разработать классы-подписчики(не более 3х) для демонстрации подписки и обработки событий.*/

using System;

namespace NewsOperator
{
    // Делегат поддерживающий событие
    public delegate void NewsDeleg(string message);

    public class MyClass
    {
        static public string Title = "Рассылка подписчикам уведомлений о появлении новой информации определеной категории";

        public MyClass()
        {
            // Создание обьекта класса-издателя
            NewsOperator sourceEvent = new NewsOperator();
            sourceEvent.Message = "Отсутствует новая информация! Ждите обновления!";
            
            // Создание обьектов классов-подписчиков
            Subscriber_1 s1 = new Subscriber_1();
            Subscriber_2 s2 = new Subscriber_2();
            Subscriber_3 s3 = new Subscriber_3();

            // Подписка обьектов классов-подписчиков на события
            sourceEvent.News += s1.Handler_1_News;
            sourceEvent.Weather += s1.Handler_1_Weather;
            sourceEvent.Weather += s2.Handler_2_Weather;
            sourceEvent.Humor += s2.Handler_2_Humor;
            sourceEvent.Sport += s2.Handler_2_Sport;
            sourceEvent.Accidents += s3.Handler_3_Accidents;

            // Рассылка сообщений
            sourceEvent.InvokeNews("Появилась новая информация в категории <<NEWS>>");
            sourceEvent.InvokeWeather("Появилась новая информация в категории <<WEATHER>>");
            sourceEvent.InvokeSport("Появилась новая информация в категории <<SPORT>>");
            sourceEvent.InvokeAccidents("Появилась новая информация в категории <<ACCIDENTS>>");
            sourceEvent.InvokeHumor("Появилась новая информация в категории <<HUMOR>>");
        }
    }

    // Класс-издатель
    public class NewsOperator
    {
        // Свойство содержащее рассылаемую инф-цию
        public string Message { get; set; }

        // События по категориям
        public event NewsDeleg News;
        public event NewsDeleg Weather;
        public event NewsDeleg Sport;
        public event NewsDeleg Accidents;
        public event NewsDeleg Humor;

        /*// Метод, инициирующий рассылку сообщения о наступлении определенной категории события всем, кто на нее подписан
        public void InvokeEvent(string mess)
        {
            Message = mess;
            News?.Invoke(Message);
            Weather?.Invoke(Message);
            Sport?.Invoke(Message);
            Accidents?.Invoke(Message);
            Humor?.Invoke(Message);
        }*/
        
        public void InvokeNews(string mess)
        {
            Message = mess;
            News?.Invoke(Message);
        }
        public void InvokeWeather(string mess)
        {
            Message = mess;
            Weather?.Invoke(Message);
        }
        public void InvokeSport(string mess)
        {
            Message = mess;
            Sport?.Invoke(Message);
        }
        public void InvokeAccidents(string mess)
        {
            Message = mess;
            Accidents?.Invoke(Message);
        }
        public void InvokeHumor(string mess)
        {
            Message = mess;
            Humor?.Invoke(Message);
        }
        
    }

    // Классы-подписчики 
    public class Subscriber_1
    {
        // Обработчик события категории News
        public void Handler_1_News(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<НОВОСТИ>>\n");
        }
        // Обработчик события категории Weather
        public void Handler_1_Weather(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<ПОГОДА>>\n");
        }
    }
    public class Subscriber_2
    {
        // Обработчик события категории Weather
        public void Handler_2_Weather(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<ПОГОДА>>\n");
        }
        // Обработчик события категории Humor
        public void Handler_2_Humor(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<ЮМОР>>\n");
        }
        // Обработчик события категории Sport
        public void Handler_2_Sport(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<СПОРТ>>\n");
        }
    }
    public class Subscriber_3
    {
        // Обработчик события категории Accidents
        public void Handler_3_Accidents(string mess)
        {
            Console.WriteLine($"Подписчик\0{this.GetType().Name}\0 получил уведомление о новом событии" +
                                                                          $" из категории <<ПРОИСШЕСТВИЯ>>\n");
        }
    }
    public class Program
    {
        static void Main(string[] args)
        {
            Console.Title = MyClass.Title;
            Console.ForegroundColor = ConsoleColor.Black;
            
            new MyClass();

            Console.ReadLine();
        }
    }
}
