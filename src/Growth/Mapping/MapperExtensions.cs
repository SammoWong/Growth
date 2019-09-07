using System;
using System.Collections.Generic;
using System.Text;

namespace Growth.Mapping
{
    public static class MapperExtensions
    {
        public static TTarget MapTo<TSource, TTarget>(this TSource source, TTarget target)
        {
            throw new Exception();
        }

        public static TTarget MapTo<TSource, TTarget>(this TSource source)
        {
            throw new Exception();
        }
    }
}
