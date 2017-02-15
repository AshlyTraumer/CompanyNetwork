using System.ComponentModel;

namespace DomenModel.Enums
{
    public enum Language
    {
        [Description("English")]
        English = 1,

        [Description("Russian")]
        Russian = 2,

        [Description("German")]
        German = 4,

        [Description("Albanian")]
        Albanian = 8,

        [Description("French")]
        French = 16,

        [Description("Polish")]
        Polish = 32,

        [Description("Spanish")]
        Spanish = 64
    }
}
