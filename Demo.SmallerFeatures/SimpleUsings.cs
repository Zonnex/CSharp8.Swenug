using System.IO;

namespace Demo.SmallerFeatures
{
    public class SimpleUsings
    {

        static void UsingDeclarations(string filePath)
        {
            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                using (var bs = new BufferedStream(fs))
                {
                    using (var sr = new StreamReader(bs))
                    {
                        // do things here
                    }
                }
            }
        }

        static void UsingDeclarations2(string filePath)
        {
            using (var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            using (var bs = new BufferedStream(fs))
            using (var sr = new StreamReader(bs))
            {
                // do things here
            }
        }

        static void UsingDeclaration3(string filePath)
        {
            using var fs = File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.Read);
            using var bs = new BufferedStream(fs);
            using var sr = new StreamReader(bs);

            // do things here
            // usings disposed at end of method
        }
    }
}
