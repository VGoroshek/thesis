using PowerSetLibrary;
using System;
using System.Diagnostics;
using System.Linq;

namespace TestConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //Создаем тестовый массив
            MyTestClass[] testArr = new MyTestClass[]
            {
                new MyTestClass(1),
                new MyTestClass(2),
                new MyTestClass(3),
                new MyTestClass(4),
                new MyTestClass(5),
                new MyTestClass(6),
                new MyTestClass(7),
                new MyTestClass(8),
                new MyTestClass(9),
                new MyTestClass(10),
                new MyTestClass(11),
                new MyTestClass(12),
                new MyTestClass(13),
                new MyTestClass(14),
                new MyTestClass(15),
                new MyTestClass(16)
            };

            Stopwatch sw = Stopwatch.StartNew();//Засекаем время выполнения
            var comp = PSLibraryFile.CreateComponents(testArr);
            sw.Stop();
            //Вывод времени выполнения
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            for (int i = 0; i < comp.Count; i++)
                Console.WriteLine(String.Join(',', comp[i].Select(r => r.Id).ToArray()));
            Console.WriteLine();
            //STRONGLY

            sw = Stopwatch.StartNew();
            var compS = PSLibraryFile.CreateStrongComponents(testArr);
            sw.Stop();
            //Вывод времени выполнения
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            for (int i = 0; i < compS.Count; i++)
                Console.WriteLine(String.Join(',', compS[i].Select(r => r.Id).ToArray()));

            Console.WriteLine();
            Console.WriteLine("Clique");
            sw = Stopwatch.StartNew();//Засекаем время выполнения
            var MaxClique = PSLibraryFile.MaxClique(testArr);
            sw.Stop();
            //Вывод времени выполнения
            Console.WriteLine("{0} ms", sw.ElapsedMilliseconds);
            Console.WriteLine("[{0}]", string.Join(", ", MaxClique.Select(r => r.Id).ToArray()));




            Console.ReadKey();
            
        }
    }
}
