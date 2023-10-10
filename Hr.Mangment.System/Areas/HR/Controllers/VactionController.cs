using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

using System.Globalization;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    //[Authorize]

    public class VactionController : BaseController
    {
        UserManager<Applicaionuser> _userManager;
        public VactionController(UnitOfWork unitOfWork, lookupServess lookupServess, UserManager<Applicaionuser> userManager
) : base(unitOfWork, lookupServess)
        {
            _userManager = userManager;



        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Vaction.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                //model = model.Where(patient =>
                //     _unitOfWork.Vaction.SearchProperty(patient.EmployeeName, search)

                //// Add more properties for search as needed
                //);
            }

            var pagedPatients = _unitOfWork.Vaction.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }



        public async Task<IActionResult> addvaction(string id)
        {

            var model = _unitOfWork.Vaction.GETVATIONEMPOYEEID(id);


            return View(model);  
        }
        public async Task<IActionResult> Editebyempid(string id)
        {

            var model =  new VactionVm();
            model.EmployeeId = id;
            model.EmployeeName= _userManager.Users.Where(i=>i.Id == id).Select(p=>p.UserName).FirstOrDefault(); 
            return View(model);
        }


        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {
         

            if (id >0)
            {
                var  model = _unitOfWork. Vaction.GetById(id);
                model.Employes = _lookupServess.EmployeeAll();
                //model.Shifts = _lookupServess.GetallShifts();
             
                return View(model);
            }
            else
            {
                var vewodel = new VactionVm();
                vewodel.Employes= _lookupServess.EmployeeAll();
                ////vewodel.Shifts = _lookupServess.GetallShifts();
        
                return View(vewodel);
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(   VactionVm emp1 )
        {
            emp1.Employes = _lookupServess.EmployeeAll();

            if (ModelState.IsValid)
            {
                _unitOfWork.Vaction.Save(emp1);
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
        public IActionResult Delete(int  id)
        {
          _unitOfWork.Vaction.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
