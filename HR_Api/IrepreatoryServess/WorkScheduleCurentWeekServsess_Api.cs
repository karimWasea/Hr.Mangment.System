using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;
using HR_Api.Utellites;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

namespace HR_Api.IrepreatoryServess
{
    public class WorkScheduleCurentWeekServsess_Api: PaginationHelper<WorkScheduleCurentWeekDayDTO> , IWorkScheduleCurentWeekDay_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public WorkScheduleCurentWeekServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public WorkScheduleCurentWeekDayDTO Save(WorkScheduleCurentWeekDayDTO entity)
        {


            var model = WorkScheduleCurentWeekDayDTO.ConvertTODTOToObj(entity);

            if (entity.Id > 0)
            { 
                 
                _Context.workScheduleCurentWeeks.Update(model);

                _Context.SaveChanges();
 return entity;


            }
            else
            {


                _Context.workScheduleCurentWeeks.Add(model);

                _Context.SaveChanges();
                return entity;



            }
        }





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Devices.Find(id);
            _Context.Devices.Remove(deletedmodel);
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

        public WorkScheduleCurentWeekDayDTO GetById(int id)
        {
            return _Context.workScheduleCurentWeeks.Include(p => p.EmployeeWorkScheduleCurentWeekDay).Where(p => p.Id == id && p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new  WorkScheduleCurentWeekDayDTO
            {
                Id = p.Id,
                DayNames = p.DayName,
                  ShiftName = p.ShiftName,
                    TimeEndshifts = p.TimeEndshifts,    
                     TimestartShift = p.TimestartShift


            }).FirstOrDefault();
        }

        public IEnumerable<WorkScheduleCurentWeekDayDTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.workScheduleCurentWeeks
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.DayName.ToString().ToLower().Contains(searchTerm) || // Search by DayName
                    p.ShiftName.ToLower().Contains(searchTerm)) // Search by ShiftName
                .Select(p => new WorkScheduleCurentWeekDayDTO
                {
                    Id = p.Id,
                    DayNames = p.DayName,
                    ShiftName = p.ShiftName,
                    TimestartShift = p.TimestartShift,
                    TimeEndshifts = p.TimeEndshifts
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
