using DataAcess.layes;
using HR.ViewModel;

using Intersoft.Crosslight.Mobile;

using IREprestory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprestoryServess
{
    public class TimeShiftServsss : PaginationHelper<TimeShiftVM>, ITimeShift
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public TimeShiftServsss(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(TimeShiftVM entity)
        {


            var model = TimeShiftVM.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.TimeShifts.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.TimeShifts.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<TimeShiftVM> GetAll()
        {
            var model= _Context.TimeShifts.Include(p => p.Employee).Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new TimeShiftVM
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EndingTime = p.EndingTime,
                shiftStuTework = p.shiftStuTework,
                StartingTime = p.StartingTime,
                IsDeleted = p.IsDeleted,
 EmployeeName=_user.Users.Select(u=>u.UserName).FirstOrDefault()
            }).ToList();

            return model;
        }

        public TimeShiftVM GetById(int id)
        {
            return 
                _Context.TimeShifts.Include(p => p.Employee).Where( p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted &&p.Id==id).Select(p => new TimeShiftVM
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EndingTime = p.EndingTime,
                shiftStuTework = p.shiftStuTework,
                StartingTime = p.StartingTime,
                IsDeleted = p.IsDeleted,
                    EmployeeName = _user.Users.Select(u => u.UserName).FirstOrDefault()


                }).FirstOrDefault();
        }


















        public bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
