using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

using static HR_Api.Dtos.VacarionDTOAdd;

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
       



        public Department Add(DepartmintDTOAdd entity)
        {
            var model = DepartmintDTOAdd.ConvertTODTOToObj(entity);

            var ADDentity = _Context.Departments.Add(model);

            _Context.SaveChanges();
            return ADDentity.Entity;
        }

        public Department Update(DepartmintDTO entity)
        {
            var model = DepartmintDTO.ConvertTODTOToObj(entity);

            var UPdated = _Context.Departments.Update(model);


            _Context.SaveChanges();
            return UPdated.Entity;
        }


        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Departments.Find(id);
            _Context.Departments.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


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

        public IEnumerable<DepartmintDTO> Search(string searchTerm=default)
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


       


    }
    }
