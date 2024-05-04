using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public class User : BaseEntity
    {
        [Required, StringLength(50)]
        public string Name { get; set; } = string.Empty;

        [Required, StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [Required, EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;

        // tenemos que crear un tipo de model para que haga match con la validacion de tokens 

    }
}
