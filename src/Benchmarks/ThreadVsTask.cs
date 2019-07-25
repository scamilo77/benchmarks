using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Diagnosers;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Benchmarks
{
    [CoreJob]
    [MemoryDiagnoser]
    public class ThreadVsTask
    {
        [Params(10, 100)]
        public int Size { get; set; }

        [Benchmark]
        public void UsingThread()
        {
            var t = new Thread(Run);

            t.Start();
        }

        [Benchmark]
        public void UsingTask()
        {
            Task.Factory.StartNew(() => Run());
        }

        public void Run()
        {
            for (int i = 0; i < Size; i++)
            {

            }
        }
    }
}
