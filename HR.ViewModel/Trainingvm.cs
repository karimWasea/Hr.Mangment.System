using DataAcess.layes;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace HR.ViewModel
{
    public class Trainingvm : BaseViewModel
    {
        public string TrainingName { get; set; }

        public IEnumerable<SelectListItem> Mangers { get; set; } = Enumerable.Empty<SelectListItem>();

        public static Training CanconvertViewmodel(Trainingvm entity)
        {
            var dept = new Training() {
             Id = entity.Id,
              TrainingName = entity.TrainingName,
IsDeleted= entity.isDeleted,                
            
            
            
            };


            return dept;
        }
    }
}