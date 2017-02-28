using System.ComponentModel;

namespace DomenModel.Enums
{
    public enum SexOfPerson
    {
        [Description("Мужчина")]
        Men = 0,

        [Description("Женщина")]
        Women = 1,

        [Description("Не определено")]
        NotFound = 2
    }
}
