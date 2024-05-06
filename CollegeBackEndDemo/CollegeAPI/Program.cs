

// 1. Usings to work with EntityFramework ORM
using Microsoft.EntityFrameworkCore;
using CollegeAPI.DataAccess;
using CollegeAPI.services;
using CollegeAPI;
using Microsoft.OpenApi.Models;

// Tenemos que traer las opciones de Versionado
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ApiExplorer;

// 19. usar Serilog para incluirlo en uestro app
using Serilog;


var builder = WebApplication.CreateBuilder(args);

// 20. Configuraicon de Serilog
builder.Host.UseSerilog((HostBuilderCtx, loggerConf) =>
{
    loggerConf
        .WriteTo.Console()
        .WriteTo.Debug()
        .ReadFrom.Configuration(HostBuilderCtx.Configuration);
});
// 10. Agregar la localizacion de la aplicacion
// Localizacion
builder.Services.AddLocalization(options => options.ResourcesPath = "Resources");


// 13. tenemos que usar las peticiiones http, para ello necesitamos agregar la inyeccion de dependecinas.
// Add httpclient para ealizar las peticciones (requests) http
builder.Services.AddHttpClient(); // este paso es importante para las peticciones http.

// 14. Ahora tenemos que agregar la gestion de control de versiones.
builder.Services.AddApiVersioning(setup =>
{
    setup.DefaultApiVersion = new ApiVersion(1, 0); // 1.0 _ version
    setup.AssumeDefaultVersionWhenUnspecified = true;
    setup.ReportApiVersions = true;

});

// 15. Ahora tenemos que especificar como queremos documentar las versiones.
builder.Services.AddVersionedApiExplorer(setup =>
{
    setup.GroupNameFormat = "v'VVV'";  // 1.0.0, 1.1.0, etc
    setup.SubstituteApiVersionInUrl = true; // queremos que se agregue la version en la URL.
});




// Add services to the container.
// 2. Connection with SQL Server Express
const string CONNECTIONNAME = "CollegeDB";
var connectionString = builder.Configuration.GetConnectionString(CONNECTIONNAME);

// 3. Add Context to this project
builder.Services.AddDbContext<CollegeDBContext>(options => options.UseSqlServer(connectionString));


// 7. Add service of JWT authentication | autoritatiion
builder.Services.AddJwtTokenServices(builder.Configuration); // cuando quereamo aniadir la informacion de nuestro token tenemos que agregar el servicio.


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


// 16. Configurar las optiones de generacion de Swagger.
builder.Services.ConfigureOptions<ConfigureSwaggerOptions>();


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


// 17. Configurar los endpoints para swagger docs pafa cada una de las versiones gestinados.
var apiVersionDescriptionProvider = app.Services.GetRequiredService<IApiVersionDescriptionProvider>();


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
    // 18. Configure Swagger Docs que se van a generar.
    app.UseSwaggerUI(options =>
    {
        foreach(var description in apiVersionDescriptionProvider.ApiVersionDescriptions)
        {
            options.SwaggerEndpoint(
                    $"/swagger/{description.GroupName}/swagger.json",
                    description.GroupName.ToUpperInvariant()
                ) ;
        }
    });

}

//21. Tenemos que decirle a la aplicaion que use Serilog y la configuracion ehcha.
app.UseSerilogRequestLogging();

app.UseHttpsRedirection(); // Redirections

app.UseAuthorization(); // Auth opeartions

app.MapControllers();

// 6. Decir a nuetra aplicacion haga uso del CORS configurations
// Tell app to use cors configurations.
app.UseCors("CorsPolicy"); // uso de cors para la aplicacion.
 
app.Run(); // Run application
