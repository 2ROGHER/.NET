using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using Swashbuckle.AspNetCore.Swagger;

namespace CollegeAPI
{
    public class ConfigureSwaggerOptions : IConfigureNamedOptions<SwaggerOptions>

    {
        // esta clase ontendra las configuraciones de Swagger para la gestion de las versiones de la aplicacion.
        // Esta clase podria estar en unmodulo de utils, config.

        private readonly IApiVersionDescriptionProvider _provider;

        // inicializamos en el construtcor
        public ConfigureSwaggerOptions(IApiVersionDescriptionProvider provider)
        {
           this._provider = provider;
        }

        // generate funciton swagger
        public OpenApiInfo CreateVersionInfo(ApiVersionDescription description)
        {
            // este metodo documenta la aplicaion con swagger de forma directa.
            var info = new OpenApiInfo
            {
                Title = "My .Net api restful",
                Version = description.ApiVersion.ToString(),
                Description = "This is my first API versioning control",
                Contact = new OpenApiContact()
                {
                    Email = "due@due.com",
                    Name = "John Due",
                }

            };
            // en caso este deprecated mi api tenemos que agreagar un descripcion para informar al cliente
            if (description.IsDeprecated)
            {
                info.Description += "This API version has been deprecated";
            }
            return info;
        }

        public void Configure(string? name, SwaggerOptions options)
        {
            // Add Swagger documentation para cada una de las versines de nuestra aplicacion.
            foreach(var description in _provider.ApiVersionDescriptions)
            {
                options.SwaggerDoc(description.GroupName, CreateVersionInfo(description));
            }
        }

        public void Configure(SwaggerOptions options)
        {
            // aqui tenemos que llamar la segunda options
            Configure(options);
        }
    }
}
