/*Создать класс, представляющий учебный класс ClassRoom. Создайте класс ученик Pupil. В теле класса создайте методы void Study(), void Read(),
void Write(), void Relax(). Создайте 3 производных класса ExcelentPupil, GoodPupil, BadPupil от класса базового класса Pupil и переопределите каждый из методов, 
в зависимости от успеваемости ученика.Конструктор класса ClassRoom принимает аргументы типа Pupil, класс должен состоять
из 4 учеников. Предусмотрите возможность того, что пользователь может передать 2 или 3 аргумента. 
Выведите информацию о том, как все ученики экземпляра класса ClassRoom умеют учиться, читать, писать, отдыхать.*/

using System;
using System.Collections.Generic;

namespace Pupil
{
    class Program
    {
        static void Main(string[] args)
        {
            ExcelentPupil pupul1 = new ExcelentPupil();
            GoodPupil pupul2 = new GoodPupil();
            BadPupil pupul3 = new BadPupil();
            GoodPupil pupul4 = new GoodPupil();

            ClassRoom classA = new ClassRoom(pupul1, pupul2, pupul3);
            classA.AddPupilInClass(pupul4);

            classA.ShowInfo();
        }
    }
    class ClassRoom
    {
        public List<Pupil> PupilList = new List<Pupil>(4);
        public ClassRoom(Pupil p)
        {
            PupilList.Add(p);
        }
        public ClassRoom(Pupil p1, Pupil p2)
        {
            PupilList.Add(p1);
            PupilList.Add(p2);
        }
        public ClassRoom(Pupil p1, Pupil p2, Pupil p3)
        {
            PupilList.Add(p1);
            PupilList.Add(p2);
            PupilList.Add(p3);
        }
        public void AddPupilInClass(Pupil p)
        {
            this.PupilList.Add(p);
        }

        public void ShowInfo()
        {
            Type c = this.GetType();
            Console.WriteLine($"Информация об учениках класса:\0{c.Name}");

            foreach (Pupil p in this.PupilList)
            {
                Type t = p.GetType();
                Console.WriteLine($"\nУченик:\0{t.Name}");
                Console.Write("\n-->");
                p.Study();
                Console.Write("\n-->");
                p.Read();
                Console.Write("\n-->");
                p.Write();
                Console.Write("\n-->");
                p.Relax();
                Console.Write("\n");
            }
        }
    }
    class Pupil
    {
        public virtual void Study()
        {
            Console.WriteLine("Оценка качества учебы");
        }
        public virtual void Read()
        {
            Console.WriteLine("Оценка качества чтения");
        }
        public virtual void Write()
        {
            Console.WriteLine("Оценка качества письма");
        }
        public virtual void Relax()
        {
            Console.WriteLine("Оценка качества отдыха");
        }
    }
    class ExcelentPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Оценка качества учебы: *****");
        }
        public override void Read()
        {
            Console.WriteLine("Оценка качества чтения: *****");
        }
        public override void Write()
        {
            Console.WriteLine("Оценка качества письма: *****");
        }
        public override void Relax()
        {
            Console.WriteLine("Оценка качества отдыха: *****");
        }
    }
    class GoodPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Оценка качества учебы: ****");
        }
        public override void Read()
        {
            Console.WriteLine("Оценка качества чтения: ****");
        }
        public override void Write()
        {
            Console.WriteLine("Оценка качества письма: ****");
        }
        public override void Relax()
        {
            Console.WriteLine("Оценка качества отдыха: ****");
        }
    }
    class BadPupil : Pupil
    {
        public override void Study()
        {
            Console.WriteLine("Оценка качества учебы: ***");
        }
        public override void Read()
        {
            Console.WriteLine("Оценка качества чтения: ***");
        }
        public override void Write()
        {
            Console.WriteLine("Оценка качества письма: ***");
        }
        public override void Relax()
        {
            Console.WriteLine("Оценка качества отдыха: ***");
        }
    }
}
