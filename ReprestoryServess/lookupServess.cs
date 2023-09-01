using DataAcess.layes;
using IREprestory;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.Rendering;

using SystemEnums;

namespace ReprestoryServess
{
    public class lookupServess :Ilookup
    {
        private readonly ApplicationDBcontext _applicationDBcontext;
        private readonly UserManager<Applicaionuser> _user;


        public lookupServess(UserManager<Applicaionuser> userManager, ApplicationDBcontext applicationDBcontext)
        {
            _applicationDBcontext = applicationDBcontext;
            _user = userManager;



        }
        public List<SelectListItem> GetWeekdaySelectList()
        {
            var weekdays = Enum.GetValues(typeof(DayOfWeek))
                               .Cast<DayOfWeek>()
                               .Select(d => new SelectListItem
                               {
                                   Value = ((int)d).ToString(),
                                   Text = d.ToString()
                               })
                               .ToList();

            return weekdays;
        }


        public List<SelectListItem> GEnder()
        {
            var weekdays = Enum.GetValues(typeof(Gender))
                               .Cast<Gender>()
                               .Select(d => new SelectListItem
                               {
                                   Value = ((int)d).ToString(),
                                   Text = d.ToString()
                               })
                               .ToList();

            return weekdays;
        }



        public IQueryable<SelectListItem>EmployeeAll()
        {

            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Employees.Select(x => new SelectListItem { Value = x.Id, Text = x.UserName });
            return applicationuser;
        }

        public IQueryable<SelectListItem> DepartmitAll()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.DepartmentName });
            return applicationuser;
        }
    }
}