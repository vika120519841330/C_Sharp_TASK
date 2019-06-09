/*Создайте коллекцию, которая бы по свой структуре напоминала «родовое дерево» (имя человека, год рождения),
причем в нее можно добавлять/удалять нового родственника, есть возможность увидеть
всех наследников выбранного человека, отобрать родственников по году рождения.*/

using System;
using System.Collections.Generic;

namespace FamilyTree
{
    class Program
    {
        static void Main(string[] args)
        {
            Person p1 = new Person("Ira", 1959);
            Person p2 = new Person("Kolya", 1955);
            Person p3 = new Person("Valera", 1956);
            Person p4 = new Person("Janna", 1955);
            Person p5 = new Person("Vika", 1984);
            Person p6 = new Person("Yura", 1985);
            Person p7 = new Person("Timur", 2016);

            p7.AddParents(p5, p6);
            p5.AddParents(p3, p4);
            p6.AddParents(p1, p2);

            p6.AddHeritors(p7);
            p5.AddHeritors(p7);
            p1.AddHeritors(p6);
            p2.AddHeritors(p6);
            p3.AddHeritors(p5);
            p4.AddHeritors(p5);

            p1.ShowHeritors();
            p2.ShowHeritors();
            p3.ShowHeritors();
            p4.ShowHeritors();
            p5.ShowHeritors();
            p6.ShowHeritors();

            p5.ShowParents();
            p6.ShowParents();
            p7.ShowParents();
        }
    }

    class Person
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public Person(string n, int a)
        {
            Name = n;
            Age = a;
        }

        public Person[] parents = new Person[2];            // у каждого Person индивидуальный список с родителями

        public List<Person> heritors = new List<Person>(); // у каждого Person индивидуальный список с наследниками

        public Person Father
        {
            get
            {
                return parents[0];
            }
            set
            {
                parents[0] = value;
            }
        }

        protected Person Mother
        {
            get
            {
                return parents[1];
            }
            set
            {
                parents[1] = value;
            }
        }
        public void AddParents(Person f, Person m)
        {
            this.Father = f;
            this.Mother = m;
        }
    
        public void AddHeritors(Person p)
        {
            this.heritors.Add(p);
        }

        public void ShowHeritors ()
        {
            Console.WriteLine($"У Person {this.Name},\0год рождения {this.Age} следующие наследники:");
            for (int i = 0; i < this.heritors.Count; i++ )
            {
                int temp = i + 1;
                Console.WriteLine($"наследник №{temp}:\0{this.heritors[i].Name},\0год рождения:{this.heritors[i].Age}\n");
            }
        }
        public void ShowParents ()
        {
            Console.WriteLine($"У Person {this.Name},\0год рождения {this.Age} следующие родители:");
            Console.WriteLine($"отец:\0{this.parents[0].Name},\0год рождения:{this.parents[0].Age}\0" +
                    $"\nмать:\0{this.parents[1].Name},\0год рождения:{this.parents[1].Age}\n");
        }
    }
}
