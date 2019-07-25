using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Environments;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System.Text;

namespace Benchmarks
{
    [DryCoreJob]
    [MemoryDiagnoser]
    public class ConcatVsStringbuilder
    {
        [Params(10, 100, 1000)]
        public int Size { get; set; }

        [Benchmark]
        public string UsingStringConcat()
        {
            var str = "";

            for (int i = 0; i < Size; i++)
            {
                string.Concat(str, i);
            }

            return str;
        }

        [Benchmark]
        public string UsingStringbuilder()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < Size; i++)
            {
                sb.Append(i);
            }

            return sb.ToString();
        }
    }
}
