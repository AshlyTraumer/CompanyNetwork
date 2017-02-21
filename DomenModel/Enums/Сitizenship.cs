using System;
using System.ComponentModel;

namespace DomenModel.Enums
{
    [Flags]
    public enum Сitizenship
    {
        [Description("Albanians")]
        Albanians = 1,

        [Description("Australians")]
        Australians = 2,

        [Description("Belarusians")]
        Belarusians = 4,

        [Description("Belgians")]
        Belgians = 8,

        [Description("Albanians")]
        Canadians = 16,

        [Description("FrenchCitizens")]
        FrenchCitizens = 32,

        [Description("Germans")]
        Germans = 64,

        [Description("BalticGerman")]
        BalticGermans = 128,

        [Description("Poles")]
        Poles = 256,

        [Description("Russians")]
        Russians = 512,

        [Description("Americans")]
        Armenians = 1024
    }
}
