using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public class Chapter : BaseEntity
    {
        [Required]
        public int CourseId { get; set; } // y esta es el Id de dicho Course por el cual se esta asociando.
        [Required]
        public virtual Course Course { get; set; } = new Course(); // con esto asociamos un Course con un Chapter de 1:1
        [Required]
        public string Chapters { get; set;  }

    }
}
