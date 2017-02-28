using System;
using System.ComponentModel;

namespace DomenModel.Enums
{
    [Flags]
    public enum Language
    {
        [Description("Английский")]
        English = 1,

        [Description("Русский")]
        Russian = 2,

        [Description("Немецкий")]
        German = 4,

        [Description("Албанский")]
        Albanian = 8,

        [Description("Французский")]
        French = 16,

        [Description("Польский")]
        Polish = 32,

        [Description("Испанский")]
        Spanish = 64
    }   
}
