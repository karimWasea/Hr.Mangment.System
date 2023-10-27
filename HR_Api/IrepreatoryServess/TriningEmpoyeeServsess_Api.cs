using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

using static HR_Api.Dtos.VacarionDTOAdd;

namespace HR_Api.IrepreatoryServess
{
    public class TriningEmpoyeeServsess_Api : PaginationHelper<EmployeeTriningDTO>, ITriningEmpoyee_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
      
        public TriningEmpoyeeServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public EmployeeTraining Update(EmployeeTriningDTO entity)
        {
            // Assuming EmployeedeviceDTO.CanconvertViewmodel(entity) converts to EmployeeDevice


            var modelsToUpdate = entity.TrainiIngIds.Select(selectedid => new EmployeeTraining
            {
                TrainingId = selectedid,
                EmployeeId = entity.EmployeeId,
                Id = entity.Id,

            }).ToList();
            _Context.EmployeeTrainings.UpdateRange(modelsToUpdate);
            _Context.SaveChanges();

            return modelsToUpdate.LastOrDefault();
        }
     public EmployeeTraining Add(EmployeeTriningDTOAdd entity)
        {
            // Assuming EmployeedeviceDTO.CanconvertViewmodel(entity) converts to EmployeeDevice


            var modelsToUpdate = entity.TrainiIngIds.Select(selectedid => new EmployeeTraining
            {
                TrainingId = selectedid,
                EmployeeId = entity.EmployeeId,


            });
            _Context.EmployeeTrainings.AddRange(modelsToUpdate);
            _Context.SaveChanges();

            return modelsToUpdate.LastOrDefault();
        }



      

        //public EmployeeTriningDTO Save(EmployeeTriningDTO entity)
        //{



        //    foreach (var selectedid in entity.TrainiIngIds)
        //    {
        //        entity.TrainingId = selectedid;
        //        var model = EmployeeTriningDTO.ConvertTODTOToObj(entity);




        //        if (entity.Id > 0)
        //        {
        //            _Context.EmployeeTrainings.Update(model);




        //        }
        //        else
        //        {


        //            _Context.EmployeeTrainings.Add(model);





        //        }

        //        _Context.SaveChanges();

        //    }

        //    return entity;
        //}





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.EmployeeTrainings.Find(id);
            _Context.EmployeeTrainings.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


        }

        public IEnumerable<EmployeeTriningDTO> GetAll()
        {
            return _Context. EmployeeTrainings.Include(p => p.Training).Include(p => p.Employee)
                .Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted)
                .Select(p => new EmployeeTriningDTO
                {
                    Id = p.Id,
                    EmployeeId = p.EmployeeId,
                     TrainingId =  p.TrainingId
                    //_Context.Trainings.Where(i => i.Id == p.TrainingId).Select(i => i.Id).ToList()
                })
               .ToList();
           
        }

        public EmployeeTriningDTO GetById(int id)
        {
            return _Context.EmployeeTrainings.Include(p=>p.Training).Include(p=>p.Employee)
                .Where(p => p.Id == id )
                .Select(p => new EmployeeTriningDTO
                {
                    Id = p.Id,
                    EmployeeId = p.EmployeeId,
                    TrainingId = p.TrainingId
                    //TrainiIngIds = _Context.Trainings.Where(i => i.Id == p.TrainingId).Select(i => i.Id).ToList()
                })
                .FirstOrDefault();
        }


        public IEnumerable< EmployeeTriningDTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.EmployeeTrainings
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.EmployeeId.ToLower().Contains(searchTerm))
                .Select(p => new EmployeeTriningDTO
                {
                    Id = p.Id,
                })
                .ToList();
        }
      
        public IEnumerable<EmployeeTriningDTO> EmployeeTRining(string str = null)
        {
            return _Context.EmployeeTrainings.Include(p => p.Training).Include(p => p.Employee)
                    .Where(p =>p.EmployeeId== str)
                    .Select(p => new EmployeeTriningDTO
                    {
                        Id = p.Id,
                        EmployeeId = p.EmployeeId,
                         TrainingId = p.TrainingId
                        //TrainiIngIds = _Context.Trainings.Where(i => i.Id == p.TrainingId).Select(i => i.Id).ToList()
                    })
                   .ToList();
        }

        






        //public IEnumerable<DepartmintDTO> Search(string searchTerm)
        //{
        //    if (string.IsNullOrWhiteSpace(searchTerm))
        //    {
        //        // If searchTerm is empty, return all departments
        //        var allDepartments = _Context.Departments
        //            .Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Include(t => t.Employees)
        //            .Select(p => new DepartmintDTO
        //            {
        //                Id = p.Id,
        //                Name = p.DepartmentName,
        //                ManagerId = p.ManagerId,
        //                mangerName = _user.Users
        //                    .Where(m => m.Id == p.ManagerId)
        //                    .Select(m => m.UserName)
        //                    .FirstOrDefault(),
        //            })
        //            .ToList();

        //        return allDepartments;
        //    }

        //else
        //{
        //  //  If searchTerm is not empty, perform the search
        //           var departments = _Context.Departments
        //               .Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted &&
        //                           (p.DepartmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
        //                            _user.Users.Any(u => u.Id == p.ManagerId || u.UserName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase)))
        //                            || string.IsNullOrWhiteSpace(searchTerm)

        //                            )
        //               .Select(p => new DepartmintDTO
        //               {
        //                   Id = p.Id,
        //                   Name = p.DepartmentName,
        //                   ManagerId = p.ManagerId,
        //                   mangerName = _user.Users
        //                       .Where(m => m.Id == p.ManagerId)
        //                       .Select(m => m.UserName)
        //                       .FirstOrDefault(),
        //               })
        //               .ToList();

        //    return departments;
        //    }
        //}



    }
}
