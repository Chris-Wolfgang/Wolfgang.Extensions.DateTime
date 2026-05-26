using System;
using BenchmarkDotNet.Attributes;
using Wolfgang.Extensions.DateTime;

namespace Wolfgang.Extensions.DateTime.Benchmarks;

/// <summary>
/// Microbenchmarks for the public extension methods. All eight methods
/// allocate a small number of DateTime structs and short loops; they should
/// be well under a microsecond apiece. The MemoryDiagnoser is enabled so any
/// future refactor that introduces allocation surfaces in the gh-pages
/// benchmark chart immediately.
/// </summary>
[MemoryDiagnoser]
public class DateTimeExtensionsBenchmarks
{
    // A representative mid-range UTC value — late enough that the MinValue
    // boundary checks in FirstOfWeek do not short-circuit, but well clear of
    // the MaxValue overflow guard so EndOfMonth / EndOfYear take the common
    // fast path.
    private static readonly System.DateTime Sample =
        new(2026, 5, 26, 13, 45, 30, 123, DateTimeKind.Utc);



    [Benchmark]
    public System.DateTime TruncateMilliseconds() => Sample.TruncateMilliseconds();



    [Benchmark]
    public System.DateTime TruncateSeconds() => Sample.TruncateSeconds();



    [Benchmark]
    public System.DateTime FirstOfMonth() => Sample.FirstOfMonth();



    [Benchmark]
    public System.DateTime EndOfMonth() => Sample.EndOfMonth();



    [Benchmark]
    public System.DateTime FirstOfYear() => Sample.FirstOfYear();



    [Benchmark]
    public System.DateTime EndOfYear() => Sample.EndOfYear();



    [Benchmark]
    public System.DateTime FirstOfWeek_Sunday() => Sample.FirstOfWeek(DayOfWeek.Sunday);



    [Benchmark]
    public System.DateTime EndOfWeek_Sunday() => Sample.EndOfWeek(DayOfWeek.Sunday);
}
