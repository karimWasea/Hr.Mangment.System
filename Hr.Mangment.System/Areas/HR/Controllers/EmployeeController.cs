using DataAcess.layes;

using HR.ViewModel;

using Intersoft.Crosslight;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
        [Authorize(Roles = "SuperAdmin")]

    public class EmployeeController : BaseController
    {
        EmployeeVM modelemp;
        public EmployeeController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {
            modelemp=new EmployeeVM();
        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Employee.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Employee.SearchProperty(patient.Email, search) ||
                     _unitOfWork.Employee.SearchProperty(patient.UserName, search) ||
                     _unitOfWork.Employee.SearchProperty(patient.Adress, search)                 // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.Employee.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

        // GET: EmployeeController/Details/5
        public async Task<IActionResult> Details(string Id)
        {
            var model = await _unitOfWork.Employee.GetById(Id);
            return View(model);
        }



        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(string id)
        {
           
            //if (id !=null)
            //{
                var model = await _unitOfWork.Employee.GetById(id);
                model.listGender = _lookupServess.GEnder();
                model.alldept = _lookupServess.DepartmitAll();
                return View(model);
            //}
            //else
            //{
            //    modelemp.listGender = _lookupServess.GEnder();
            //    modelemp.alldept = _lookupServess.DepartmitAll();
            //    return View(modelemp);
            //}
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( EmployeeVM emp1 )
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Employee.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            }
            return View(emp1);


        }

        // GET: EmployeeController/Delete/5
     

        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(string id)
        {
          _unitOfWork.Employee.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
