using hospitalVm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IREprestory
{
    public interface IRoleS : IPaginationHelper<RoleVM>
    {
        Task<IEnumerable<RoleVM>> GetAllRolesAsync();
        Task<RoleVM> GetRoleByIdAsync(string id);
        //Task<bool> CreateRoleAsync(RoleVM role);
        //Task<bool> UpdateRoleAsync(RoleVM role);
        Task<bool> Save(RoleVM role);
        Task<bool> DeleteRoleAsync(string id);
    }

}
