using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace scmap.Helpers
{
    public static class TypeHelper
    {
        public static List<Type> GetAllTypesInheritedFromType<T>()
        {
            var type = typeof(T);
            return AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => type.IsAssignableFrom(p)).ToList();
        }
    }
}
