using DataAcess.layes;

using HR_Api.Dtos;
using HR_Api.IrepreatoryServess;

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

using PagedList;



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
        public async Task<ActionResult<IPagedList<AplicatiouserDto>>> GetPaginatedEmployee(int pageNumber = 1)
        {

            // Assuming you have an IQueryable source of products (e.g., _unitOfWork.Product.GetAllAsQueryable())
            var Employee = await _unitofwork.Employee.Search();

            // Use the PaginationHelper to get paginated data
            var Employees = _unitofwork.Employee.GetPagedData(Employee, pageNumber);

            return Ok(Employees);
        }

        [HttpGet("{id :alpha}")]
        public async Task<ActionResult<AplicatiouserDto>> GetEmployeee(string id)
        {

            var product = await _unitofwork.Employee.GetById(id);


            if (product == null)
            {
                return NotFound();
            }



            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult<AplicatiouserDto>> CreateEmployee([FromForm] AplicatiouserDto productCreateDto)
        {









            var existingProduct = _unitofwork.Employee.Save(productCreateDto);
            return CreatedAtAction(nameof(GetEmployeee), new { id = existingProduct.Id }, existingProduct);
        }

        [HttpPut]

        public async Task<ActionResult<AplicatiouserDto>> UpdateGetEmployee([FromForm] AplicatiouserDto updatedProductDto)
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
        public async Task<IActionResult> Search([FromQuery] string searchTerm)
        {

            var departments = _unitofwork.Employee.Search(searchTerm);

            return Ok(departments);
        }
    }



}
//using DataAcess.layes;

//using HR_Api.Dtos;
//using HR_Api.IrepreatoryServess;
//using HR_Api.Utellites;

//using Microsoft.AspNetCore.Identity;
//using Microsoft.AspNetCore.Mvc;

//namespace HR_Api.Controllers
//{
//    [ApiController]
//    [Route("api/[controller]")]
//    public class EmployeeController : ControllerBase
//    {
//        Imgoperation _Imgoperation;

//        private readonly UserManager<Applicaionuser> userManager;
//        private readonly EmployeeServess _employeeService;

//        public EmployeeController(EmployeeServess employeeService, UserManager<Applicaionuser> userManager, Imgoperation _Imgoperation)
//        {
//            this._Imgoperation = _Imgoperation;
//            this.userManager = userManager;
//            _employeeService = employeeService;
//        }

//        [HttpGet]
//        public ActionResult<IEnumerable<AplicatiouserDto>> GetAllEmployees()
//        {
//            //var employees = userMaList<Applicaionuser>?er.Users.ToList();
//            var employees =  _employeeService.GetAll();
//            return Ok(employees);
//        }

//        //[HttpGet("{id}")]
//        //public async Task<ActionResult<AplicatiouserDto>> GetEmployeeById(string id)
//        //{
//        //    //Applicaionuser? employee = userManager.Users.FirstOrDefault(x => x.Id == id);

//        //   var employee= _employeeService.GetById(id);
//        //    if (employee == null)
//        //    {
//        //        return NotFound();
//        //    }
//        //    return Ok(employee);
//        //}

//        //[HttpPost]
//        //public async Task<IActionResult> CreateEmployee([FromBody] AplicatiouserDto entity)
//        //{

//        //    var existingUser = new Applicaionuser();

//        //    existingUser.Id = entity.Id;

//        //    existingUser.Salary = (double?)entity.Salary;
//        //    existingUser.JobTitle = entity.JobTitle;
//        //    existingUser.ContructUrl = _Imgoperation.Uploadimg(entity.contractUrlform);
//        //    existingUser.HirangDate = entity.HirangDate;
//        //    existingUser.Email = entity.Email;
//        //    existingUser.Gender = (SystemEnums.Gender)entity.Gender;
//        //    existingUser.ImgUrl = _Imgoperation.Uploadimg(entity.imgurlform);
//        //    existingUser.PhoneNumber = entity.PhoneNumber;
//        //    existingUser.PasswordHash = entity.PasswordHash;
//        //    existingUser.HirangDate = entity.HirangDate;
//        //    existingUser.Bouns = (double?)entity.Bouns;
//        //    existingUser.BirthDate = entity.BirthDate;
//        //    existingUser.UserName = entity.UserName;
//        //    if (!string.IsNullOrEmpty(entity.PasswordHash)) // Check if the password is provided
//        //    {
//        //        // Hash and set the password
//        //        var passwordHasher = new PasswordHasher<Applicaionuser>();
//        //        existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, entity.PasswordHash);
//        //    }

//        //    var createResult = await userManager.CreateAsync(existingUser, existingUser.PasswordHash); // Use newUser.PasswordHash instead





//        //    return CreatedAtAction(nameof(GetEmployeeById), new { id = existingUser.Id }, existingUser);
//        //}

//        //[HttpPut("{id}")]
//        //public async Task<IActionResult> UpdateEmployee([FromBody] AplicatiouserDto entity)
//        //{



//        //    var existingUser = await userManager.FindByIdAsync(entity.Id);


//        //    // Update properties of existingUser
//        //    existingUser.Id = entity.Id;

//        //    existingUser.Salary = (double?)entity.Salary;
//        //    existingUser.JobTitle = entity.JobTitle;
//        //    existingUser.ContructUrl = _Imgoperation.Uploadimg(entity.contractUrlform);
//        //    existingUser.HirangDate = entity.HirangDate;
//        //    existingUser.Email = entity.Email;
//        //    existingUser.Gender = (SystemEnums.Gender)entity.Gender;
//        //    existingUser.ImgUrl = _Imgoperation.Uploadimg(entity.imgurlform);
//        //    existingUser.PhoneNumber = entity.PhoneNumber;
//        //    existingUser.PasswordHash = entity.PasswordHash;
//        //    existingUser.HirangDate = entity.HirangDate;
//        //    existingUser.Bouns = (double?)entity.Bouns;
//        //    existingUser.BirthDate = entity.BirthDate;
//        //    existingUser.UserName = entity.UserName;

//        //    if (!string.IsNullOrEmpty(entity.PasswordHash)) // Check if the password is provided
//        //    {
//        //        // Hash and update the password
//        //        var passwordHasher = new PasswordHasher<Applicaionuser>();
//        //        existingUser.PasswordHash = passwordHasher.HashPassword(existingUser, entity.PasswordHash);
//        //    }

//        //    var updateResult = await userManager.UpdateAsync(existingUser);

//        //    ////userManager.UpdateAsync(employee);
//        //    //await _employeeService.Save(employee);
//        //    return CreatedAtAction(nameof(GetEmployeeById), new { id = existingUser.Id }, existingUser);


//        //}
//        //[HttpDelete("{id}")]
//        //public async Task<IActionResult> DeleteEmployee(string Id)
//        //{
//        //    var existingUser = await userManager.FindByIdAsync(Id);

//        //    var success = await userManager.DeleteAsync(existingUser);

//        //    return NoContent();
//        //}

//        //[HttpGet("search")]
//        //public async Task<IActionResult> SearchEmployees([FromQuery] string searchTerm)
//        //{
//        //    searchTerm = searchTerm?.Trim().ToLower(); // Convert searchTerm to lowercase

//        //    var employees = await userManager.Users
//        //        .Where(p =>
//        //            string.IsNullOrWhiteSpace(searchTerm) || // Return all items if searchTerm is empty
//        //            p.UserName.ToLower().Contains(searchTerm))
//        //        .Select(p => new AplicatiouserDto
//        //        {
//        //            Id = p.Id,
//        //            UserName = p.UserName,
//        //        })
//        //        .ToListAsync();

//        //    return Ok(employees);
//        //}

//    }
//}


