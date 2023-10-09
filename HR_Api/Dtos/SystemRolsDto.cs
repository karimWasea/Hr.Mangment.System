using Microsoft.AspNetCore.Identity;

using System.ComponentModel.DataAnnotations;

namespace apistudy.Models.Entityies
{
    public class SystemRolsDtoCreate
    {
        [Required]
        public string Role { get; set; }
         public static IdentityRole converttoridentityrple(SystemRolsDtoCreate systemRolsDtoCreate)
        {
            return new IdentityRole { Name = systemRolsDtoCreate.Role };
        }
    }  
    public class SystemRolsDtoUpdate : SystemRolsDtoCreate
    {
        [Required]
        public string RoleId { get; set; }
        public static IdentityRole converttoridentityrple(SystemRolsDtoUpdate systemRolsDtoCreate)
        {
            return new IdentityRole { Name = systemRolsDtoCreate.Role , Id =systemRolsDtoCreate.RoleId };
        }
    };


}
