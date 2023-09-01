using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using IREprestory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using SystemEnums;

namespace ReprestoryServess
{
    public class EmployeeServsss : PaginationHelper<EmployeeVM>, Iemployee
    {
        Imgoperation _Imgoperation;
        private ApplicationDBcontext _DBcontext;
        private readonly UserManager<Applicaionuser> _user;



        public EmployeeServsss(ApplicationDBcontext db, UserManager<Applicaionuser> user, Imgoperation lookupServess)
        {
            _Imgoperation = lookupServess;
            _user = user;
            _DBcontext = db;
        }















        //private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        //{
            
        //}

        public async Task Save(EmployeeVM entity)
        {
         entity.imgPath=  _Imgoperation.Uploadimg(entity.ImgUrl);

            var model = EmployeeVM.CanconvertViewmodel(entity);

            if (entity.Id != null)
            {
                //// Update existing entity
                //var existingUser =  _DBcontext.Employees.Find(entity.Id);

                //// Update properties of existingUser
                //existingUser.Salary = entity.Salary;
                //existingUser.JobTitle = entity.Adress;
                //existingUser.ContructUrl = entity.ContructUrl;
                //existingUser.HirangDate = entity.HirangDate;
                //existingUser.Email = entity.Email;
                //existingUser.Gender = entity.Gender;
                //existingUser.ImgUrl = entity.imgPath;
                //existingUser.PhoneNumber = entity.PhoneNumber;
                //existingUser.PasswordHash = entity.PasswordHash;
                //existingUser.UserName = entity.UserName;

               




                var updateResult =  _DBcontext.Employees.Update(model);

                await _DBcontext.SaveChangesAsync();
            }
            else
            {




                var updateResult = _DBcontext.Employees.Add(model);

                await _DBcontext.SaveChangesAsync();
            }

        }



        public async Task<bool> Delete(string id)
        {
           
                var user = _DBcontext.Employees.Find(id);
                if (user != null)
                {
                    var roles = await _user.GetRolesAsync(user);
                    foreach (var role in roles)
                    {
                        await _user.RemoveFromRoleAsync(user, role);
                    }
                var deleeteduser = await GetById(id);
                deleeteduser.iDeleted = IsDeleted.Deleted;
                    Save(deleeteduser);


                    _DBcontext.SaveChanges();

                }
            return true; 
            
            
            }
      
       



        public async Task<EmployeeVM> GetById(string id)
        {
            var model = await
             _DBcontext.Employees.Where(p => p.Id == id && p.IsDeleted==IsDeleted.NotDeleted).Select(ApplicationUser => new EmployeeVM
             {

                 Id = ApplicationUser.Id,
                 UserName = ApplicationUser.UserName,

                 Email = ApplicationUser.Email,
                 Gender = ApplicationUser.Gender,
                 Adress = ApplicationUser.Adress,
                 BirthDate = ApplicationUser.BirthDate,
                 PhoneNumber = ApplicationUser.PhoneNumber,
                 imgPath =ApplicationUser.ImgUrl,
                 //Bouns = ApplicationUser.Bouns,
                 JobTitle = ApplicationUser.JobTitle,
                 HirangDate = ApplicationUser.HirangDate,
                 ContructUrl = ApplicationUser.ContructUrl,
                 Salary = ApplicationUser.Salary,
                 IsDeleted = ApplicationUser.IsDeleted,

             }).FirstOrDefaultAsync();
            return model;
        }

       

        public IEnumerable<EmployeeVM> GetAll()
        {
            var model =
            _DBcontext.Employees. Where(p=>p.IsDeleted == IsDeleted.NotDeleted). Select(ApplicationUser => new EmployeeVM
            {

                Id = ApplicationUser.Id,
                UserName = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                Gender = ApplicationUser.Gender,
                Adress = ApplicationUser.Adress,
                BirthDate = ApplicationUser.BirthDate,
                PhoneNumber = ApplicationUser.PhoneNumber,
                imgPath = ApplicationUser.ImgUrl,
                //Bouns = ApplicationUser.Bouns,
                JobTitle = ApplicationUser.JobTitle,
                HirangDate = ApplicationUser.HirangDate,
                ContructUrl = ApplicationUser.ContructUrl,
                Salary = ApplicationUser.Salary,
                IsDeleted = ApplicationUser.IsDeleted,
            }).ToList();
            return model;
        }

        bool Iemployee.SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }
    }
}