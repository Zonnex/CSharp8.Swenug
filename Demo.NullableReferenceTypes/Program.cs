using System;

#nullable enable

namespace Demo.NullableReferenceTypes
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            
            string test = null;
            string test2 = GetName();

            var used = test.Length;
            var used2 = test2.Length;

            int? maybeInt = null;
            int? maybeDoubled = maybeInt.Select(i => i * 2);

            Cat? cat = null;

            string? maybeName = cat.Select(c => c.Name);
            //int? maybeAge = cat.Select(c => c.Age);
        }

        static string? GetName()
        {
            return "Hello";
        }
    }

    class Cat
    {
        public int Age;
        public string Name = "";
    }
}
