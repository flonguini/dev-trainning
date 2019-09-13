using System.ComponentModel;

namespace MVVMApp.Enums
{
    [TypeConverter(typeof(EnumDescriptionTypeConverter))]
    public enum Genders
    {
        [Description("Masculino")]
        Male,
        [Description("Feminino")]
        Female
    }
}
