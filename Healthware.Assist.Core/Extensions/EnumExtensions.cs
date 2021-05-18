using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;

namespace Healthware.Assist.Core.Extensions
{
    public static class EnumExtensions
    {
        
        public static Dictionary<string, string> GetEnumDictionaryValues<TEnum>()
        {
            var returnValues = new Dictionary<string, string>(); 
            foreach (Enum item in Enum.GetValues(typeof(TEnum)))
            {
                returnValues.Add(item.ToString(), StringExtensions.ToTitleCase(GetEnumDisplayName(item)));
            }

            return returnValues;
        }
        public static string GetEnumDisplayName(Enum enumType)
        {
            return enumType.GetType().GetMember(enumType.ToString())
                .First()
                .GetCustomAttribute<DisplayAttribute>()
                .Name;
        }
        
    }
}