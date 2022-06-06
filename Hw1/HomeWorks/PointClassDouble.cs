using System;

namespace HomeWorks
{
    internal class PointClassDouble
    {
        public double X;
        public double Y;
        public PointClassDouble(double x, double y)
        {
            X = x;
            Y = y;
        }
        public double PointDistanceDouble(PointClassDouble pointOne, PointClassDouble pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return Math.Sqrt((x * x) + (y * y));
        }

    }
}
