using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace Task3_1
{
    
    public class PointClass
    {
        public int X;
        public int Y;
    }
    public struct PointStruct
    {
        public int X;
        public int Y;
    }
    public class Distance
    {
        
        
        PointClass pointOne = new PointClass { X = 3, Y = 15 };
        PointClass pointTwo = new PointClass { X = 5, Y = 25 };
        PointStruct pointstrOne = new PointStruct { X = 3, Y = 20 };
        PointStruct pointstrTwo = new PointStruct { X = 15, Y = 5 };
        public static float PointDistance(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static double PointDistanceDouble(PointStruct pointOne, PointStruct pointTwo)
        {
            double x = pointOne.X - pointTwo.X;
            double y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((float)((x * x) + (y * y)));
        }
        public static float PointDistanceClass(PointClass pointOne, PointClass pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return MathF.Sqrt((x * x) + (y * y));
        }
        public static float PointDistanceNo(PointStruct pointOne, PointStruct pointTwo)
        {
            float x = pointOne.X - pointTwo.X;
            float y = pointOne.Y - pointTwo.Y;
            return (x * x) + (y * y);
        }

        [Benchmark]
        public void TestFstr()
        {

            PointDistance(pointstrOne, pointstrTwo);
        }
        [Benchmark]
        public void TestDstr()
        {
            PointDistanceDouble(pointstrOne, pointstrTwo);
        }
        [Benchmark]
        public void TestFclass()
        {
            PointDistanceClass(pointOne, pointTwo);
        }
        [Benchmark]
        public void TestFstrN()
        {
            PointDistanceNo(pointstrOne, pointstrTwo);
        }


    }
    

    class Program
    {
        
        static void Main(string[] args)
        {
            BenchmarkSwitcher.FromAssembly(typeof(Program).Assembly).Run(args);
 
        }
    }
}
