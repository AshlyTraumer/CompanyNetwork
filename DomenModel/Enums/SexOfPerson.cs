using System.ComponentModel;

namespace DomenModel.Enums
{
    public enum SexOfPerson
    {
        [Description("Men")]
        Men = 0,

        [Description("Women")]
        Women = 1,

        [Description("None")]
        NotFound = 2
    }
}
