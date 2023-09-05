using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class TringingController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public TringingController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Trining.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Trining.SearchProperty(patient.TrainingName, search) 

                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.Deparment.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

      


        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {
            

            if (id >0)
            {
              var model = _unitOfWork.Trining.GetById(id);
                model.Mangers = _lookupServess.EmployeeAll();
                return View(model);
            }
            else
            {
               
                return View();
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( Trainingvm emp1 )
        {
            //if (ModelState.IsValid)
            //{
                _unitOfWork.Trining.Save(emp1);
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
          _unitOfWork.Trining.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
