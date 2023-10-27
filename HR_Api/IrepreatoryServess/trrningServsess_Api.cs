using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.Irepreatory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System.Runtime.InteropServices;


namespace HR_Api.IrepreatoryServess
{
    public class trrningServsess_Api : PaginationHelper<TrainingDTOAdd>, ITrining_Api
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
    
        public trrningServsess_Api(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {

            _user = user;
            _Context = db;
        }
        public Training Add(TrainingDTOAdd entity)
        {
            var model = TrainingDTOAdd.ConvertTODTOToObj(entity);

            var ADDentity = _Context.Trainings.Add(model);

            _Context.SaveChanges();
            return ADDentity.Entity;
        }

        public Training Update(TrainingDTOUppdate entity)
        {
            var model = TrainingDTOUppdate.ConvertTODTOToObj(entity);

            var UPdated = _Context.Trainings.Update(model);


            _Context.SaveChanges();
            return UPdated.Entity;
        }
       





        public bool Delete(int id)
        {

             

            var deletedmodel = _Context.Trainings.Find(id);
            _Context.Trainings.Remove(deletedmodel);
            _Context.SaveChanges();
            return true;


        }

    

        public TrainingDTOUppdate GetById(int id)
        {
            return _Context.Trainings.Where(p => p.Id == id && p.IsDeleted == SystemEnums.IsDeleted.NotDeleted).Select(p => new TrainingDTOUppdate
            {
                Id = p.Id,
                TrainingName = p.TrainingName,


            }).FirstOrDefault();
        }

        public IEnumerable<TrainingDTOUppdate> Search(string searchTerm = default)
        {
            searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

            return _Context.Trainings
                .Where(p =>
                    string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
                    p.TrainingName.ToLower().Contains(searchTerm))
                .Select(p => new TrainingDTOUppdate
                {
                    Id = p.Id,
                    TrainingName = p.TrainingName,
                })
                .ToList();
        }






    }
}
