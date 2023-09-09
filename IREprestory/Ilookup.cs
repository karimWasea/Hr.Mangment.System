using Microsoft.AspNetCore.Mvc.Rendering;

namespace IREprestory
{
    public interface Ilookup
    {
        IQueryable<SelectListItem> Selectallshiofts();
        
        IQueryable<SelectListItem> AllTrinng();
        IQueryable<SelectListItem> AllDevicess();
        IQueryable<SelectListItem> EmployeeAll();
        IQueryable<SelectListItem> DepartmitAll();
         List<SelectListItem> GEnder();
         List<SelectListItem> GetAlltransaction();


    }
}