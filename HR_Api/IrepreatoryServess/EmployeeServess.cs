using DataAcess.layes;
using HR_Api.Utellites
;
    using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using HR_Api.Utellites;

namespace HR_Api.IrepreatoryServess
{
    public class EmployeeServess : PaginationHelper<AplicatiouserDto>, Iemployee_Api
    {
        Imgoperation _Imgoperation;
        private ApplicationDBcontext _DBcontext;
        private   UserManager<Applicaionuser> _user;



        public EmployeeServess(ApplicationDBcontext db, UserManager<Applicaionuser> user, Imgoperation lookupServess)
        {
            _Imgoperation = lookupServess;
            _user = user;
            _DBcontext = db;
        }















        //private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        //{

        //}


        public async Task Save(AplicatiouserDto entity)
        {
            var model = AplicatiouserDto.CanconvertViewmodel(entity);

            if (entity.Id != null)
            {
                // Update existing entity
                var existingUser = await _user.FindByIdAsync(entity.Id);

                // Update properties of existingUser
                existingUser.Salary = (double?)entity.Salary;
                existingUser.JobTitle = entity.JobTitle; 
                existingUser.HirangDate = entity.HirangDate;
                existingUser.Email = entity.Email;
                //existingUser.Gender = entity.Gender;
                //existingUser.RoleRegeseter = entity.RoleRegeseter;
     

                existingUser.PhoneNumber = entity.PhoneNumber;

                existingUser.Adress = entity.Address;
                existingUser.UserName = entity.UserName;

                //if (entity.imgurlupdated == null)


                //{
                //    existingUser.imphgurl = _user.Users.Where(x => x.Id == entity.id).Select(e => e.imphgurl).FirstOrDefault();
                //}
                //else
                //{

                //    existingUser.imphgurl = _lookupServess.Uploadimg(entity.imgurlupdated);
                //}



                //existingUser.statusDoctorInSystem = entity.StatusDoctorInSystem;


                var updateResult = await _user.UpdateAsync(existingUser);

                await _DBcontext.SaveChangesAsync();
            }
            else
            {

                var updateResult = await _user.CreateAsync(model);

                await _DBcontext.SaveChangesAsync();
            }

        }




        public async Task<bool> Delete(string id)
        {

            var user =    _user.Users.Where(i=>i.Id==id).FirstOrDefault();
            //if (user != null)
            //{
            //    var roles =  await _user.GetRolesAsync(user);
            //    foreach (var role in roles)
            //    {
            //          _user.RemoveFromRoleAsync(user, role);
            //    }
            //    var deleeteduser =   GetById(id);

                _user.DeleteAsync(user);

                _DBcontext.SaveChanges();

            //}
            return true;


        }





        public   Task<AplicatiouserDto> GetById(string id)
        {
            var model =  
            _user.Users.Where(p => p.Id == id ).Select(ApplicationUser => new AplicatiouserDto
            {

                Id = ApplicationUser.Id,
                UserName = ApplicationUser.UserName,

                Email = ApplicationUser.Email,
                //Gender = ApplicationUser.Gender,
                //Address = ApplicationUser.Adress,
                //BirthDate = ApplicationUser.BirthDate,
                //PhoneNumber = ApplicationUser.PhoneNumber,
                //ImgUrl = ApplicationUser.ImgUrl,
                //Bouns = (decimal)ApplicationUser.Bouns,
                //JobTitle = ApplicationUser.JobTitle,
                //HirangDate = ApplicationUser.HirangDate,
                //contracturl = ApplicationUser.ContructUrl,
                //Salary = (decimal)ApplicationUser.Salary,

            }).FirstOrDefaultAsync();
            return model;
        }



        public IEnumerable<AplicatiouserDto> GetAll()
        {
            var model =
              _user.Users.Select(ApplicationUser => new AplicatiouserDto
              {

                  //Id = ApplicationUser.Id,
                  UserName = ApplicationUser.UserName,

                  Email = ApplicationUser.Email,
                  //Gender = ApplicationUser.Gender,
                  //Adress = ApplicationUser.Adress,
                  //BirthDate = ApplicationUser.BirthDate,
                  //PhoneNumber = ApplicationUser.PhoneNumber,
                  //imgPath = ApplicationUser.ImgUrl,
                  //Bouns = ApplicationUser.Bouns,
                  //JobTitle = ApplicationUser.JobTitle,
                  //HirangDate = ApplicationUser.HirangDate,
                  //ContructPath = ApplicationUser.ContructUrl,
                  //Salary = ApplicationUser.Salary,
                  //IsDeleted = ApplicationUser.IsDeleted,
              }).ToList();
            return model;
        }
        public   async   Task<IEnumerable<AplicatiouserDto>> Search(string str = null)
        {
            str = str?.Trim().ToLower(); // Convert searchTerm to lowercase

            return   _user.Users
                .Where(p =>
                    string.IsNullOrWhiteSpace(str) || // Return all items if searchTerm is empty
                    p.UserName.ToLower().Contains(str))
                .Select(p => new AplicatiouserDto
                {
                    Id = p.Id,
                     UserName = p.UserName,
                })
                .ToList();
        }
      
    }
}
