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
    public class EmployeeController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public EmployeeController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public async  Task< ActionResult<IPagedList<EmployeeDTO>>> GetPaginatedEmployee(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var Employee = await _unitofwork.Employee.Search(  );

            // Use the PaginationHelper to get paginated data
            var Employees = _unitofwork.Employee.GetPagedData(Employee, pageNumber);

            return Ok(Employees);
        }

        [HttpGet("{id:alpha}", Name = nameof(GetEmployeee))]
        public ActionResult<EmployeeDTO> GetEmployeee(string id)
        {

            var product = _unitofwork.Employee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<EmployeeDTO> CreateEmployee([FromForm] EmployeeDTO productCreateDto)
        {









            var existingProduct = _unitofwork.Employee.Save(productCreateDto);
            return CreatedAtAction(nameof(GetEmployeee), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut]

        public ActionResult<EmployeeDTO> UpdateGetEmployee( [FromForm] EmployeeDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.Employee.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id :alpha}")]

        public IActionResult DeleteEmployee(string id)
        {

            _unitofwork.Employee.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
          
         var departments=  _unitofwork.Employee.Search(searchTerm);

            return Ok(departments);
        }
    }



}
