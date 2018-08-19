using BenchmarkDotNet.Attributes;
using System.Runtime.Serialization;

namespace DynamicObjectCreationTest
{
    [ClrJob]
    [RPlotExporter, RankColumn]
    public class TheActualBenchmark
    {
        [Params(1000000)]
        public int N;

        [Benchmark]
        public TestObject StandardNew() => NewBuilder.Build();

        [Benchmark]
        public TestObject ActivatorCreateBuilderWithoutGenericTest() => ActivatorCreateBuilderWithoutGeneric.Build();

        [Benchmark]
        public TestObject ActivatorCreateBuilderWithGenericTest() => ActivatorCreateBuilderWithGeneric.Build();

        [Benchmark]
        public TestObject FormatterServicesBuilderWithoutCachingWithoutGenericTest() => 
            (TestObject)FormatterServicesBuilderWithoutCachingWithoutGeneric.Build(typeof(TestObject));

        [Benchmark]
        public TestObject FormatterServicesBuilderWithCachingWithoutGenericTest() =>
            (TestObject)FormatterServicesBuilderWithoutCachingWithoutGeneric.Build(typeof(TestObject));

        [Benchmark]
        public TestObject FormatterServicesBuilderWithoutCachingWithGenericTest() =>
            FormatterServicesBuilderWithoutCachingWithGeneric<TestObject>.Build();

        [Benchmark]
        public TestObject FormatterServicesBuilderWithCachingWithGenericTest() =>
            FormatterServicesBuilderWithCachingWithGeneric<TestObject>.Build();

        [Benchmark]
        public TestObject MsilBuilderWithoutCachingWithoutGenericTest() =>
            (TestObject)MsilBuilderWithoutCachingWithoutGeneric.Build(typeof(TestObject));

        [Benchmark]
        public TestObject MsilBuilderWithCachingWithoutGenericTest() =>
            (TestObject)MsilBuilderWithCachingWithoutGeneric.Build(typeof(TestObject));

        [Benchmark]
        public TestObject MsilBuilderWithoutCachingWithGenericTest() =>
            MsilBuilderWithoutCachingWithGeneric<TestObject>.Build();

        [Benchmark]
        public TestObject MsilBuilderWithCachingWithGeneric() =>
            MsilBuilderWithCachingWithGeneric<TestObject>.Build();

        [Benchmark]
        public TestObject LinqBuilderWithoutCachingWithGenericTest() =>
            LinqBuilderWithoutCachingWithGeneric.Build<TestObject>();

        [Benchmark]
        public TestObject LinqBuilderWithCachingWithGenericTest() =>
            LinqBuilderWithCachingWithGeneric<TestObject>.Build();
    }
}
