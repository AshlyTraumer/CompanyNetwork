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
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
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