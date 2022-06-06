using System;
using HomeWorksInterface;

namespace HomeWorks
{
    public class Lesson1 : ILesson
    {
        public string Name => "1";

        public string Description => "Домашнее задание 1";

        public void Run()
        {
            Console.WriteLine($"---{Description}---");
            bool start = true;
            while (start)
            {
                Console.WriteLine("Выберите задание от 1 до 3.");
                int chosedTask;
                int numForTask1;
                long numForTask3;
                int chosedMethod;
                int.TryParse(Console.ReadLine(), out chosedTask);

                switch (chosedTask)
                {
                    case 1:
                        Console.WriteLine("Введите целое число");
                        int.TryParse(Console.ReadLine(), out numForTask1);
                        bool ans = IsNumberSimple(numForTask1);
                        if (ans == true)
                        {
                            Console.WriteLine($"{numForTask1} это простое");
                        }
                        else
                        {
                            Console.WriteLine($"{numForTask1} это не простое");
                        }
                        break;
                    case 2:
                        Console.WriteLine("Сложность функции O(N^3).");
                        break;
                    case 3:
                        Console.WriteLine("Введите целое число");
                        long.TryParse(Console.ReadLine(), out numForTask3);
                        Console.WriteLine("Выберите способ:\n1 - рекурсией\n2 - через цикл");
                        int.TryParse(Console.ReadLine(), out chosedMethod);
                        switch (chosedMethod)
                        {
                            case 1:
                                long fibNumberWithRecursion = GetFibNumberRecursion(numForTask3);
                                Console.WriteLine($"Для номера {numForTask3} - число фиббоначи {fibNumberWithRecursion}");
                                break;
                            case 2:
                                long fibNumberWithFor = GetFibNumberWithFor(numForTask3);
                                Console.WriteLine($"Для номера {numForTask3} - число фиббоначи {fibNumberWithFor}");
                                break;
                            default:
                                Console.WriteLine("Такого метода нет!");
                                break;
                        }
                        break;
                    default:
                        Console.WriteLine("Такого задания еще нет!");
                        break;
                }
                Console.WriteLine("Хотите повторить? y/n");
                string refresh = Console.ReadLine();
                if (refresh == "n")
                {
                    start = false;
                }
            }
        }
        private bool IsNumberSimple(int num)
        {
            int d = 0;
            int i = 2;
            while (i < num)
            {
                if (num % i == 0)
                {
                    d++;
                }
                i++;
            }
            if (d == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private long GetFibNumberRecursion(long number)
        {
            if (number < 1)
            {
                return 0;
            }
            if (number == 1)
            {
                return 1;
            }
            return GetFibNumberRecursion(number - 1) + GetFibNumberRecursion(number - 2);
        }
        private long GetFibNumberWithFor(long number)
        {
            long first = 0;
            long fibonacci = 0;
            long second = 1;
            if (number == 1) fibonacci = second;

            for (int i = 0; i < number - 1; i++)
            {
                fibonacci = first + second;
                first = second;
                second = fibonacci;
            }
            return fibonacci;
        }
    }
}
