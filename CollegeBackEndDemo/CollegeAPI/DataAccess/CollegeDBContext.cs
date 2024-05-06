using CollegeAPI.Models.DataModels;
using Microsoft.EntityFrameworkCore;

namespace CollegeAPI.DataAccess
{
    public class CollegeDBContext : DbContext
    {
        private readonly ILoggerFactory _loggerFactory;

        // Este es el contexto de nuestra DB, el cual extiende del EntityFramework
        public CollegeDBContext(DbContextOptions<CollegeDBContext> options, ILoggerFactory loggerFactory):base(options)
        {
            _loggerFactory = loggerFactory;
        }

        // TODO: Add DbSets (Tables for the DDBB)
        // Con las lineas siguientes tenemos que decirle a .Net para que agreguen en las vistas las tablas que hemos creado en los modelos
        // Los contextos, son los modelos que podemos ver en la base de datos o son las entidaes que se crean en nuestro DB.
        public DbSet<User>? Users { get; set; } // esto nos permite crear tablas en forma de graficos en la base de datos (views).
        public DbSet<Course>? Courses { get; set; }
        public DbSet<Category>? Categories { get; set; }

        public DbSet<Chapter> Chapters { get; set; }
        public DbSet<Student> Students { get; set; }
        
        // cad avez que se realalice el proceso de crear, borrar, insertar estara registrado en la base de datos.
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var logger = _loggerFactory.CreateLogger<CollegeDBContext>();
            // optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }));
            //optionsBuilder.EnableSensitiveDataLogging();     
            // Poro si queremos leer deuna base de datos no seria recomendable dado que nos mostria dsdo informacion y no es recomendable

            optionsBuilder.LogTo(d => logger.Log(LogLevel.Information, d, new[] { DbLoggerCategory.Database.Name }), LogLevel.Information)
                .EnableSensitiveDataLogging() // agrega los datos si o si
                .EnableDetailedErrors(); // y solo minifique ne lo maximo los tipos de errores.
        }
    }
}
