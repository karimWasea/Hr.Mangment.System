using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class WorkScheduleCurentWeekDayController : BaseController
    {
       



          public WorkScheduleCurentWeekDayController(UnitOfWork unitOfWork, lookupServess lookupServess) : base(unitOfWork, lookupServess)
        {

        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.workScheduleCurentWeekDay.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Deparment.SearchProperty(patient.ShiftName, search)

                 //Add more properties for search as needed
                ) ;
            }

            var pagedPatients = _unitOfWork.workScheduleCurentWeekDay.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

      


        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {
            

            if (id >0)
            {
                var  model = _unitOfWork.workScheduleCurentWeekDay.GetById(id);
                model.DayNameslist = _lookupServess.GetWeekdaySelectList();
                return View(model);
            }
            else
            {
                var vewodel = new WorkScheduleCurentWeekDayVm();
                vewodel.DayNameslist = _lookupServess.GetWeekdaySelectList();
                return View(vewodel);
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save(WorkScheduleCurentWeekDayVm emp1 )
        {
        //    if (ModelState.IsValid)
        //    {
                _unitOfWork.workScheduleCurentWeekDay.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(Index));
            //}
            //return View(emp1);


        }

        // GET: EmployeeController/Delete/5
     

        // POST: EmployeeController/Delete/5
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        public IActionResult Delete(int   id)
        {
          _unitOfWork.workScheduleCurentWeekDay.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
