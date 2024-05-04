using CollegeAPI.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.DataAccess
{
    public class CollegeDBContext : DbContext
    {
        // Este es el contexto de nuestra DB, el cual extiende del EntityFramework
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options):base(options)
        {

        }

        // TODO: Add DbSets (Tables for the DDBB)
        // Con las lineas siguientes tenemos que decirle a .Net para que agreguen en las vistas las tablas que hemos creado en los modelos
        // Los contextos, son los modelos que podemos ver en la base de datos o son las entidaes que se crean en nuestro DB.
        public DbSet<User>? Users { get; set; } // esto nos permite crear tablas en forma de graficos en la base de datos (views).
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
