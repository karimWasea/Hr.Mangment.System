using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

using System.Globalization;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    //[Authorize]


    public class TimeShiftController : BaseController
    {
       

        public TimeShiftController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

        }

        public IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.timeShift.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                     _unitOfWork.Employee.SearchProperty(patient.EmployeeName, search)

                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.timeShift.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

      


        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {
         

            if (id >0)
            {
                var  model = _unitOfWork. timeShift.GetById(id);
                model.Employes = _lookupServess.EmployeeAll();
                model.Shifts = _lookupServess.GetallShifts();
             
                return View(model);
            }
            else
            {
                var vewodel = new TimeShiftVM();
                vewodel.Employes= _lookupServess.EmployeeAll();
                vewodel.Shifts = _lookupServess.GetallShifts();
        
                return View(vewodel);
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(   TimeShiftVM emp1 )
        {
            //if (ModelState.IsValid)
            //{
                _unitOfWork.timeShift.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            //}
            //  return View(emp1); 

            
        }

        // GET: EmployeeController/Delete/5
     

        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int  id)
        {
          _unitOfWork.timeShift.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
