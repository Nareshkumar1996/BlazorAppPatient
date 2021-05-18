using System;
using System.Linq;
using System.Text;

namespace Healthware.Assist.Core.Extensions
{
    public static class type_extensions
    {
        public static bool IsNull<T>(this T item) where T : class
        {
            return item == null;
        }

        public static bool IsNotNull<T>(this T item) where T : class
        {
            return item != null;
        }
        
        public static string GetFormattedName(this Type t)
        {
            if (t.IsGenericType)
            {
                var sb = new StringBuilder();

                sb.Append(t.Name.Substring(0, t.Name.LastIndexOf("`", StringComparison.Ordinal)));
                sb.Append(t.GetGenericArguments().Aggregate("<",
                    (aggregate, type) => aggregate + (aggregate == "<" ? "" : ",") + GetFormattedName(type)));
                sb.Append(">");

                return sb.ToString();
            }

            if (t.IsArray)
            {
                return t.Name.Substring(0, t.Name.LastIndexOf("`", StringComparison.Ordinal)) + "[]";
            }

            return t.Name;
        }
    }
}