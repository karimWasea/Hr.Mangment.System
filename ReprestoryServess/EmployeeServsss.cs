//using DataAcess.layes;

//using HR.Utailites;
//using HR.ViewModel;

//using IREprestory;

//using Microsoft.AspNetCore.Identity;

//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;

//namespace ReprestoryServess
//{
//    internal class EmployeeServsss : PaginationHelper<EmployeeVM>, Iemployee
//    {
//        Imgoperation _lookupServess;
//        private readonly UserManager<ApplicationUser> _user;



//        private ApplicationDBcontext _db;
//        public Doctorserves(ApplicationDBcontext db, UserManager<ApplicationUser> user, Imgoeration lookupServess)
//        {
//            _lookupServess = lookupServess;
//            _user = user;
//            _db = db;
//        }

















//        public async Task Save(DoctorVm entity)
//        {
//            var model = DoctorVm.CanconvertViewmodel(entity);

//            if (entity.id != null)
//            {
//                // Update existing entity
//                var existingUser = await _user.FindByIdAsync(entity.id);

//                // Update properties of existingUser
//                existingUser.Salary = entity.Salary;
//                existingUser.Nationality = entity.Nationality;
//                existingUser.spicialist = entity.spicialist;
//                existingUser.Title = entity.Title; existingUser.WorkingDaysinWeek = entity.WorkingDaysinWeek;
//                existingUser.Contracturl = entity.Contracturl;
//                existingUser.HiringDate = entity.HiringDate;
//                existingUser.Email = entity.Email;
//                existingUser.Gender = entity.Gender;
//                existingUser.RoleRegeseter = entity.RoleRegeseter;
//                existingUser.HiringDate = entity.HiringDate;
//                existingUser.imphgurl = entity.imphgurl;
//                existingUser.PhoneNumber = entity.Phonenumber;
//                existingUser.PostalCode = entity.PostalCode;
//                existingUser.StreetAddress = entity.StreetAddress;
//                existingUser.UserName = entity.username;

//                if (entity.imgurlupdated == null)


//                {
//                    existingUser.imphgurl = _user.Users.Where(x => x.Id == entity.id).Select(e => e.imphgurl).FirstOrDefault();
//                }
//                else
//                {

//                    existingUser.imphgurl = _lookupServess.Uploadimg(entity.imgurlupdated);
//                }



//                existingUser.statusDoctorInSystem = entity.StatusDoctorInSystem;


//                var updateResult = await _user.UpdateAsync(existingUser);

//                await _db.SaveChangesAsync();
//            }
//            else
//            {

//                var updateResult = await _user.CreateAsync(model);

//                await _db.SaveChangesAsync();
//            }

//        }



//        public async Task<bool> Delete(string id)
//        {
//            try
//            {
//                var user = await _user.FindByIdAsync(id);
//                if (user != null)
//                {
//                    var roles = await _user.GetRolesAsync(user);
//                    foreach (var role in roles)
//                    {
//                        await _user.RemoveFromRoleAsync(user, role);
//                    }

//                    var result = await _user.DeleteAsync(user);

//                    if (result.Succeeded)
//                    {
//                        await _db.SaveChangesAsync();
//                        return true;
//                    }
//                    else
//                    {
//                        // Handle user deletion failure
//                        foreach (var error in result.Errors)
//                        {
//                            // Log or handle each error message
//                        }
//                        return false;
//                    }
//                }
//                else
//                {
//                    // Handle user not found
//                    return false;
//                }
//            }
//            catch (Exception ex)
//            {
//                // Handle exceptions
//                // Log the exception details for troubleshooting
//                return false;
//            }
//        }
//        public async Task<IEnumerable<DoctorVm>> GetallconfirmedDoctor()
//        {
//            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Doctor && ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Confirmed).Select(ApplicationUser => new DoctorVm
//            {
//                id = ApplicationUser.Id,
//                username = ApplicationUser.UserName,

//                Email = ApplicationUser.Email,
//                RoleRegeseter = ApplicationUser.RoleRegeseter,
//                Gender = ApplicationUser.Gender,
//                StreetAddress = ApplicationUser.StreetAddress,
//                City = ApplicationUser.City,
//                Dateofbarth = ApplicationUser.Dateofbarth,
//                Phonenumber = ApplicationUser.PhoneNumber,
//                Nationality = ApplicationUser.Nationality,
//                imphgurl = ApplicationUser.imphgurl,
//                PostalCode = ApplicationUser.PostalCode,
//                Title = ApplicationUser.Title,
//                HiringDate = ApplicationUser.HiringDate,
//                Contracturl = ApplicationUser.Contracturl,
//                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

//                WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
//                Salary = ApplicationUser.Salary,



//            }).ToListAsync();

//            return _users;
//        }

//        public async Task<DoctorVm> GetByIdasRegisterdoctor(string id)
//        {
//            var model = await
//             _user.Users.Where(p => p.Id == id && p.statusDoctorInSystem == Cofimationdoctor.Regeseter).Select(ApplicationUser => new DoctorVm
//             {
//                 id = ApplicationUser.Id,
//                 username = ApplicationUser.UserName,

//                 Email = ApplicationUser.Email,
//                 RoleRegeseter = ApplicationUser.RoleRegeseter,
//                 Gender = ApplicationUser.Gender,
//                 StreetAddress = ApplicationUser.StreetAddress,
//                 City = ApplicationUser.City,
//                 Dateofbarth = ApplicationUser.Dateofbarth,
//                 Phonenumber = ApplicationUser.PhoneNumber,
//                 Nationality = ApplicationUser.Nationality,
//                 imphgurl = ApplicationUser.imphgurl,
//                 PostalCode = ApplicationUser.PostalCode,
//                 Title = ApplicationUser.Title,
//                 HiringDate = ApplicationUser.HiringDate,
//                 Contracturl = ApplicationUser.Contracturl,
//                 StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

//                 WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
//                 Salary = ApplicationUser.Salary,





//             }).FirstOrDefaultAsync();
//            return model;
//        }



//        public async Task<IEnumerable<DoctorVm>> GetAllDoctorRegester()
//        {
//            // && ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Regeseter
//            var _users = await _user.Users.Where(ApplicationUser => ApplicationUser.RoleRegeseter == RoleRegeseter.Doctor && ApplicationUser.statusDoctorInSystem == Cofimationdoctor.Regeseter).Select(ApplicationUser => new DoctorVm
//            {


//                id = ApplicationUser.Id,
//                username = ApplicationUser.UserName,

//                Email = ApplicationUser.Email,
//                RoleRegeseter = ApplicationUser.RoleRegeseter,
//                Gender = ApplicationUser.Gender,
//                StreetAddress = ApplicationUser.StreetAddress,
//                City = ApplicationUser.City,
//                Dateofbarth = ApplicationUser.Dateofbarth,
//                Phonenumber = ApplicationUser.PhoneNumber,
//                Nationality = ApplicationUser.Nationality,
//                imphgurl = ApplicationUser.imphgurl,
//                PostalCode = ApplicationUser.PostalCode,
//                StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,
//                spicialist = ApplicationUser.spicialist,






//            }).ToListAsync();
//            return _users;
//        }

//        public async Task<DoctorVm> GetByIdasconfirmed(string id)
//        {
//            // && p.statusDoctorInSystem == Cofimationdoctor.Regeseter
//            var model = await
//             _user.Users.Where(p => p.Id == id).Select(ApplicationUser => new DoctorVm
//             {
//                 id = ApplicationUser.Id,
//                 username = ApplicationUser.UserName,

//                 Email = ApplicationUser.Email,
//                 RoleRegeseter = ApplicationUser.RoleRegeseter,
//                 Gender = ApplicationUser.Gender,
//                 StreetAddress = ApplicationUser.StreetAddress,
//                 City = ApplicationUser.City,
//                 Dateofbarth = ApplicationUser.Dateofbarth,
//                 Phonenumber = ApplicationUser.PhoneNumber,
//                 Nationality = ApplicationUser.Nationality,
//                 imphgurl = ApplicationUser.imphgurl,
//                 PostalCode = ApplicationUser.PostalCode,
//                 Title = ApplicationUser.Title,
//                 HiringDate = ApplicationUser.HiringDate,
//                 Contracturl = ApplicationUser.Contracturl,
//                 StatusDoctorInSystem = ApplicationUser.statusDoctorInSystem,

//                 WorkingDaysinWeek = ApplicationUser.WorkingDaysinWeek,
//                 Salary = ApplicationUser.Salary,





//             }).FirstOrDefaultAsync();
//            return model;
//        }

//    }
//}