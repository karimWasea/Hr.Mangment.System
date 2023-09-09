

namespace ReprestoryServess
{
    public class WorkScheduleCurentWeekDayServsess : PaginationHelper<WorkScheduleCurentWeekDayVm>,IWorkScheduleCurentWeekDay
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public WorkScheduleCurentWeekDayServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(WorkScheduleCurentWeekDayVm entity)
        {
            

            var model = WorkScheduleCurentWeekDayVm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.workScheduleCurentWeeks.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.workScheduleCurentWeeks.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<WorkScheduleCurentWeekDayVm> GetAll()
        {
            return _Context.  workScheduleCurentWeeks.Where( p=> p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new WorkScheduleCurentWeekDayVm
            {
                Id = p.Id,
                 TimestartShift = (DateTime)p.TimestartShift,
                  ShiftName = p.ShiftName,
                   DayName = p.DayName,
                    TimeEndshifts = (DateTime)p.TimeEndshifts
                    
                      


            }).ToList();    

        }

        public WorkScheduleCurentWeekDayVm GetById(int id)
        {
            return _Context.workScheduleCurentWeeks.Where(p => p.Id == id &&p.IsDeleted==IsDeleted.NotDeleted).Select(p => new WorkScheduleCurentWeekDayVm
            {
                Id = p.Id,
                TimestartShift = (DateTime)p.TimestartShift,
                ShiftName = p.ShiftName,
                DayName = p.DayName,
                TimeEndshifts = (DateTime)p.TimeEndshifts

            }).FirstOrDefault();
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
