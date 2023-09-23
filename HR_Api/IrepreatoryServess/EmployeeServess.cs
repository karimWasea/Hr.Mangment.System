﻿using DataAcess.layes;
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
    public class EmployeeServess : PaginationHelper<AplicatiouserDto>, Iemployee_Api
    {
        Imgoperation _Imgoperation;
        private ApplicationDBcontext _DBcontext;
        private   UserManager<Applicaionuser> _userManager;



        public EmployeeServess(ApplicationDBcontext db, UserManager<Applicaionuser> user, Imgoperation lookupServess)
        {
            _Imgoperation = lookupServess;
            _userManager = user;
            _DBcontext = db;
        }


















        



        public   Task<AplicatiouserDto> GetById(string id)
        {
            var model =
          _userManager.Users.Where(p => p.Id == id ).Select(ApplicationUser => new AplicatiouserDto
            {
              Id = ApplicationUser.Id,
              UserName = ApplicationUser.UserName,

              Email = ApplicationUser.Email,
              Gender = ApplicationUser.Gender,
              Address = ApplicationUser.Adress,
              //BirthDate = ApplicationUser.BirthDate,
              PhoneNumber = ApplicationUser.PhoneNumber,
              //imgPath = ApplicationUser.ImgUrl,
              //Bouns = ApplicationUser.Bouns,
              JobTitle = ApplicationUser.JobTitle,
              HirangDate = ApplicationUser.HirangDate,
              //ContructPath = ApplicationUser.ContructUrl,
              Salary = (decimal)ApplicationUser.Salary,
              //IsDeleted = ApplicationUser.IsDeleted,

          }).FirstOrDefaultAsync();
            return model;
        }



        public IEnumerable<AplicatiouserDto> GetAll()
        {
            var model =
           _userManager.Users.Select(ApplicationUser => new AplicatiouserDto
              {

                  Id = ApplicationUser.Id,
                  UserName = ApplicationUser.UserName,

                  Email = ApplicationUser.Email,
               Gender = ApplicationUser.Gender,
               Address = ApplicationUser.Adress,
               //BirthDate = ApplicationUser.BirthDate,
               PhoneNumber = ApplicationUser.PhoneNumber,
               //imgPath = ApplicationUser.ImgUrl,
               //Bouns = ApplicationUser.Bouns,
               JobTitle = ApplicationUser.JobTitle,
               HirangDate = ApplicationUser.HirangDate,
               //ContructPath = ApplicationUser.ContructUrl,
               Salary = (decimal)ApplicationUser.Salary,
               //IsDeleted = ApplicationUser.IsDeleted,
           }).ToList();
            return model;
        }
        public async Task<IEnumerable<AplicatiouserDto>> Search(string str = null)
        {
            str = str?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _userManager.Users
                .Where(p =>
                    string.IsNullOrWhiteSpace(str) || // Return all items if searchTerm is empty
                    p.UserName.ToLower().Contains(str))
                .Select(p => new AplicatiouserDto
                {

                    Id = p.Id,
                    UserName = p.UserName,

                    Email = p.Email,
                    //Gender = ApplicationUser.Gender,
                    Address = p.Adress,
                    //BirthDate = ApplicationUser.BirthDate,
                    PhoneNumber = p.PhoneNumber,
                    //imgPath = ApplicationUser.ImgUrl,
                    //Bouns = ApplicationUser.Bouns,
                    JobTitle = p.JobTitle,
                    HirangDate = p.HirangDate,
                    //ContructPath = ApplicationUser.ContructUrl,
                    Salary = (decimal)p.Salary,
                    //IsDeleted = ApplicationUser.IsDeleted,
                })
                .ToList();
        }
        public async Task<bool> Delete(string id)
        {

            var user = _userManager.Users.Where(i => i.Id == id).FirstOrDefault();
            //if (user != null)
            //{
            //    var roles =  await _user.GetRolesAsync(user);
            //    foreach (var role in roles)
            //    {
            //          _user.RemoveFromRoleAsync(user, role);
            //    }
            //    var deleeteduser =   GetById(id);

            _userManager.DeleteAsync(user);

            _DBcontext.SaveChanges();

            //}
            return true;


        }

        public async Task<AuthModel> Creat(AplicatiouserDtoCreat entity)
        {
            var user = AplicatiouserDtoCreat.CanconvertViewmodel(entity);
           
            var result = await _userManager.CreateAsync(user, entity.PasswordHash);

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
            await _userManager.AddToRoleAsync(user, "User");

            return new AuthModel { Message = "Addnew employee" };
        }

                public async Task<AuthModel> Update(AplicatiouserDto aplicatiouserDto)
        {


            var applicationUser =  await _userManager.FindByIdAsync(aplicatiouserDto.Id);


            //var user = AplicatiouserDto.CanconvertViewmodel(finduser);
            // Map properties from AplicatiouserDto to Applicaionuser
            applicationUser.Id = aplicatiouserDto.Id;
            //applicationUser.BirthDate = aplicatiouserDto.BirthDate;
            applicationUser.Adress = aplicatiouserDto.Address;
            applicationUser.Salary = (double?)aplicatiouserDto.Salary;
            applicationUser.DepartmentId = aplicatiouserDto.DepartmentId;
            //applicationUser.Bouns = (double?)aplicatiouserDto.Bouns;
            applicationUser.JobTitle = aplicatiouserDto.JobTitle;
            applicationUser.PhoneNumber = aplicatiouserDto.PhoneNumber;
            applicationUser.HirangDate = aplicatiouserDto.HirangDate;
            applicationUser.UserName = aplicatiouserDto.UserName;
            applicationUser.Email = aplicatiouserDto.Email;
            applicationUser.ContructUrl = aplicatiouserDto.contractUrl;
            applicationUser.PasswordHash = aplicatiouserDto.PasswordHash;
            applicationUser.ImgUrl = aplicatiouserDto.ImgUrl;
            var result = await _userManager.UpdateAsync(applicationUser);

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
            await _userManager.AddToRoleAsync(applicationUser, "User");

            return new AuthModel { Message = "updated employee Data" };



        }
    }

}
