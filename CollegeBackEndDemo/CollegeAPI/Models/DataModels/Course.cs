using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public enum Level
    {
        Basic, 
        Medium,
        Advanced,
        Expert
    }

    public class Course : BaseEntity
    {
        [Required, StringLength(20)]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; } = string.Empty;
        [Required]
        public string Description { get; set; } = string.Empty;
        public Level Level { get; set; } = Level.Basic;
        [Required, StringLength(180)]
        public string ShorDescription { get; set; } = string.Empty;
        [Required]
        public ICollection<Category> Categories { get; set; } = new List<Category>(); // aqui estamos especificando que nuestra entidad "course" tiene muchas "categorias" o una lista de entidade "categorias".
        [Required]
        public Chapter Chapter { get; set; } = new Chapter(); // Con esto le estamos diciendo que existen una relacion de 1:1 entre el Index y el Student entities.

    }
}
