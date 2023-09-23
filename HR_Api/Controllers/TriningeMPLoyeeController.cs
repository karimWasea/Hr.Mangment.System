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
    public class TriningeMPLoyeeController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public TriningeMPLoyeeController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList< EmployeeTriningDTO>> GetPaginatedEmployeeTrining(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.TriningEmpoyee.GetAll();

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.TriningEmpoyee.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<EmployeeTriningDTO> GetEmployeeTrining(int id)
        {

            var product = _unitofwork.TriningEmpoyee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<EmployeeTriningDTO> CreateEmployeeTrining([FromForm]  EmployeeTriningDTO productCreateDto)
        {









            var existingProduct = _unitofwork.TriningEmpoyee.Save(productCreateDto);
            return CreatedAtAction(nameof(GetEmployeeTrining), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<EmployeeTriningDTO> UpdateDeviceEmployee(int id, [FromForm] EmployeeTriningDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.TriningEmpoyee.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDeviceEmployee(int id)
        {

            _unitofwork.TriningEmpoyee.Delete(id);
            return NoContent();
        }


        [HttpGet("GEtallforthiemployee")]
        public IActionResult GEtallforthiemployee([FromQuery] string employeeid)
        {
          
         var departments=  _unitofwork.TriningEmpoyee.EmployeeTRining(employeeid);

            return Ok(departments);
        }
    }



}
