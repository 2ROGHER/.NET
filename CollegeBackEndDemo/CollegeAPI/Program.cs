

// 1. Usings to work with EntityFramework ORM
using Microsoft.EntityFrameworkCore;
using CollegeAPI.DataAccess;
using CollegeAPI.services;
using CollegeAPI;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// 10. Agregar la localizacion de la aplicacion
// Localizacion
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");



// Add services to the container.
// 2. Connection with SQL Server Express
const string CONNECTIONNAME = "CollegeDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to this project
builder.Services.AddDbContext<CollegeDBContext>(options => options.UseSqlServer(connectionString));


// 7. Add service of JWT authentication | autoritatiion
builder.Services.AddJsonTokenService(options.) // cuando quereamo aniadir la informacion de nuestro token tenemos que agregar el servicio.


// Build the configurations and other else more.
// Add Services to the main container 
builder.Services.AddControllers();

// 4. Add Custom Folder Services 
builder.Services.AddScoped<IStudentService, StudentService>(); // tenemos que indicar la interfaz y la clase que lo implementa.


// 9. Agreagar una politica de autorizacion a nuestra aplicacion | las politica sse pueden extender a mas
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("UserPolicy", policy =>
    {
        policy.RequireClaim("UserOnly", "User 1");
    });
});


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

// 8. Configuracion del Swagger para que tenga en cuenta del autorization.
builder.Services.AddSwaggerGen(options =>
{
    // definimos la seguridad de la app
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "JWT Authorization header using Bearer Scheme",
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string [] {}
        }
    });
});



// 5. Habilitar el CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "CorsPolicy", builder =>
    {
        builder.AllowAnyOrigin(); // cualquier origen
        builder.AllowAnyMethod(); // cualquier metodo
        builder.AllowAnyHeader(); // cualquiere header
    });
});

var app = builder.Build();


// 11. ADd SUpportted culturas agregar el soporte de culturas a la API
var supportedCultures = new[] { "en-US", "es-ES", "fr-FR" };

// agregar las opciones de locallizacion
var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
    .AddSupportedCultures(supportedCultures) // a partir de este momento esta aplicacion soporta por defecto el "ingles"
    .AddSupportedCultures(supportedCultures)
    .AddSupportedUICultures(supportedCultures);


// 12. Agregar la localizacion a la aplicacion
app.UseRequestLocalization(localizationOptions);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection(); // Redirections

app.UseAuthorization(); // Auth opeartions

app.MapControllers();

// 6. Decir a nuetra aplicacion haga uso del CORS configurations
// Tell app to use cors configurations.
app.UseCors("CorsPolicy"); // uso de cors para la aplicacion.
 
app.Run(); // Run application
