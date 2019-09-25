using System;
using System.Collections.Generic;
using System.Text;

namespace Demo.SmallerFeatures
{
    public class Performance
    {
        public void SampleMethod(ref Vector3 byRef, in Vector3 input, out Vector3 output)
        {
            output = Vector3.Origin;
        }

    }

    public struct Vector3
    {
        public double X;
        public double Y;
        public double Z;

        public static Vector3 Origin = new Vector3();
    }

    /*
     * We could previously apply readonly to structs for performance gains if we
     * know that they shouldn't change. Compiler will enforce the readonly rule
     */
    public readonly struct ReadOnlyThing
    {
        public int A { get; }
        // public int B { get; set; } <-- will not compile
    }

    /*
     * What if we want to tell the compiler that the ToString() method is not mutating
     * the struct? In C#8 we can do just that
     */
    public struct Point
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Distance => Math.Sqrt((X*X) + (Y*Y));

        public override string ToString()
        {
            return $"({X}, {Y}) is {Distance} from the origin";
        }
    }
}
