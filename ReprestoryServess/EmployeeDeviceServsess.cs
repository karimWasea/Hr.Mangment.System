

namespace ReprestoryServess
{
    public class EmployeeDeviceServsess : PaginationHelper<EmployeeDeviceVm>,IEmployeeDevice
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public EmployeeDeviceServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(EmployeeDeviceVm entity)
        {
            foreach (var selectedid in entity.selectDeviceids)
            {
                 entity.Deviceid = selectedid;
                var model = EmployeeDeviceVm.CanconvertViewmodel(entity);
            

        

                if (entity.Id > 0)
                {
                _Context.EmployeeDevices.Update(model);

                _Context.SaveChanges();


                  }
                else
                 {


                _Context.EmployeeDevices.Add(model);

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

        public IEnumerable<EmployeeDeviceVm> GetAll()
        {
            return _Context.EmployeeDevices.Include(p=>p.Employee). Where( p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeDeviceVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
 Deviceid=p.DeviceId,

            }).ToList().OrderBy(b=>b.EmployeeName);    

        }

        public IEnumerable<EmployeeDeviceVm> GetAllShiftByemployeeId( string id )
        {
            return _Context.EmployeeDevices.Include(p => p.Employee).Include(p=>p.Device).Where(p => p.IsDeleted == SystemEnums.IsDeleted.NotDeleted && p.EmployeeId==id).Select(p => new EmployeeDeviceVm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
                EmployeeId = p.EmployeeId,
                EmployeeName = p.Employee.UserName,
                Deviceid = (int)p.DeviceId,
                 Name =p.Device.DeviceName,

            }).ToList().OrderBy(b => b.EmployeeName);

        }









        public EmployeeDeviceVm GetById(int id)
        {
            return _Context.EmployeeDevices.Include(p=>p.Device).Include(p=>p.Employee).Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new EmployeeDeviceVm
            {
 isDeleted = p.IsDeleted,
                Id = p.Id,
 EmployeeId= p.EmployeeId,
  EmployeeName=p.Employee.UserName,
    Deviceid= (int)p.DeviceId,
    Name= p.Device.DeviceName,

             
            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
