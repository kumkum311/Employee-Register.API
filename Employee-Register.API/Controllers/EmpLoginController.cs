using Employee_Register.API.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Employee_Register.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmpLoginController : ControllerBase
    {
        private  EmployeeDbContext _employeeDbContext;
        private  IConfiguration configuration;

        public EmpLoginController(EmployeeDbContext employeeDbContext,IConfiguration configuration)
        {
            _employeeDbContext = employeeDbContext;
            this.configuration = configuration;
        }

        [HttpGet]
        public async Task<IActionResult> GetEmpLogin()
        {
            var records = await _employeeDbContext.logins.ToListAsync();
            return Ok(records);
        }

        private string GenerateToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["Jwt:key"]));
            var credential = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);
            var token = new JwtSecurityToken(
               configuration["Jwt:Issuer"],
               configuration["Jwt:Audience"], null,
                expires: DateTime.Now.AddMinutes(20),
                signingCredentials: credential
            );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        [HttpPost]
        public async Task<IActionResult> PostEmpLogin([FromBody]login emp)
        {


            _employeeDbContext.logins.Add(emp);
            await _employeeDbContext.SaveChangesAsync();
            var token = GenerateToken();
                return Ok(new { token = token, user = emp.UserName });

        }


    }
}
