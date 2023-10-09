

using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;

namespace hospitalVm
{
    public class RoleVM
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public bool Rols { get; set; }

    }

   






    //public static ApplicationUser CanconvertViewmodel(PatientVm ApplicationUser)
    //    {
    //        return new ApplicationUser
    //        {
    //            Id = ApplicationUser.id,
    //            UserName = ApplicationUser.username,

//            Email = ApplicationUser.Email,
//            RoleRegeseter = ApplicationUser.RoleRegeseter,
//            Gender = ApplicationUser.Gender,
//            StreetAddress = ApplicationUser.StreetAddress,
//            City = ApplicationUser.City,
//            Dateofbarth = ApplicationUser.Dateofbarth,
//            PhoneNumber = ApplicationUser.Phonenumber,
//            Nationality = ApplicationUser.Nationality,
//            imphgurl = ApplicationUser.imphgurl,
//            PostalCode = ApplicationUser.PostalCode,
//            Title = ApplicationUser.Title,

//        };
//    }





}