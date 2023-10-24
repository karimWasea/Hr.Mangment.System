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
    public class EmployeeTriningServsess : PaginationHelper<EmployeeTrininTVm>,IEmployeetrining
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public EmployeeTriningServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(EmployeeTrininTVm entity)
        {
            foreach (var selectedid in entity.selectTriningids)
            {
                 entity.Triningid = selectedid;
                var model = EmployeeTrininTVm.CanconvertViewmodel(entity);
            

        

            if (entity.Id > 0)
            {
                _Context.EmployeeTrainings.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.EmployeeTrainings.Add(model);

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

        public IEnumerable<EmployeeTrininTVm> GetAll()
        {
            return _Context.EmployeeTrainings.Include(p=>p.Employee). Where( p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeTrininTVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
    Triningid= (int)p.TrainingId,


            }).ToList().OrderBy(b=>b.EmployeeName);    

        }

        public IEnumerable<EmployeeTrininTVm> GetAllTrainingsByemployeeId( string id )
        {
            var model= _Context.EmployeeTrainings.Include(p => p.Employee).Where(p => p.EmployeeId==id).Select(p => new EmployeeTrininTVm
            {

                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.UserName,
                Triningid = (int)p.TrainingId,
                 Name =p.Training.TrainingName,

            }).ToList().OrderBy(b => b.EmployeeName);
return model;
        }









        public EmployeeTrininTVm GetById(int id)
        {
            return _Context.EmployeeTrainings.Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeTrininTVm
            {
 isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
    Triningid= (int)p.TrainingId,

             
            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
