using System;
using System.Linq;

namespace Demo.SmallerFeatures
{
    public static class NestedStackAlloc
    {
        public static void Sample()
        {
            Span<int> numbers = stackalloc int[] { 1, 2, 3, 4, 5 };
            PrintExcept(numbers, stackalloc[] { 3, 4 });
        }

        public static void PrintExcept(Span<int> first, Span<int> second)
        {
            foreach (int number in first)
            {
                if(second.Contains(number))
                {
                    continue;
                }
                Console.WriteLine(number);
            }
        }
    }
}
