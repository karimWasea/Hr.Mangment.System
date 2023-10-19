
using ReprestoryServess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.Differencing;

using System.Drawing.Printing;
using Hr.Mangment.System.Areas.HR.Controllers;
using hospitalVm;
using Microsoft.AspNetCore.Authorization;

namespace Hospital.Areas.Admin.Controllers
{
    [Area(areaName: "Auth")]
    //<partial name = "_AlertMessage" />
    [Authorize(Roles = "SuperAdmin")]

    public class RoleController : BaseController
    {

        public RoleController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

        }

        public async Task<IActionResult> Index(int? page, string search)
        {
            var roles = await _unitOfWork.roleS.GetAllRolesAsync();



            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                search = search.ToLower(); // Convert the search text to lowercase

                //  Apply search filtering here based on your model properties
                roles = roles.Where(patient =>
                   SearchProperty(patient.Name, search) 
               );
            }

            var pagedPatients = _unitOfWork.roleS.GetPagedData(roles.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

        //  Helper method for case-insensitive search






        private bool SearchProperty(string propertyValue, string search, StringComparison comparison = StringComparison.OrdinalIgnoreCase)
        {
            return !string.IsNullOrWhiteSpace(propertyValue) &&
                   propertyValue.IndexOf(search, comparison) >= 0;
        }
    

        public async Task<IActionResult> Details(string id)
        {
            var role = await _unitOfWork.roleS.GetRoleByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        public async Task<IActionResult> Save(string id)
        {  if(id == null)
            {
                
                return View();


            }
            else
            {

                var roles = await _unitOfWork.roleS.GetRoleByIdAsync(id);

               

                return View(roles);
            }
        }

        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save([FromBody] RoleVM role)
             {
           
                var result = await _unitOfWork.roleS.Save(role);
                if (result)
                {
                    return RedirectToAction("Index");
                }

            return View(role);
        }


        //public async Task<IActionResult> Delete(string id)
        //{
        //    var role = await _unitOfWork.roleS.GetRoleByIdAsync(id);
        //    if (role == null)
        //    {
        //        return NotFound();
        //    }

        //    return RedirectToAction("Index");
        //}

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var result = await _unitOfWork.roleS.DeleteRoleAsync(id);
            if (result)
            {
                return RedirectToAction("Index");
            }
            return RedirectToAction("Delete", new { id });
        }
    }

}
