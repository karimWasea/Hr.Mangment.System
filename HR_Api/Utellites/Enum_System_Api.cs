
using System.ComponentModel;

namespace HR_Api.Utellites
{
    //public enum Gender
    //{
    //    Male,
    //    Female,
    //    Other
    //}

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




    //
    // Summary:
    //     Specifies the day of the week.
    public enum DayOfWeeks
    {
        [Description("Sunday")]
        Sunday = 0,

        [Description("Monday")]
        Monday = 1,

        [Description("Tuesday")]
        Tuesday = 2,

        [Description("Wednesday")]
        Wednesday = 3,

        [Description("Thursday")]
        Thursday = 4,

        [Description("Friday")]
        Friday = 5,

        [Description("Saturday")]
        Saturday = 6
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
