
using System;

namespace Demo.SmallerFeatures
{
    public class StringInterpolation
    {
        public string OldSyntax = $@"
            Here I can type
            on multiple lines
            and interpolate like this: {DateTime.Now}
        ";

        public string NewSyntax = @$"
            Previously if you flipped the characters
            you got compile error. Interpolate still works: {DayOfWeek.Tuesday}
        ";
    }
}
