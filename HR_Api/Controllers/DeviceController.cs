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
    public class DeviceController : ControllerBase
    {
        private readonly Unitofwork _unitofwork;

        public DeviceController(Unitofwork unitofwork)
        {
            _unitofwork = unitofwork;
        }
        [HttpGet]
        public ActionResult<IPagedList<DevicDTO>> GetPaginatedDevice(int pageNumber = 1  )
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
           var  products = _unitofwork.Device.Search(  );

            // Use the PaginationHelper to get paginated data
            var pagedProducts = _unitofwork.Device.GetPagedData(products, pageNumber);

            return Ok(pagedProducts);
        }

        [HttpGet("{id}")]
        public ActionResult<DevicDTO> GetDevice(int id)
        {

            var product = _unitofwork.Device.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public ActionResult<DevicDTO> CreateDepartment([FromForm] DevicDTO productCreateDto)
        {









            var existingProduct = _unitofwork.Device.Save(productCreateDto);
            return CreatedAtAction(nameof(GetDevice), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut("{id}")]
        public ActionResult<DevicDTO> UpdateProduct(int id, [FromForm] DevicDTO updatedProductDto)
        {


            var existingProduct = _unitofwork.Device.Save(updatedProductDto);
            return Ok(existingProduct);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteDevice(int id)
        {

            _unitofwork.Device.Delete(id);
            return NoContent();
        }


        [HttpGet("search")]
        public IActionResult Search([FromQuery] string searchTerm)
        {
          
         var departments=  _unitofwork.Device.Search(searchTerm);

            return Ok(departments);
        }
    }



}
