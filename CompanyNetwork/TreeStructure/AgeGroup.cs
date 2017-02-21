using System;
using System.ComponentModel;
using System.Linq;
using System.Reflection;

namespace CompanyNetwork.TreeStructure
{
    public enum AgeGroup
    {
        [Description("до 25")]
        Pre25 = 25,

        [Description("25 - 29")]
        Pre30 = 30,

        [Description("30 - 39")]
        Pre40 = 40,

        [Description("40 - 49")]
        Pre50 = 50,

        [Description("более 50")]
        Upper50 = 100
    }

    public static class EnumDescription
    {
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