using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

namespace HR_Api.IrepreatoryServess
{
    public class trrningServsess_Api : PaginationHelper<TrainingDTO>, ITrining_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public trrningServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public TrainingDTO Save(TrainingDTO entity)
        {


            var model = TrainingDTO.ConvertTODTOToObj(entity);

            if (entity.Id > 0)
            { 
                 
                _Context.Trainings.Update(model);

                _Context.SaveChanges();
 return entity;


            }
            else
            {


                _Context.Trainings.Add(model);

                _Context.SaveChanges();
                return entity;



            }
        }





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Trainings.Find(id);
            _Context.Trainings.Remove(deletedmodel);
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

        public TrainingDTO GetById(int id)
        {
            return _Context.Trainings.Where(p => p.Id == id && p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new TrainingDTO
            {
                Id = p.Id,
                Name = p.TrainingName,


            }).FirstOrDefault();
        }

        public IEnumerable<TrainingDTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.Trainings
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.TrainingName.ToLower().Contains(searchTerm))
                .Select(p => new TrainingDTO
                {
                    Id = p.Id,
                    Name = p.TrainingName,
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
