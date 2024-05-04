using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public class Student : BaseEntity
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string LastName { get; set; } = string.Empty;
        [Required]
        public DateTime DBO { get; set; }
        [Required]
        public ICollection<Course> Courses { get; set; } = new List<Course>();

    }
}
