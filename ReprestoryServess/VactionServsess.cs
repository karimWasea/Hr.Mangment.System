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
    public class VactionServsess : PaginationHelper<VactionVm>, IVaction
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public VactionServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(VactionVm entity)
        {


            var model = VactionVm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.Vacations.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.Vacations.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<VactionVm> GetAll()
        {
            var model= _Context.Vacations.Include(p => p.Employee).Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new VactionVm
            {
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                isDeleted = p.IsDeleted,
                EmployeeName = _user.Users.Where(m => m.Id == p.EmployeeId).Select(p => p.UserName).FirstOrDefault(),


            }).ToList();

            return model;
        }

        public VactionVm GetById(int id)
        {
            return _Context.Vacations.Include(p=>p.Employee).Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new VactionVm
            {
                isDeleted = p.IsDeleted, 
 Id = p.Id,
              
                EmployeeId = p.EmployeeId,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                EmployeeName =_user.Users.Where(m=>m.Id==p.EmployeeId).Select(p=>p.UserName).FirstOrDefault(),

             
            }).FirstOrDefault();
        }



        public VactionVm GETVATIONEMPOYEEID(String id)
        {
            return _Context.Vacations.Include(p => p.Employee).Where(p =>p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new VactionVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,

                EmployeeId = p.EmployeeId,
                EndDate = p.EndDate,
                StartDate = p.StartDate,
                EmployeeName = _user.Users.Where(m => m.Id == id).Select(p => p.UserName).FirstOrDefault(),


            }).FirstOrDefault();
        }















        public bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
