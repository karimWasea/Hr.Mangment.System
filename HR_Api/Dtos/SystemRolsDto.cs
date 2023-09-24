using Microsoft.AspNetCore.Identity;

namespace apistudy.Models.Entityies
{
    public class SystemRolsDtoCreate
    {
        public string Role { get; set; }
         public static IdentityRole converttoridentityrple(SystemRolsDtoCreate systemRolsDtoCreate)
        {
            return new IdentityRole { Name = systemRolsDtoCreate.Role };
        }
    }  
    public class SystemRolsDtoUpdate : SystemRolsDtoCreate
    {
        public string RoleId { get; set; }
        public static IdentityRole converttoridentityrple(SystemRolsDtoUpdate systemRolsDtoCreate)
        {
            return new IdentityRole { Name = systemRolsDtoCreate.Role , Id =systemRolsDtoCreate.RoleId };
        }
    };


}
