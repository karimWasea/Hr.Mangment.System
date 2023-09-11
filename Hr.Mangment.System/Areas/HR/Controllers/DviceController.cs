using DataAcess.layes;

using HR.ViewModel;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using ReprestoryServess;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]

    public class DviceController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
        public DviceController(UnitOfWork unitOfWork, lookupServess lookupServess)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
        }

        public  IActionResult Index(int? page, string search)
        {
            var model =  _unitOfWork.Device.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Employee.SearchProperty(patient.DeviceName, search) 

                // Add more properties for search as needed
                );
            }

            var pagedPatients = _unitOfWork.Device.GetPagedData(model.AsQueryable() ,pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }

    

      


        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id)
        {
            

            if (id >0)
            {
            var model = _unitOfWork.Device.GetById(id);
                //model.Mangers = _lookupServess.EmployeeAll();
                return View(model);
            }
            else
            {
                //vewodel.Mangers= _lookupServess.EmployeeAll();
                return View();
            }
           
        }

        // POST: EmployeeController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( Devicetvm emp1 )
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.Device.Save(emp1);
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
          _unitOfWork.Device.Delete(id);
                return RedirectToAction(nameof(Index));
            
        }
    }
}
