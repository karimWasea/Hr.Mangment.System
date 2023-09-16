using DataAcess.layes;

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
    public class CurentWeakController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public CurentWeakController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<WorkScheduleCurentWeekDayDTO>> GetPaginatedWorkScheduleCurentWeekDay(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork. WorkScheduleCurentWeekDay.Search(  );

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.WorkScheduleCurentWeekDay.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<WorkScheduleCurentWeekDay> GetWorkScheduleCurentWeekDay(int id)
        {

            var product = _unitofwork.WorkScheduleCurentWeekDay.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<WorkScheduleCurentWeekDayDTO> CreateWorkScheduleCurentWeekDay([FromForm] WorkScheduleCurentWeekDayDTO productCreateDto)
        {









            var existingProduct = _unitofwork.WorkScheduleCurentWeekDay.Save(productCreateDto);
            return CreatedAtAction(nameof(GetWorkScheduleCurentWeekDay), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<WorkScheduleCurentWeekDayDTO> UpdateProduct( [FromForm] WorkScheduleCurentWeekDayDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.WorkScheduleCurentWeekDay.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeletecurentDaywork(int id)
        {

            _unitofwork.WorkScheduleCurentWeekDay.Delete(id);
            return NoContent();
        }


        [HttpGet("Search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
          
         var departments=  _unitofwork.WorkScheduleCurentWeekDay.Search(searchTerm);

            return Ok(departments);
        }
    }



}
