using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace HR_Api.IrepreatoryServess
{
    public class DepatmentServsess_Api : PaginationHelper<DepartmintDTO>, IDeparment_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public DepatmentServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public DepartmintDTO Save(DepartmintDTO entity)
        {


            var model = DepartmintDTO.ConvertTODTOToObj(entity);

            if (entity.Id > 0)
            { 
                 
                _Context.Departments.Update(model);

                _Context.SaveChanges();
 return entity;


            }
            else
            {


                _Context.Departments.Add(model);

                _Context.SaveChanges();
                return entity;



            }
        }





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Departments.Find(id);
            _Context.Departments.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


        }

        public IEnumerable<DepartmintDTO> GetAll()
        {
            var model = _Context.Departments.Include(p => p.Employees).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new DepartmintDTO
            {
                Id = p.Id,
                Name = p.DepartmentName,
                ManagerId = p.ManagerId,
                mangerName = _user.Users.Where(m => m.Id == p.ManagerId).Select(p => p.UserName).FirstOrDefault(),

            }).ToList();

            return model;
        }

        public DepartmintDTO GetById(int id)
        {
            return _Context.Departments.Include(p => p.Employees).Where(p => p.Id == id && p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new DepartmintDTO
            {
                Id = p.Id,
                Name = p.DepartmentName,
                ManagerId = p.ManagerId,
                mangerName = _user.Users.Where(m => m.Id == p.ManagerId).Select(p => p.UserName).FirstOrDefault(),


            }).FirstOrDefault();
        }

        public IEnumerable<DepartmintDTO> Search(string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return _Context.Departments
                .Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted &&
                            (string.IsNullOrWhiteSpace(searchTerm) ||
                             p.DepartmentName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase) ||
                             _user.Users.Any(u => u.Id == p.ManagerId || u.UserName.Contains(searchTerm, StringComparison.OrdinalIgnoreCase))))
                .Select(p => new DepartmintDTO
                {
                    Id = p.Id,
                    Name = p.DepartmentName,
                    ManagerId = p.ManagerId,
                    mangerName = _user.Users
                        .Where(m => m.Id == p.ManagerId)
                        .Select(m => m.UserName)
                        .FirstOrDefault(),
                })
                .ToList();
            }
            return null;
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
