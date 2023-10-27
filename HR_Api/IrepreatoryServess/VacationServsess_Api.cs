using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;
using System.Security.Principal;

using static HR_Api.Dtos.VacarionDTOAdd;

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
                    p.EmployeeId.ToLower().Contains(searchTerm) || // Search by EmployeeId
                    (p.StartDate != null && p.StartDate.ToString().ToLower().Contains(searchTerm)) || // Search by StartDate
                    (p.EndDate != null && p.EndDate.ToString().ToLower().Contains(searchTerm))) // Search by EndDate
                .Select(p => new VacarionDTO
                {
                    Id = p.Id,
                    EmployeeId = p.EmployeeId,
                    StartDate = p.StartDate,
                    EndDate = p.EndDate
                })
                .ToList();
        }

        public Vacation Add(VacarionDTOAdd entity)
        {
            var model = VacarionDTOAdd.ConvertTODTOToObj(entity);

         var ADDentity=   _Context.Vacations.Add(model);

            _Context.SaveChanges();
            return ADDentity.Entity;
        }

        public Vacation Update(VacarionDTO entity)
        {
            var model = VacarionDTO.ConvertTODTOToObj(entity);

        var UPdated=    _Context.Vacations.Update(model);


            _Context.SaveChanges();
            return UPdated.Entity;
        }
    }
}
