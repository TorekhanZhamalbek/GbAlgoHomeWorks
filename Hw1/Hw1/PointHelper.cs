using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Hw1
{
    class PointHelper
    {
        public static double GetDistanceStruct(PointStructDouble pointOne, PointStructDouble pointTwo)
        {
            double x = pointOne.X - pointOne.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static double GetDistanceClass(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.X - pointOne.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }
        public static object[] GenerateSequenceClass(int sequenceLength)
        {
            object[] result = new object[sequenceLength];
            Random rnd = new Random(100);
            for (int i = 0; i < sequenceLength; i++)
            {
                PointClassDouble point = new PointClassDouble(rnd.NextDouble(), rnd.NextDouble());
                result[i] = point;
            }
            return result;
        }
        public static object[] GenerateSequenceStruct(int sequenceLength)
        {
            object[] result = new object[sequenceLength];
            Random rnd = new Random(100);
            for (int i = 0; i < sequenceLength; i++)
            {
                PointStructDouble point = new PointStructDouble(rnd.NextDouble(), rnd.NextDouble());
                result[i] = point;
            }
            return result;
        }
        public static TimeSpan DoTestStruct(object[] inputArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                PointHelper.GetDistanceStruct((PointStructDouble)inputArray[i], (PointStructDouble)inputArray[i + 1]);
            }
            sw.Stop();
            return sw.Elapsed;
        }
        public static TimeSpan DoTestClass(object[] inputArray)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            for (int i = 0; i < inputArray.Length - 1; i++)
            {
                PointHelper.GetDistanceClass((PointClassDouble)inputArray[i], (PointClassDouble)inputArray[i + 1]);
            }
            sw.Stop();
            return sw.Elapsed;
        }
    }
}
