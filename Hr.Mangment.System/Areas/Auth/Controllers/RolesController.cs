

using DataAcess.layes;



using hospitalVm;

using Hr.Mangment.System.Areas.HR.Controllers;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using Newtonsoft.Json;

using ReprestoryServess;

using static Microsoft.ApplicationInsights.MetricDimensionNames.TelemetryContext;

namespace Hospital.Areas.Admin.Controllers
{
    [Area("Auth")]
    //[Authorize("Admin")]
    // [Authorize(Roles = clsRoles.roleAdmin)]
    public class RolesController : BaseController
    {
        UserManager<Applicaionuser> _user;
        public RolesController(UnitOfWork unitOfWork, lookupServess lookupServess, UserManager<Applicaionuser> userManager, RoleManager<IdentityRole> roles
) : base(unitOfWork, lookupServess )
        {
            _user = userManager;

            _roles = roles;


        }

        private readonly RoleManager<IdentityRole> _roles;


        public async Task<IActionResult> Index()
        {
            var _users = await _user.Users.ToListAsync();
            return View(_users);
        }

        public async Task<IActionResult> addRoles(string userId)
        {
            var user = await _user.FindByIdAsync(userId);
            var userRoles = await _user.GetRolesAsync(user);

            var allRoles = await _roles.Roles.ToListAsync();
            if (allRoles != null)
            {
                var roleList = allRoles.Select(r => new RoleViewModel()
                {
                    roleId = r.Id,
                    roleName = r.Name,
                    useRole = userRoles.Any(x => x == r.Name)
                });
                ViewBag.userName = user.UserName;
                ViewBag.userId = userId;
                return View(roleList);
            }
            else
                return NotFound();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> addRoles(string userId, string jsonRoles)
        {
            var user = await _user.FindByIdAsync(userId);

            List<RoleViewModel> myRoles =
                JsonConvert.DeserializeObject<List<RoleViewModel>>(jsonRoles);

            if (user != null)
            {
                var userRoles = await _user.GetRolesAsync(user);

                foreach (var role in myRoles)
                {
                    if (userRoles.Any(x => x == role.roleName.Trim()) && !role.useRole)
                    {
                        await _user.RemoveFromRoleAsync(user, role.roleName.Trim());
                        _unitOfWork._context.SaveChanges();
                    }

                    if (!userRoles.Any(x => x == role.roleName.Trim()) && role.useRole)
                    {
                        await _user.AddToRoleAsync(user, role.roleName.Trim());
                        _unitOfWork._context.SaveChanges();

                    }
                }

                return RedirectToAction(nameof(Index));
            }
            else
                return NotFound();
        }
    }
}
