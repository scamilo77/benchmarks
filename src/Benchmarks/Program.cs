using BenchmarkDotNet.Running;
using System;

namespace Benchmarks
{
    class Program
    {
        /// <summary>
        /// Add your benchmark execution here. Comment previous executions in order to execute yours.
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<ConcatVsStringbuilder>();

            Console.ReadKey();
        }
    }
}
