using DataAcess.layes;
using IREprestory;
using Microsoft.AspNetCore.Identity;

using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

using System.ComponentModel;

using SystemEnums;

namespace ReprestoryServess
{
    public class lookupServess : Ilookup
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
        public List<SelectListItem> GetAlltransaction()
        {
            var weekdays = Enum.GetValues(typeof(TransactionSalaryType))
                               .Cast<TransactionSalaryType>()
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
        public List<SelectListItem> GetallShifts()
        {
            var shiftList = Enum.GetValues(typeof(ShiftStuTework))
                .Cast<ShiftStuTework>()
                .Select(shift =>
                {
                    var description = shift.GetDescription(); // Get the description from the enum
                    return new SelectListItem
                    {
                        Value = ((int)shift).ToString(),
                        Text = description
                    };
                })
                .ToList();

            return shiftList;
        }


      


        public IQueryable<SelectListItem>EmployeeAll()
        {

            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Users.Select(x => new SelectListItem { Value = x.Id, Text = x.UserName }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
       
        public IQueryable<SelectListItem> DepartmitAll()
        {
            IQueryable<SelectListItem>? applicationuser = _applicationDBcontext.Departments.Select(x => new SelectListItem { Value = x.Id.ToString(), Text = x.DepartmentName }).OrderBy(c => c.Text).AsNoTracking();
            return applicationuser;
        }
    }














     
}