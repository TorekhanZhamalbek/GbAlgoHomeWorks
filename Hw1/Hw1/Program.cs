using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;
using HomeWorksInterface;
using System.Reflection;

namespace Hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            Assembly asm = Assembly.LoadFrom("HomeWorks.dll");

            List<ILesson> tasks = new List<ILesson>();

            Type[] types = asm.GetTypes();

            for (int i = 0; i < types.Length; i++)
            {
                if (types[i].Name.Contains("Lesson"))
                {
                    tasks.Add((ILesson)Activator.CreateInstance(types[i]));
                }
            }

            bool start = true;

            while (start)
            {
                foreach (ILesson lesson in tasks)
                {
                    Console.WriteLine($"Введите - {lesson.Name} для вызова задания {lesson.Description}");
                }

                Console.WriteLine("Введите номер задания:");
                string chosedLesson = Console.ReadLine();

                foreach (ILesson lesson in tasks)
                {
                    if (chosedLesson == lesson.Name)
                    {
                        lesson.Run();
                    }
                }

                Console.WriteLine("Хотите Выбрать задание? [y/n]");
                string ans = Console.ReadLine();
                if (ans == "n")
                {
                    start = false;
                }
            }
        }
    }
}
