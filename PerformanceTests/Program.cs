using SuperTuples;
using System;
using System.Diagnostics;
using System.Linq.Expressions;

namespace PerformanceTests
{
    class Program
    {
        private const int Iterations = 1000000;

        static void Main(string[] args)
        {
            for (int run = 1; run <= 5; run++)
            {
                Console.WriteLine($"Run {run}");
                Bench(() => TupleEquals());
                Bench(() => UncachedSupleEquals());
                Bench(() => CachedSupleEquals());
                Bench(() => TupleNotEquals());
                Bench(() => UncachedSupleNotEquals());
                Bench(() => CachedSupleNotEquals());
                Console.WriteLine();
            }
        }

        private static void UncachedSupleEquals()
        {
            object a = new UnCachedSuple(1, 2, 3);
            object b = new UnCachedSuple(1, 2, 3);
            Run(a, b);
        }

        private static void UncachedSupleNotEquals()
        {
            object a = new UnCachedSuple(1, 2, 3);
            object b = new UnCachedSuple(1, 2, 4);
            Run(a, b);
        }

        private static void CachedSupleEquals()
        {
            object a = new CachedSuple(1, 2, 3);
            object b = new CachedSuple(1, 2, 3);
            Run(a, b);
        }

        private static void CachedSupleNotEquals()
        {
            object a = new CachedSuple(1, 2, 3);
            object b = new CachedSuple(1, 2, 4);
            Run(a, b);
        }

        private static void TupleEquals()
        {
            object a = Tuple.Create(1, 2, 3);
            object b = Tuple.Create(1, 2, 3);
            Run(a, b);
        }

        private static void TupleNotEquals()
        {
            object a = Tuple.Create(1, 2, 3);
            object b = Tuple.Create(1, 2, 4);
            Run(a, b);
        }

        private static void Run(object a, object b)
        {
            for (int i = 0; i < Iterations; i++)
            {
                a.Equals(b);
                b.Equals(a);
                Equals(a, b);
                Equals(a.GetHashCode(), b.GetHashCode());
            }
        }

        private static void Bench(Expression<Action> action)
        {
            var toRun = action.Compile();
            var str = action.ToString();
            Console.Write($"{str}");
            var sw = Stopwatch.StartNew();
            toRun();
            Console.WriteLine($" took {sw.Elapsed}");
        }

        public class UnCachedSuple : Suple<int, int, int>
        {
            public UnCachedSuple(int a, int b, int c) : base(a, b, c)
            {
            }
        }

        public class CachedSuple : Suple<int, int, int>
        {
            public CachedSuple(int a, int b, int c) : base(a, b, c, SupleHash.Cached)
            {
            }
        }
    }
}
