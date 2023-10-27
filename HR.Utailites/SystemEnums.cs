using System.ComponentModel;

namespace SystemEnums
{
    public enum Gender
    {
        [Description("Male  ")]

        Male,
        [Description("Female  ")]

        Female,
        [Description("Other  ")]

        Other
    }

    public enum ShiftStuTework
    {
        [Description("Morning Shift")]
        Morning,
        [Description("Afternoon Shift")]
        Afternoon,
        [Description("Night Shift")]
        Night
    }

    public enum IsDeleted
    {
        [Description("NotDeleted")]

        NotDeleted,
        [Description("Deleted")]

        Deleted,

    }

    public enum TransactionSalaryType
    {
        None,      // Explicitly define a default value
        Bonus,
        Deduction,
        debt,
        Other
    }

    public static class EnumExtensions
    {
        public static string GetDescription(this Enum value)
        {
            var fieldInfo = value.GetType().GetField(value.ToString());
            var attributes = fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false) as DescriptionAttribute[];
            return attributes != null && attributes.Length > 0 ? attributes[0].Description : value.ToString();
        }
    }
}
