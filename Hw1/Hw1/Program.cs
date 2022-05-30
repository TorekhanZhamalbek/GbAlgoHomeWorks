using System;
using System.Collections.Generic;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Hw1
{
    class Program
    {
        static void Main(string[] args)
        {
            bool overall = true;
            while (overall)
            {
                Console.WriteLine("Выберите домашнее задание от 1 до 4");
                int chosedHw;
                int.TryParse(Console.ReadLine(), out chosedHw);
                switch (chosedHw)
                {
                    case 1:
                        Hw1();
                        break;
                    case 2:
                        Hw2();
                        break;
                    case 3:
                        Hw3();
                        break;
                    case 4:
                        Hw4();
                        break;
                    default:
                        Console.WriteLine("Такого дз еще нет");
                        break;
                }
                Console.WriteLine("Хотите повторно выбрать дз? y/n");
                string refresh = Console.ReadLine();
                if (refresh == "n")
                {
                    overall = false;
                }
            }
            void Hw1()
            {
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
            void Hw2()
            {
                LinkedList list = new LinkedList();

                list.AddNode(10);
                list.GetCount();
                list.RemoveNode(list.FindNode(10));

                int[] intArray = new int[] { 1, 2, 40, 15, 25, 3, 0, 10, 6, 22};

                BubbleSort(intArray); // Асс

                for (int i = 0; i < intArray.Length; i++)
                {
                    Console.Write(intArray[i] + " ");
                }

                Console.WriteLine();

                int findNumber = BinarySearch(intArray, 40); // Ассимптотическая сложность O(log(n))]
                Console.WriteLine(findNumber);
                Console.ReadLine();
            }
            void Hw3()
            {
                Console.WriteLine("Количество точек\t|\tPointStructDouble\t|\tPointClassDouble\t|\tRatio");
                for (int i = 0; i < 5; i++)
                {
                    int length = (i + 1) * 500000;
                    object[] pointStructArray = PointHelper.GenerateSequenceStruct(length);
                    object[] pointClassArray = PointHelper.GenerateSequenceClass(length);
                    TimeSpan timeStruct = PointHelper.DoTestStruct(pointStructArray);
                    TimeSpan timeClass = PointHelper.DoTestClass(pointClassArray);
                    Console.WriteLine($"{length}\t|\t{timeStruct}\t|\t{timeClass}\t|\t{timeClass.Divide(timeStruct)}");
                }
                Console.ReadLine();
            }
            void Hw4()
            {
                var binaryTree = new BinaryTree();
                binaryTree.Add(8);
                binaryTree.Add(3);
                binaryTree.Add(10);
                binaryTree.Add(1);
                binaryTree.Add(6);
                binaryTree.PrintTree();
                Console.WriteLine(new string('-', 40));
                binaryTree.DeleteNote(binaryTree.FindNoteByValue(3));
                binaryTree.PrintTree();
                Console.WriteLine(new string('-', 40));
                binaryTree.DeleteNote(binaryTree.FindNoteByValue(8));
                binaryTree.PrintTree();
            }
        }
        public static bool IsNumberSimple(int num)
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
        public static long GetFibNumberRecursion(long number)
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
        public static long GetFibNumberWithFor(long number)
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
        public static void BubbleSort(int[] array)
        {
            for (int i = 0; i < array.Length; i++)
            {
                for (int j = 0; j < array.Length - 1; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        var temp = array[j + 1];
                        array[j + 1] = array[j];
                        array[j] = temp;
                    }
                }
            }
        }


        public static int BinarySearch(int[] inputArray, int searchValue)
        {
            int min = 0;
            int max = inputArray.Length - 1;
            while (min <= max)
            {
                int mid = (min + max) / 2;
                if (searchValue == inputArray[mid])
                {
                    return mid;
                }
                else if (searchValue < inputArray[mid])
                {
                    max = mid - 1;
                }
                else
                {
                    min = mid + 1;
                }
            }
            return -1;
        }
    }
    public class Node
    {
        public int Value { get; set; }
        public Node NextNode { get; set; }
        public Node PrevNode { get; set; }
    }
    public interface ILinkedList
    {
        int GetCount();
        void AddNode(int value);
        void AddNodeAfter(Node node, int value);
        void RemoveNode(int index);
        void RemoveNode(Node node);
        Node FindNode(int searchValue);
    }
    public class LinkedList : ILinkedList
    {
        private Node head = new Node();
        private Node tail = new Node();

        public LinkedList()
        {
            head.NextNode = tail;
            tail.PrevNode = head;
        }
        public int GetCount()
        {
            int count = 0;
            Node current = head;
            while (current != null)
            {
                current = current.NextNode;
                count++;
            }
            return count;
        }

        public void AddNode(int value)
        {
            var node = head;

            while (node.NextNode != null)
            {
                node = node.NextNode;
            }

            var newNode = new Node()
            {
                Value = value,
                PrevNode = node
            };

            node.NextNode = newNode;
        }

        public void AddNodeAfter(Node node, int value)
        {
            var newNode = new Node { 
                Value = value,
                NextNode = node.NextNode,
                PrevNode = node
            };
            node.NextNode = newNode;
        }

        public void RemoveNode(int index)
        {
            int count = 0;
            Node current = head;
            while (current != null && count < index)
            {
                current = current.NextNode;
                count++;
            }
            if (count == index)
            {
                RemoveNode(current);
            }
            else
            {
                Console.WriteLine($"Узел с индексом - {index} не существует!");
            }
        }

        public void RemoveNode(Node node)
        {
            var prev = node.PrevNode;
            var next = node.NextNode;

            if (next != null)
            {
                next.PrevNode = prev;
            }
            prev.NextNode = next;
        }
        public Node FindNode(int searchValue)
        {
            Node current = head;

            while (current != null)
            {
                if (current.Value == searchValue)
                {
                    return current;
                }
                current = current.NextNode;
            }

            return null;
        }
    }
}
