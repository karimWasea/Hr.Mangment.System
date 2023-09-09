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
    public class EmployeeWorkScheduleCurentWeekDayServsess : PaginationHelper<EmployeeWorkScheduleCurentWeekDayVm>,IEmployeeWorkScheduleCurentWeekDay
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public EmployeeWorkScheduleCurentWeekDayServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(EmployeeWorkScheduleCurentWeekDayVm entity)
        {
            foreach (var selectedid in entity.selectShiftids)
            {
                 entity.Shiftid = selectedid;
                var model = EmployeeWorkScheduleCurentWeekDayVm.CanconvertViewmodel(entity);
            

        

            if (entity.Id > 0)
            {
                _Context.EmployeeWorkScheduleCurentWeekDay.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.EmployeeWorkScheduleCurentWeekDay.Add(model);

                _Context.SaveChanges();


            }
            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<EmployeeWorkScheduleCurentWeekDayVm> GetAll()
        {
            return _Context.EmployeeWorkScheduleCurentWeekDay.Include(p=>p.Employee). Where( p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeWorkScheduleCurentWeekDayVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
    Shiftid= (int)p.TimeShiftId,


            }).ToList().OrderBy(b=>b.EmployeeName);    

        }

        public IEnumerable<EmployeeWorkScheduleCurentWeekDayVm> GetAllShiftByemployeeId( string id )
        {
            return _Context.EmployeeWorkScheduleCurentWeekDay.Include(p => p.Employee).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted && p.EmployeeId==id).Select(p => new EmployeeWorkScheduleCurentWeekDayVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.UserName,
                Shiftid = (int)p.TimeShiftId,
                 Name =p.WorkScheduleCurentWeekDay.DisplayShift,

            }).ToList().OrderBy(b => b.EmployeeName);

        }









        public EmployeeWorkScheduleCurentWeekDayVm GetById(int id)
        {
            return _Context.EmployeeWorkScheduleCurentWeekDay.Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeWorkScheduleCurentWeekDayVm
            {
 isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
    Shiftid= (int)p.TimeShiftId,

             
            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
