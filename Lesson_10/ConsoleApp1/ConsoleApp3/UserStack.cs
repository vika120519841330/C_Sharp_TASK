/*Создать пользовательский класс, реализующий основную логику Stack для работы с элементами типа System.Int32
Реализовать методы Push(int item), Pop(), Peek(), свойства для чтения bool IsEmpty, int Count.
Класс должен содержать в себе 2 конструктора – 1 с входным параметром – начальной емкостью стека, 
второй – конструктор по умолчанию без параметров.
Хранение элементов внутри класса выполнить с использованием одного из ранее известных инструментов, 
подходящих для хранения нескольких объектов и позволяющих решить поставленную задачу.*/
using System;
using System.Collections.Generic;

namespace ConsoleApp3
{
    class UserStackDemo
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Демонстрация функционирования <<СТЕКА>> №1:\n");
            Stack stack1 = new Stack();
            stack1.Push(10);
            stack1.Push(127);
            int[] val = new int[] { 11, 25, 0, 15, -6, 100, 0 };
            stack1.Push(val);
            stack1.ShowStack();
            stack1.Peek();
            stack1.Peek();
            stack1.ShowStack();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.Pop();
            stack1.ShowStack();
        }
    }
    class Stack
    {
        public List<Int32> stl; // ссылка на базовую коллекцию
        public int top; // индекс вершины стека
        // Конструктор по умолчанию
        public Stack()
        {
            stl = new List<Int32>();
            top = 0;
        }

        // Пользовательский конструктор
        public Stack(int size)
        {
            stl = new List<Int32>(size);
            top = 0;
        }

        // Свойство, возвращающее логическое значение истинности или ложности утверждения, что стек пуст(только для чтения)
        public bool IsEmpty
        {
            get
            {
                return (top == 0);
            }
        }

        // Свойство, возвращающее колличество элементов, хранящихся в настоящий момент в стеке (только для чтения)
        public int Count
        {
            get
            {
                return top;
            }
        }

        // Метод для помещения значений в стек
        public void Push(int val)
        {
            Console.WriteLine($"Поместить в СТЕК новое значение:\0{val}");
            stl.Add(val);
            top++;
        }
        // Метод для помещения группы значений в стек - перегрузка
        public void Push(int []val)
        {
            for (int i = 0; i < val.Length; ++i)
            {
                stl.Add(val[i]);
                Console.WriteLine($"Поместить в СТЕК новое значение:\0{val[i]}");
                top++;
            }
        }

        // Метод для извлечения и удаления извлеченного значения из стека 
        public int Pop()
        {
            if (top == 0)
            {
                Console.WriteLine("Стек пуст!");
                return 0;
            }
            else
            {
                top--;
                Console.WriteLine($"Извлечь и удалить из СТЕКа последнее добавленное значение:\0{stl[top]}");
                int temp = stl[top]; // сохранение извлекаемого значения в локальной переменной
                stl.RemoveAt(top);
                return temp;
            }
        }
        
        // Метод для извлечения без последующего удаления извлеченного значения из стека 
        public int Peek()
        {
            if (top == 0)
            {
                Console.WriteLine("Стек пуст!");
                return 0;
            }
            else
            {
                top--;
                Console.WriteLine($"Извлечь без удаления из СТЕКа последнее добавленное значение:\0{stl[top]}");
                int temp = stl[top];
                top++;
                return temp;
            }
        }

        // Метод для демонстрации содержимого стека
        public void ShowStack()
        {
            Console.WriteLine($"\nСодержимое стека:");
            for (int i = stl.Count-1; i >= 0; --i)
            {
                Console.WriteLine($"{stl[i]}");
            }
            Console.WriteLine();
        }
    }
}
