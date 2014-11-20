// Делегаты

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            MyClass ob = new MyClass();

            Deleg1 deleg1 = new Deleg1(ob.Method);
            Deleg2 deleg2 = new Deleg2(MyClass.MethodStat);
            Console.WriteLine(deleg1(3, true));

            int x = 2;
            deleg2(ref x);
            Console.WriteLine(x);

            Deligate3 deleg3 = new Deligate3(Program.Method);
            BaseClass bc = deleg3("Демонстрация ковариантности делегатов прошла успешно!!!");
            Console.WriteLine(bc.name);
            Console.ReadKey();
        }

        static SomeClass Method(string name)
        {
            return new SomeClass(name);
        }
    }

    delegate BaseClass Deligate3 (string name);

    class BaseClass
    {
        public string name;
        public BaseClass (string name)
        {
            this.name = name;
        }
    }

    class SomeClass : BaseClass
    {
        public SomeClass(string name) : base(name) {}
    }

    class MyClass
    {
        public string Method(int x, bool flag)
        {
            return String.Format("Получилось!   " + x + "  " + flag);
        }

        public static void MethodStat(ref int x)
        {
            x *= x;
        }
    }

    delegate string Deleg1 (int j, bool k);

    delegate void Deleg2 (ref int j);
}
