using System;

namespace Demo.SmallerFeatures
{
    public class UnmanagedTypes
    {
        class Cat
        {
            public string Name;
        }

        struct Thing
        {
            public int Number;
        }

        /* From docs:
        
        An unmanaged_type is any type that isn't a reference_type or constructed type, 
        and doesn't contain reference_type or constructed type fields at any level of nesting. 
        In other words, an unmanaged_type is one of the following:

        sbyte, byte, short, ushort, int, uint, long, ulong, char, float, double, decimal, or bool.
        Any enum_type.
        Any pointer_type.
        Any user-defined struct_type that is not a constructed type and contains fields of 
        unmanaged_types only.
        
         */

        public static void Sample()
        {
            Stackalloc<int>();
            Stackalloc<Thing>();
            //Stackalloc<Cat>();
        }

        public static void Stackalloc<T>()
            where T : unmanaged
        {
            Span<T> things = stackalloc T[10];
        }

        public struct Coords<T>
        {
            public T X;
            public T Y;
        }

        public static void Main()
        {
            DisplaySize<Coords<int>>();
            DisplaySize<Coords<double>>();
            DisplaySize<Thing>();

            //DisplaySize<Cat>();
            //DisplaySize<Coords<Cat>>();
        }

        // In C# 7.3 we got the unmanaged constraint
        private unsafe static void DisplaySize<T>() where T : unmanaged
        {
            System.Console.WriteLine($"{typeof(T)} is unmanaged and its size is {sizeof(T)} bytes");
        }
    }
}
