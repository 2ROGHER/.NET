using System.ComponentModel.DataAnnotations;

namespace CollegeAPI.Models.DataModels
{
    public class BaseEntity
    {
        // Esta es la clase que nos va a permitir especificar todos los campos
        // que se van a crear atraves  del ORM espeificar a SQL, como debe crear los campos de las tablas.

        // Estos son los campos que van a tener todo las entidades, en la base de datos.
        [Required]
        [Key]
        public int Id { get; set; }
        public int UserId { get; set;  }
        //public virtual User CreatedBy { get; set; } = new User(); // esto nos dice quien lo ha creado y mas datos.
        //public User UpdateBy { get; set; } = new User();
        public string CreatedBy { get; set;  } = string.Empty;
        public string UpdatedBy { get; set; } = string.Empty;
        public DateTime CreatedOn { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; }
        //public User DeletedBy { get; set; } = new User();
        public string DeletedBy { get; set; } = string.Empty;
        public DateTime DeletedAt { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
