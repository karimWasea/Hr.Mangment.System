using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;

namespace HR_Api.IrepreatoryServess
{
    public class DeviceEmployyServsess_Api : PaginationHelper<EmployeedeviceDTO>, IDeviceEmpoyee_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public DeviceEmployyServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public EmployeedeviceDTO Save(EmployeedeviceDTO entity)
        {



            foreach (var selectedid in entity.devicids)
            {
                entity.devicid = selectedid;
                var model = EmployeedeviceDTO.CanconvertViewmodel(entity);




                if (entity.Id > 0)
                {
                    _Context.EmployeeDevices.Update(model);

   
             

                }
                else
                {


                    _Context.EmployeeDevices.Add(model);

         
             


                }

                _Context.SaveChanges();

            }

            return entity;
        }





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.EmployeeDevices.Find(id);
            _Context.EmployeeDevices.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


        }

        public IEnumerable<EmployeedeviceDTO> GetAll()
        {
            return _Context.EmployeeDevices.Include(p => p.Device).Include(p => p.Employee)
                .Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted)
                .Select(p => new EmployeedeviceDTO
                {
                    Id = p.Id,
                    Employeeid = p.EmployeeId,
                    devicids = _Context.Devices.Where(i => i.Id == p.DeviceId).Select(i => i.Id).ToList()
                })
               .ToList();
           
        }

        public EmployeedeviceDTO GetById(int id)
        {
            return _Context.EmployeeDevices.Include(p=>p.Device).Include(p=>p.Employee)
                .Where(p => p.Id == id )
                .Select(p => new EmployeedeviceDTO
                {
                    Id = p.Id,
                    Employeeid = p.EmployeeId,
                    devicids = _Context.Devices.Where(i => i.Id == p.DeviceId).Select(i => i.Id).ToList()
                })
                .FirstOrDefault();
        }


        public IEnumerable<EmployeedeviceDTO> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.EmployeeDevices
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.EmployeeId.ToLower().Contains(searchTerm))
                .Select(p => new EmployeedeviceDTO
                {
                    Id = p.Id,
                })
                .ToList();
        }

        public IEnumerable<EmployeedeviceDTO> Employeedevicess(string str = null)
        {
            return _Context.EmployeeDevices.Include(p => p.Device).Include(p => p.Employee)
                    .Where(p =>p.EmployeeId== str)
                    .Select(p => new EmployeedeviceDTO
                    {
                        Id = p.Id,
                        Employeeid = p.EmployeeId,
                        devicids = _Context.Devices.Where(i => i.Id == p.DeviceId).Select(i => i.Id).ToList()
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
