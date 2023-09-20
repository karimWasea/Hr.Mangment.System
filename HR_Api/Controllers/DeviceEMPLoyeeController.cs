using HR_Api.Dtos;
using HR_Api.IrepreatoryServess;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PagedList;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace HR_Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DeviceEMPLoyeeController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public DeviceEMPLoyeeController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<EmployeedeviceDTO>> GetPaginatedemployeeDevice(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.deviceEmpoyee.GetAll();

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.deviceEmpoyee.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeedeviceDTO> GetDeviceEmployee(int id)
        {

            var product = _unitofwork.deviceEmpoyee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<EmployeedeviceDTO> CreateDeviceEmployee([FromForm] EmployeedeviceDTO productCreateDto)
        {









            var existingProduct = _unitofwork.deviceEmpoyee.Save(productCreateDto);
            return CreatedAtAction(nameof(GetDeviceEmployee), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeedeviceDTO> UpdateDeviceEmployee(int id, [FromForm] EmployeedeviceDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.deviceEmpoyee.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeviceEmployee(int id)
        {

            _unitofwork.deviceEmpoyee.Delete(id);
            return NoContent();
        }


        [HttpGet("GEtallforthiemployee")]
        public IActionResult GEtallforthiemployee([FromQuery] string employeeid)
        {
          
         var departments=  _unitofwork.deviceEmpoyee.Employeedevicess(employeeid);

            return Ok(departments);
        }
    }



}
