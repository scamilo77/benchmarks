using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Configs;
using BenchmarkDotNet.Engines;
using BenchmarkDotNet.Jobs;
using BenchmarkDotNet.Toolchains.CsProj;
using System.Buffers;

namespace Benchmarks
{
    [MemoryDiagnoser]
    [Config(typeof(MyConfig))]
    public class ArrayAllocation
    {
        [Params(
            100,
            1000,
            10000,
            100000,
            1000000,
            10000000)]
        public int Size { get; set; }

        private ArrayPool<byte> Pool;

        [GlobalSetup(Targets = new[] { nameof(UseArray), nameof(UseArrayPool), nameof(UseArrayPoolShared) })]
        public void Setup()
        {
            Pool = ArrayPool<byte>.Create(Size + 1, 10);
            
        }

        [Benchmark]
        public void UseArray()
        {
            //Necessário dizer ao benchmark que não desejamos que os "dead codes" sejam eliminados
            DeadCodeEliminationHelper.KeepAliveWithoutBoxing(new byte[Size]);
        }

        [Benchmark]
        public void UseArrayPool()
        {
            var pool = Pool;
            byte[] array = pool.Rent(Size);
            pool.Return(array);
        }

        [Benchmark]
        public void UseArrayPoolShared()
        {
            var pool = ArrayPool<byte>.Shared;
            byte[] array = pool.Rent(Size);
            pool.Return(array);
        }


        private class MyConfig : ManualConfig
        {
            public MyConfig()
            {
                // Configuração para que o benchmark não force execuções do GC
                Add(Job.Default.With(new GcMode() { Force = false }).With(CsProjCoreToolchain.NetCoreApp22));
            }
        }

    }
}
