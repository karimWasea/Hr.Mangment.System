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
    public class DepartmentController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public DepartmentController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<DepartmintDTO>> GetPaginatedProducts(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
            IEnumerable<DepartmintDTO>? products = _unitofwork.Deparment.GetAll();

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.Deparment.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<DepartmintDTO> GetDepartment(int id)
        {

            var product = _unitofwork.Deparment.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<DepartmintDTO> CreateDepartment([FromForm] DepartmintDTO productCreateDto)
        {









            var existingProduct = _unitofwork.Deparment.Save(productCreateDto);
            return CreatedAtAction(nameof(GetDepartment), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<DepartmintDTO> UpdateProduct(int id, [FromForm] DepartmintDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.Deparment.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDepartment(int id)
        {

            _unitofwork.Deparment.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm))
            {
                return BadRequest("Search term cannot be empty.");
            }

         var departments=  _unitofwork.Deparment.Search(searchTerm);

            return Ok(departments);
        }
    }



}
