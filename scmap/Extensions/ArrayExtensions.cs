using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmap.Extensions
{
    public static class ArrayExtensions
    {
        public static T[] SubArray<T>(this T[] data, int index)
        {
            var length = data.Length - index;
            T[] result = new T[length];
            Array.Copy(data, index, result, 0, length);
            return result;
        }
    }
}
