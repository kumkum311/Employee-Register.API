using System.ComponentModel.DataAnnotations;

namespace Employee_Register.API.Model
{
    public class login
    {
       
            public Guid Id { get; set; }
            [Required]
            public string UserName { get; set; }
            [Required]
            public string Password { get; set; }
        
    }
}
