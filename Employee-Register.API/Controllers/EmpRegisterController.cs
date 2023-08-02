using Employee_Register.API.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Employee_Register.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("default")]
    //[Authorize]
    public class EmpRegisterController : ControllerBase
    {
        private readonly EmployeeDbContext _employeeDbContext;

        public EmpRegisterController(EmployeeDbContext employeeDbContext)
        {
            _employeeDbContext = employeeDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpRegister()
        {
            var records = await _employeeDbContext.registers.ToListAsync();
            return Ok(records);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmpRegister(register records)
        {
            _employeeDbContext.registers.Add(records);
            await _employeeDbContext.SaveChangesAsync();
            return Ok();
        }
    }
}
