using DataAcess.layes;
using HR.ViewModel;

using Intersoft.Crosslight.Mobile;

using IREprestory;

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprestoryServess
{
    public class TriningServsess : PaginationHelper<Trainingvm>,ITrining
    {
        private readonly UserManager<Applicaionuser> _user;

        private ApplicationDBcontext _Context;
        public TriningServsess(ApplicationDBcontext db, UserManager<Applicaionuser> user)
        {  

            _user = user;
            _Context = db;
        }
        public void Save(Trainingvm entity)
        {


            var model = Trainingvm.CanconvertViewmodel(entity);

            if (entity.Id > 0)
            {
                _Context.Trainings.Update(model);

                _Context.SaveChanges();


            }
            else
            {


                _Context.Trainings.Add(model);

                _Context.SaveChanges();


            }
        }





        public void Delete(int id)
        {

            

         var deletedmodel=   GetById(id);
            deletedmodel.isDeleted = SystemEnums.IsDeleted.Deleted;
            Save(deletedmodel);



        }

        public IEnumerable<Trainingvm> GetAll()
        {
            var model= _Context.Trainings.Where(p=> p.IsDeleted != SystemEnums.IsDeleted.Deleted).Select(p => new Trainingvm
            {
                Id = p.Id,
              isDeleted=p.IsDeleted,
               TrainingName = p.TrainingName,
                

            }).ToList();

            return model;
        }

        public Trainingvm GetById(int id)
        {
            var model = _Context.Trainings.Where(p => p.IsDeleted != SystemEnums.IsDeleted.Deleted && p.Id== id).Select(p => new Trainingvm
            {
                Id = p.Id,
                isDeleted = p.IsDeleted,
                TrainingName = p.TrainingName,


            }).FirstOrDefault();

            return model;
        }


















       public  bool SearchProperty(string propertyValue, string search, StringComparison comparison)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                               propertyValue.Contains(search, comparison);
        }



    }
}
