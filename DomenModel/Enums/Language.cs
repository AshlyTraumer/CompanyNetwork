using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace DomenModel.Enums
{
    [Flags]
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

    public static class Flags
    {
        public static IEnumerable<Enum> GetFlags(Enum input)
        {
            foreach (Enum value in Enum.GetValues(input.GetType()))
                if (input.HasFlag(value))
                    yield return value;
        }

        
    }
    
}
