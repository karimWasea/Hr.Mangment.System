using hospitalVm;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReprestoryServess
{

    public class RoleService : PaginationHelper<RoleVM>, IRoleS
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleService(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        public async Task<IEnumerable<RoleVM>> GetAllRolesAsync()
        {
            var roles = _roleManager.Roles.Select(role => new RoleVM
            {
                Id = role.Id,
                Name = role.Name,
            });

            return await Task.FromResult(roles);
        }

        public async Task<RoleVM> GetRoleByIdAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return null;
            }

            var roleVM = new RoleVM
            {
                Id = role.Id,
                Name = role.Name,
            };

            return roleVM;
        }



        public async Task<bool> DeleteRoleAsync(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return false;
            }

            var result = await _roleManager.DeleteAsync(role);

            return result.Succeeded;
        }

        public async Task<bool> Save(RoleVM role)
        {
            if (role == null)
            {
                var newRole = new ApplicationRole
                {
                    Name = role.Name,
                    Rols = role.Rols
                };

                var result = await _roleManager.CreateAsync(newRole);

                return result.Succeeded;

            }
            else
            {
                var existingRole = await _roleManager.FindByIdAsync(role.Id);
                if (existingRole == null)
                {
                    return false;
                }

                existingRole.Name = role.Name;

                var result = await _roleManager.UpdateAsync(existingRole);

                return result.Succeeded;

            }


        }
    }
}
