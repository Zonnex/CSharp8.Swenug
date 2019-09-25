using System;

#nullable enable

namespace Demo.NullableReferenceTypes
{
    public static class NullableExtensions
    {
        //public static TResult? Select<T, TResult>(this T? nullable, Func<T, TResult> selector)
        //{
        //    return null;
        //}

        public static TResult? Select<T, TResult>(this T? nullable, Func<T, TResult> selector)
            where T : struct
            where TResult : struct
        {
            if (nullable.HasValue)
                return selector(nullable.Value);
            else
                return null;
        }

        public static TResult? Select<T, TResult>(this T? nullable, Func<T, TResult> selector)
            where T : class
            where TResult : class
        {
            if (nullable is object)
                return selector(nullable);
            else
                return null;
        }

        //public static TResult? Select<T, TResult>(this T? nullable, Func<T, TResult> selector)
        //    where T : class
        //    where TResult : struct
        //{
        //    if (nullable is object)
        //        return selector(nullable);
        //    else
        //        return null;
        //}
    }
}
