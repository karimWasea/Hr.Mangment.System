


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















       


        public   Task Save(EmployeeVM entity)
        {
            //entity.imgPath = _Imgoperation.Uploadimg(entity.ImgUrl);
            //entity.ContructPath = _Imgoperation.Uploadimg(entity.ContructUrl);



            if (entity.Id != null)
            {

                //var existingUser = await _user.FindByIdAsync(entity.Id);
                var existingUser =   _user.Users.Where(i=>i.Id==entity.Id).Select(i=>i).FirstOrDefault();

                //if (existingUser != null)
                //{

                    existingUser.Salary = entity.Salary;
                    existingUser.JobTitle = entity.Adress;
                    existingUser.ContructUrl = _Imgoperation.Uploadimg(entity.ContructUrl);
                    existingUser.HirangDate = entity.HirangDate;
                    existingUser.Email = entity.Email;
                    existingUser.Gender = entity.Gender;
                    existingUser.ImgUrl = entity.imgPath;
                    existingUser.PhoneNumber = entity.PhoneNumber;
                    existingUser.PasswordHash = entity.PasswordHash;
                    existingUser.UserName = entity.UserName;
                    existingUser.PasswordHash = "Karim566@gmail.comm";
                    existingUser.BirthDate = DateTime.Now;

                //if (entity.imgPath == null)


                //{
                //    existingUser.ImgUrl = _user.Users.Where(x => x.Id == entity.Id).Select(e => e.ImgUrl).FirstOrDefault();
                //}
                //else
                //{

                    existingUser.ImgUrl = _Imgoperation.Uploadimg(entity.ImgUrl);


                    var updateResult = _user.UpdateAsync(existingUser);
                    _DBcontext.SaveChangesAsync();
                //}
                 return Task.CompletedTask; 
                //}
            }
            else
            {
                var newUser = new Applicaionuser();

                newUser.Salary = entity.Salary;
                newUser.JobTitle = entity.Adress;
                newUser.ContructUrl = entity.ContructPath;
                newUser.HirangDate = entity.HirangDate;
                newUser.Email = entity.Email;
                newUser.Gender = entity.Gender;
                newUser.ImgUrl = entity.imgPath;
                newUser.PhoneNumber = entity.PhoneNumber;

           


                var createResult =   _user.CreateAsync(newUser, newUser.PasswordHash); // Use newUser.PasswordHash instead

                  _DBcontext.SaveChangesAsync();
                return Task.CompletedTask;

            }
        }




        public async Task<bool> Delete(string id)
        {

            var user =   _user.Users.Where(i=>i.Id==id).Select(p=>p).FirstOrDefault();
            //if (user != null)
            //{
            //    var roles = await _user.GetRolesAsync(user);
            //    foreach (var role in roles)
            //    {
            //        await _user.RemoveFromRoleAsync(user, role);
            //    }

                _DBcontext.Users.Remove(user);

                _DBcontext.SaveChanges();
            //}
                
            return true; 
            
            
            }
      
       



        public async Task<EmployeeVM> GetById(string id)
        {
            var model = await
            _user.Users.Where(p => p.Id == id && p.IsDeleted==IsDeleted.NotDeleted).Select(ApplicationUser => new EmployeeVM
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
                 ContructPath = ApplicationUser.ContructUrl,
                 Salary = ApplicationUser.Salary,
                 IsDeleted = ApplicationUser.IsDeleted,

             }).FirstOrDefaultAsync();
            return model;
        }

       

        public IEnumerable<EmployeeVM> GetAll()
        {
            var model =
              _user.Users. Where(p=>p.IsDeleted != IsDeleted.Deleted). Select(ApplicationUser => new EmployeeVM
            {

                Id = ApplicationUser.Id,
                UserName = ApplicationUser.UserName,

                  Email = ApplicationUser.Email,
                  //Gender = ApplicationUser.Gender,
                  //Adress = ApplicationUser.Adress,
                  //BirthDate = ApplicationUser.BirthDate,
                  //PhoneNumber = ApplicationUser.PhoneNumber,
                  imgPath = ApplicationUser.ImgUrl,
                  //Bouns = ApplicationUser.Bouns,
                  //JobTitle = ApplicationUser.JobTitle,
                  //HirangDate = ApplicationUser.HirangDate,
                  //ContructPath = ApplicationUser.ContructUrl,
                  //Salary = ApplicationUser.Salary,
                  //IsDeleted = ApplicationUser.IsDeleted,
              }).ToList();
            return model;
        }

       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }
    }
}