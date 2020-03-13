using System;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo.IndicesAndRanges
{
    internal class Program
    {
        private static async Task Main(string[] args)
        {
            // 909 stores
            Systembolaget[] all = await SystembolagetFile.ReadAll();

            Measure(nameof(Allocation), Allocation);
            Measure(nameof(DemoArray), () => DemoArray(all));
            Measure(nameof(DemoSpan), () => DemoSpan(all));
            Measure(nameof(Easy_Copy), () => Easy_Copy(all));
            GC.Collect();
            Measure("ArrayLoop", () =>
            {
                for (int i = 0; i < 100; i++)
                {
                    Systembolaget[] allbutfirast = all[1..];
                }
            });
            GC.Collect();
            Measure("SpanLoop", () =>
            {
                Span<Systembolaget> span = all.AsSpan();
                for (int i = 0; i < 100; i++)
                {
                    Span<Systembolaget> allbutfirast = span[1..];
                }
            });
        }

        [DebuggerStepThrough]
        private static void Measure(string prefix, Action action)
        {
            long totalBefore = GC.GetTotalMemory(false);
            action();
            long totalAfter = GC.GetTotalMemory(false);

            long diff = totalAfter - totalBefore;
            Console.WriteLine($"{prefix}: {ToPrettySize(diff)}");

            static string ToPrettySize(long value, int decimalPlaces = 0)
            {
                const long OneKb = 1024;
                const long OneMb = OneKb * 1024;
                const long OneGb = OneMb * 1024;
                const long OneTb = OneGb * 1024;

                double asTb = Math.Round((double)value / OneTb, decimalPlaces);
                double asGb = Math.Round((double)value / OneGb, decimalPlaces);
                double asMb = Math.Round((double)value / OneMb, decimalPlaces);
                double asKb = Math.Round((double)value / OneKb, decimalPlaces);
                string chosenValue = asTb > 1 ? string.Format("{0}Tb", asTb)
                    : asGb > 1 ? string.Format("{0}Gb", asGb)
                    : asMb > 1 ? string.Format("{0}Mb", asMb)
                    : asKb > 1 ? string.Format("{0}Kb", asKb)
                    : string.Format("{0}B", Math.Round((double)value, decimalPlaces));

                return chosenValue;
            }
        }
        private static void Allocation()
        {
            int[] test = new int[100_000];
            _ = test.Sum();
        }
        private static void DemoArray(Systembolaget[] all)
        {
            Systembolaget firstStore = all[0];

            Index second = 1;
            Systembolaget secondStore = all[second];

            Index last = ^1;
            Systembolaget lastStore_Index = all[last];
            Systembolaget lastStore_Traditional = all[all.Length - 1];
            bool same = lastStore_Index == lastStore_Traditional;

            Range first10 = 0..10;
            Span<Systembolaget> first10Stores = all[first10];

            Range last10 = ^10..^0;
            Span<Systembolaget> last10Stores = all[last10];
            Systembolaget lastElement = last10Stores[^1];
            bool isReallyLast = lastElement == lastStore_Traditional;

            Span<Systembolaget> first100 = all[..100];
            Span<Systembolaget> last100 = all[^100..];
            Span<Systembolaget> all_but_last_100 = all[..^100];
        }
        private static void DemoSpan(Span<Systembolaget> all)
        {
            Systembolaget firstStore = all[0];

            Index second = 1;
            Systembolaget secondStore = all[second];

            Index last = ^1;
            Systembolaget lastStore_Index = all[last];
            Systembolaget lastStore_Traditional = all[all.Length - 1];
            bool same = lastStore_Index == lastStore_Traditional;

            Range first10 = 0..10;
            Span<Systembolaget> first10Stores = all[first10];

            Range last10 = ^10..^0;
            Span<Systembolaget> last10Stores = all[last10];
            Systembolaget lastElement = last10Stores[^1];
            bool isReallyLast = lastElement == lastStore_Traditional;

            Span<Systembolaget> first100 = all[..100];
            Span<Systembolaget> last100 = all[^100..];
            Span<Systembolaget> all_but_last_100 = all[..^100];
        }
        private static void Easy_Copy(Systembolaget[] all)
        {
            Systembolaget[] copy = all[..];
        }
    }
}
