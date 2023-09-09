using Microsoft.AspNetCore.Mvc.Rendering;

namespace IREprestory
{
    public interface Ilookup
    {
        IQueryable<SelectListItem> Selectallshiofts();

        IQueryable<SelectListItem> EmployeeAll();
        IQueryable<SelectListItem> DepartmitAll();
        public List<SelectListItem> GEnder();
        public List<SelectListItem> GetAlltransaction();


    }
}