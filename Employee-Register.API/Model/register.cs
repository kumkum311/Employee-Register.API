using System.ComponentModel.DataAnnotations;
namespace Employee_Register.API.Model
{
    public class register
    {
        public Guid Id { get; set; }
        [Required]
        public string Name { get; set; }

        [Required]
        public string UserName { get; set; }
        [Required]
        public string DateOfBirth { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Department { get; set; }
        [Required]
        public int Experience { get; set; }
        [Required]
        public string Password { get; set; }


       
    }
}
