using System;

namespace Demo.SmallerFeatures
{
    public static class StaticLocalFunctions
    {
        public static void Outer(int a, int b)
        {
            // Here we get a closure which is undesirable for 
            // high performance scenarios.
            int Inner() => a + b;

            Console.WriteLine(Inner());
        }
    }
}
