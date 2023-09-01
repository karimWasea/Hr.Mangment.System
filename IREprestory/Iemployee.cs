using HR.ViewModel;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface Iemployee : IPaginationHelper<EmployeeVM>
    {

        Task<bool> Delete(string id);
        // PagedREsult<DoctorVm> Getallpag(int pagnumber, int pagesize);
        Task<EmployeeVM> GetById(string id);
        //Task<EmployeeVM> GetByIdasconfirmed(string id);

        //Task<IEnumerable<EmployeeVM>> GetallconfirmedDoctor();
        bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase);

        Task Save(EmployeeVM entity);
        IEnumerable<EmployeeVM> GetAll();





    }
    }
