using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

namespace HR_Api.IrepreatoryServess
{
    public class VacationServsess_Api : PaginationHelper<VacarionDTO>, IVaction_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public VacationServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public VacarionDTO Save(VacarionDTO entity)
        {


            var model = VacarionDTO.ConvertTODTOToObj(entity);

            if (entity.Id > 0)
            { 
                 
                _Context.Vacations.Update(model);

                _Context.SaveChanges();
 return entity;


            }
            else
            {


                _Context.Vacations.Add(model);

                _Context.SaveChanges();
                return entity;



            }
        }





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Vacations.Find(id);
            _Context.Vacations.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


        }

        //public IEnumerable<DepartmintDTO> GetAll()
        //{
        //    var model = _Context.Departments.Include(p => p.Employees).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new DepartmintDTO
        //    {
        //        Id = p.Id,
        //        Name = p.DepartmentName,
        //        ManagerId = p.ManagerId,
        //        mangerName = _user.Users.Where(m => m.Id == p.ManagerId).Select(p => p.UserName).FirstOrDefault(),

        //    }).ToList();

        //    return model;
        //}

        public VacarionDTO GetById(int id)
        {
            return _Context.Vacations.Include(p => p.Employee).Where(p => p.Id == id && p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new VacarionDTO
            {
                Id = p.Id,
                 StartDate = p.StartDate,
                 EndDate = p.EndDate,
                  EmployeeId = p.EmployeeId,


            }).FirstOrDefault();
        }

        public IEnumerable<VacarionDTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.Vacations
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.Employee.UserName.ToLower().Contains(searchTerm))
                .Select(p => new VacarionDTO
                {
                    Id = p.Id,
                 EmployeeId= p.EmployeeId,
                     EndDate= p.EndDate,
                        StartDate = p.StartDate,    
                            
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
