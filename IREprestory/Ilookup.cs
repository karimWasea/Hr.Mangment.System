using Microsoft.AspNetCore.Mvc.Rendering;

namespace IREprestory
{
    public interface Ilookup
    {
        IQueryable<SelectListItem> EmployeeAll();
        IQueryable<SelectListItem> DepartmitAll();
        public List<SelectListItem> GEnder();


    }
}