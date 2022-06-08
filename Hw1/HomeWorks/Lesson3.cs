using System;
using HomeWorksInterface;

namespace HomeWorks
{
    public class Lesson3 : ILesson
    {
        public string Name => "3";

        public string Description => "Домашнее задание 3";

        public void Run()
        {
            Console.WriteLine($"---{Description}---");
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
        }
    }
}
