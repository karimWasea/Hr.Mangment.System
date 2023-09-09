

namespace ReprestoryServess
{
    public class DepatmentServsess : PaginationHelper<Depatmentvm>,IDeparment
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public DepatmentServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(Depatmentvm entity)
        {


            var model = Depatmentvm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.Departments.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.Departments.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<Depatmentvm> GetAll()
        {
            var model= _Context.Departments.Include(p => p.Employees).Where(p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new Depatmentvm
            {
                Id = p.Id,
                DepartmentName = p.DepartmentName,
                ManagerId = p.ManagerId,
                MangerName = _user.Users.Where(m => m.Id == p.ManagerId).Select(p => p.UserName).FirstOrDefault(),

            }).ToList();

            return model;
        }

        public Depatmentvm GetById(int id)
        {
            return _Context.Departments.Include(p=>p.Employees).Where(p => p.Id == id &&p.IsDeleted==SystemEnums.IsDeleted.NotDeleted).Select(p => new Depatmentvm
            {
                isDeleted = p.IsDeleted, 
 Id = p.Id,
  DepartmentName    = p.DepartmentName,
  ManagerId=p.ManagerId,
  MangerName =_user.Users.Where(m=>m.Id==p.ManagerId).Select(p=>p.UserName).FirstOrDefault(),

             
            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
