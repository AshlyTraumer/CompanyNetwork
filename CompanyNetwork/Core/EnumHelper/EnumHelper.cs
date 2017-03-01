using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CompanyNetwork.Core.EnumHelper
{
    public static class EnumHelper
    {
        public static IEnumerable<Enum> GetFlags(Enum input)
        {
            return Enum.GetValues(input.GetType())
                .Cast<Enum>()
                .Where(input.HasFlag);
        }

        public static string GetDescription(Enum age)
        {
            return age.GetType()
                .GetMember(age.ToString())
                .First()
                .GetCustomAttribute<DescriptionAttribute>()
                .Description;

        }
    }
}