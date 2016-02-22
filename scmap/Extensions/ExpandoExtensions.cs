using System.Collections.Generic;
using System.Dynamic;
using System.Linq;

namespace scmap.Extensions
{
    public static class ExpandoExtensions
    {
        public static string GetStringProperty(this ExpandoObject expando, string propertyName) {
            var expandoDict = (IDictionary<string, object>)expando;
            return expandoDict.Keys.Any(x => x.Equals(propertyName) && expandoDict[propertyName] != null) ? expandoDict[propertyName].ToString() : null;
        }

        public static void SetProperty(this ExpandoObject expando, string propertyName, object value)
        {
            ((IDictionary<string, object>)expando)[propertyName] = value;
        }
    }
}
