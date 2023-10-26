using DataAcess.layes;

using HR.Utailites;
using HR.ViewModel;

using IREprestory;

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

using ReprestoryServess;

using System.Collections.Generic;

namespace Hr.Mangment.System.Areas.HR.Controllers
{
    [Area("HR")]
    [Authorize(Roles = SystemRols.SuperAdmin)]


    public class EmployeeDeviceController : Controller
    {
        UnitOfWork _unitOfWork;
        lookupServess _lookupServess;
       // EmployeeDeviceVm vewodel;

        public EmployeeDeviceController(UnitOfWork unitOfWork, lookupServess lookupServess )//EmployeeDeviceVm vewodel)
        {
            _unitOfWork = unitOfWork;
            _lookupServess = lookupServess;
            //this.vewodel = vewodel;
        }

        public IActionResult Index(int? page, string search)
        {
            var model = _unitOfWork.employeeDevice.GetAll();
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Deparment.SearchProperty(patient.EmployeeName, search)

                //Add more properties for search as needed
                );
            }
















            var pagedPatients = _unitOfWork.employeeDevice.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }


        public IActionResult GetAllAssinedDevice(int? page, string search, string Emplyeeid)
        {
            var model = _unitOfWork.employeeDevice.GetAllShiftByemployeeId(Emplyeeid);
            int pageNumber = page ?? 1;

            if (!string.IsNullOrWhiteSpace(search))
            {
                // Apply search filtering here based on your model properties
                model = model.Where(patient =>
                  _unitOfWork.Deparment.SearchProperty(patient.EmployeeName, search)

                //Add more properties for search as needed
                );
            }



            var pagedPatients = _unitOfWork.employeeDevice.GetPagedData(model.AsQueryable(), pageNumber);

            ViewBag.Search = search;

            return View(pagedPatients);
        }




        // GET: EmployeeController/Edit/5
        public async Task<IActionResult> Save(int id, string Emplyeeid, string EmplyeeName)
        {


            if (id >  0)
            {
             var model = _unitOfWork.employeeDevice.GetById(id);
                model.DisplayDeviceid = _lookupServess.AllDevicess();
                return View(model);
            }
            else
            {
                EmployeeDeviceVm vewodel = new EmployeeDeviceVm();  
                vewodel.DisplayDeviceid = _lookupServess.AllDevicess();

                vewodel.EmployeeName = EmplyeeName;
                vewodel.EmployeeId = Emplyeeid;
                return View(vewodel);
            }

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Save( EmployeeDeviceVm emp1)
        {
            if (ModelState.IsValid)
            {
                _unitOfWork.employeeDevice.Save(emp1);
                TempData["Message"] = $" successfully!";
                TempData["MessageType"] = "Save";
                return RedirectToAction(nameof(GetAllAssinedDevice), new
                {
                    page = (int?)null,
                    search =
                                                 (string)null,
                    Employeeid = emp1.EmployeeId
                });
            }
            return View(emp1);


        }

      

        public IActionResult Delete(int id)
        {
          var  employeeid =_unitOfWork.employeeWorkScheduleCurentWeek.GetById(id).EmployeeId;
            _unitOfWork.employeeWorkScheduleCurentWeek.Delete(id);
            TempData["Message"] = $" Deleted!";
            TempData["MessageType"] = "Delete";
            return RedirectToAction(nameof(GetAllAssinedDevice), new
            {
                page = (int?)null,
                search =
                               (string)null,
                Employeeid = employeeid
            });
        }
    }
        //[HttpPost]


        //public IActionResult ADDrengeofshifts(IEnumerable<EmployeeWorkScheduleCurentWeekDayVm> employeeWorkScheduleCurentWeekDayVms)
        //{
        //     foreach(var  emp in employeeWorkScheduleCurentWeekDayVms)
        //    {

        //        _unitOfWork.employeeWorkScheduleCurentWeek.Save(emp);
        //    }


        //        return RedirectToAction(nameof(Gtbyemployeeid));

        //}
        /////}
        ///
    }

