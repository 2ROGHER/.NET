using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public class UserLogin
    {
        // este es a manera de DTO para le login del user
        [Required]
        public string UserName { get; set; }
        [Required]

        public string Password { get; set; }
    }
}
