using DataAcess.layes;
using HR_Api.Utellites
;
    using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HR_Api.Utellites;
using apistudy.Models.Entityies;
using System.Text;

namespace HR_Api.IrepreatoryServess
{
    public class IRoleServess : PaginationHelper<SystemRolsDtoUpdate>, ISystemRole_Api
    {
        Imgoperation _Imgoperation;
        private ApplicationDBcontext _DBcontext;
        private   RoleManager<IdentityRole> _Rolemanger;



        public IRoleServess(ApplicationDBcontext db, RoleManager<IdentityRole> Rolemanger  , Imgoperation lookupServess)
        {
            _Imgoperation = lookupServess;
_Rolemanger= Rolemanger;    
                _DBcontext = db;
        }


















        



        public   Task<SystemRolsDtoUpdate> GetById(string id)
        {
            var model =
          _Rolemanger.Roles.Where(p => p.Id == id ).Select(ApplicationUser => new SystemRolsDtoUpdate
          {
               RoleId = ApplicationUser.Id,
                Role= ApplicationUser.Name,

          }).FirstOrDefaultAsync();
            return model;
        }



        public IEnumerable<SystemRolsDtoUpdate> GetAll()
        {
            return
           _Rolemanger.Roles.Select(ApplicationUser => new SystemRolsDtoUpdate
          {
              RoleId = ApplicationUser.Id,
              Role = ApplicationUser.Name,

          }).DefaultIfEmpty().ToList();
          
        }
        public async Task<IEnumerable<SystemRolsDtoUpdate>> Search(string str = null)
        {
            str = str?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Rolemanger.Roles
                .Where(p =>
                    string.IsNullOrWhiteSpace(str) || // Return all items if searchTerm is empty
                    p.Name.ToLower().Contains(str))
                .Select(ApplicationUser => new SystemRolsDtoUpdate
                {
                    RoleId = ApplicationUser.Id,
                    Role = ApplicationUser.Name,
                })
                .ToList();
        }
        public async Task<bool> Delete(string id)
        {

            var user = _Rolemanger.Roles.Where(i => i.Id == id).FirstOrDefault();
            //if (user != null)
            //{
            //    var roles =  await _user.GetRolesAsync(user);
            //    foreach (var role in roles)
            //    {
            //          _user.RemoveFromRoleAsync(user, role);
            //    }
            //    var deleeteduser =   GetById(id);

            _Rolemanger.DeleteAsync(user);

            _DBcontext.SaveChanges();

            //}
            return true;


        }
        public async Task<AuthModel> Creat(SystemRolsDtoCreate entity)
        {
          
            var user = SystemRolsDtoCreate.converttoridentityrple(entity);
           
            var result = await _Rolemanger.CreateAsync(user);

            // If user creation fails, construct an error message with details
            if (!result.Succeeded)
            {
                var errorsBuilder = new StringBuilder();

                foreach (var error in result.Errors)
                {
                    errorsBuilder.Append($"{error.Description},");
                }

                return new AuthModel { Message = errorsBuilder.ToString() };
            }

            // Assign the "User" role to the newly registered user

            return new AuthModel { Message = "Rolle employee" };
        }

                public async Task<AuthModel> Update(SystemRolsDtoUpdate aplicatiouserDto)
        {
         

            var applicationUser =  await _Rolemanger.FindByIdAsync(aplicatiouserDto.RoleId);


          
            applicationUser.Id = aplicatiouserDto.RoleId;
            applicationUser.Name = aplicatiouserDto.Role;
     var result=     _Rolemanger.UpdateAsync(applicationUser); 

          


            return new AuthModel { Message = "updated role Data" };



        }
    }

}
