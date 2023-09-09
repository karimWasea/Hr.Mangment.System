

namespace ReprestoryServess
{
    public class DeviceServsess : PaginationHelper<Devicetvm>,IDevice
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public DeviceServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(Devicetvm entity)
        {


            var model = Devicetvm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.Devices.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.Devices.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<Devicetvm> GetAll()
        {
            return _Context.Devices.Where( p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new Devicetvm
            {
                isDeleted = p.IsDeleted,
                Id = p.Id,
                DeviceName = p.DeviceName,


            }).ToList();    

        }

        public Devicetvm GetById(int id)
        {
            return _Context.Devices.Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new Devicetvm
            {
                isDeleted = p.IsDeleted, 
 Id = p.Id,
 DeviceName =p.DeviceName,
  
             
            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
