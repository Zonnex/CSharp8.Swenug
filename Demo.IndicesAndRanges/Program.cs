using System;
using System.IO;
using System.Threading;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;

namespace Demo.IndicesAndRanges
{
    class Program
    {
        static async Task Main(string[] args)
        {
            // 909 stores
            Systembolaget[] all = await SystembolagetFile.ReadAll();

            Demo(all);
        }

        private static void Demo(Systembolaget[] all)
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
    }
}
