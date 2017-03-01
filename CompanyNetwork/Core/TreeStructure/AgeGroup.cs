using System.ComponentModel;

namespace CompanyNetwork.Core.TreeStructure
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
}