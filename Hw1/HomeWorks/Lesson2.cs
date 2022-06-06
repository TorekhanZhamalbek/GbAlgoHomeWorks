using System;
using HomeWorksInterface;

namespace HomeWorks
{
    public class Lesson2 : ILesson
    {
        public string Name => "2";

        public string Description => "Домашнее задание 2";

        public void Run()
        {
            Console.WriteLine($"---{Description}---");
            LinkedList list = new LinkedList();

            list.AddNode(10);
            list.GetCount();
            list.RemoveNode(list.FindNode(10));

            int[] intArray = new int[] { 1, 2, 40, 15, 25, 3, 0, 10, 6, 22 };

            BubbleSort(intArray); // Асс

            for (int i = 0; i < intArray.Length; i++)
            {
                Console.Write(intArray[i] + " ");
            }

            Console.WriteLine();

            int findNumber = BinarySearch(intArray, 40); // Ассимптотическая сложность O(log(n))]
            Console.WriteLine(findNumber);
        }
        private void BubbleSort(int[] array)
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
        private int BinarySearch(int[] inputArray, int searchValue)
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
}
