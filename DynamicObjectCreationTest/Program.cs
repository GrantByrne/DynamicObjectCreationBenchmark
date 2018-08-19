using BenchmarkDotNet.Running;
using System;

namespace DynamicObjectCreationTest
{
    class Program
    {
        static void Main(string[] args)
        {
            var summary = BenchmarkRunner.Run<TheActualBenchmark>();
            Console.ReadLine();
        }
    }
}
