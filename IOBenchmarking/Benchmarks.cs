using System;
using System.IO;
using System.Threading.Tasks;
using BenchmarkDotNet.Attributes;

namespace IOBenchmarking;
public class Benchmarks {
    [Params(100, 1_000, 100_000)]
    public int Count { get; set; }

    private static readonly string writePath = "Benchmarking.bin";

    [GlobalCleanup]
    public void Cleanup() {
        try {
            File.Delete(writePath);
        }
        catch (Exception e) { }
    }

    [Benchmark]
    public void BitWriter() {
        using var strm = File.Create(writePath);
        using var writer = new BinaryWriter(strm);
        for (var c = 0; c < Count; c++) writer.Write(BitConverter.GetBytes(c));
    }

    [Benchmark]
    public void StreamWrite() {
        using var strm = File.Create(writePath);
        using var writer = new StreamWriter(strm);

        for (var c = 0; c < Count; c++) writer.Write(BitConverter.GetBytes(c));
    }

    [Benchmark]
    public void BitWriterSmallBuffer() {
        using var strm = File.Create(writePath, 4);
        using var writer = new BinaryWriter(strm);

        for (var c = 0; c < Count; c++) writer.Write(BitConverter.GetBytes(c));
    }

    [Benchmark]
    public async Task StreamWriteAsync() {
        using var strm = File.Create(writePath);
        using var writer = new StreamWriter(strm);

        for (var c = 0; c < Count; c++) await writer.WriteAsync(Convert.ToChar(c));
    }
}
