using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Running;

namespace IOBenchmarking;

[MemoryDiagnoser]
internal class Program {
    private static void Main(string[] args) {
#if RELEASE
        BenchmarkRunner.Run<Benchmarks>();
#else
        var b = new Benchmarks();
        b.Count = 3;
        b.BitWriter();
        Console.ReadLine();
#endif
    }
}