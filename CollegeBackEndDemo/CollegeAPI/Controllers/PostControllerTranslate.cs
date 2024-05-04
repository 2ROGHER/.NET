using CollegeAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Localization;

namespace CollegeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostControllerTranslate : ControllerBase
    {
        // espicificamos el localizador del texto que vamos a traducir
        private readonly IStringLocalizer<PostControllerTranslate> _stringLocalizer;

        // especificar el recurso compartido con las traducciones
        private readonly IStringLocalizer<SharedResources> _sharedResourceLocalizer;

        //luego tenemos que inicializarlo 
        public PostControllerTranslate(IStringLocalizer<PostControllerTranslate> stringLocalizer, IStringLocalizer<SharedResources> sharedResourceLocalizer)
        {
            _stringLocalizer = stringLocalizer;
            _sharedResourceLocalizer = sharedResourceLocalizer;
        }

        [HttpGet]
        [Route("PostControllerResource")]
        public IActionResult GetUsingPostControllerResource()
        {
            // Encontrar el texto
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;
            return Ok(
                    new
                    {
                        PostType = article.Value,
                        PostName = postName
                    }
                );
        }

        [HttpGet]
        [Route("SharedRoute")]
        public IActionResult getUsingSharedResource ()
        {
            // Encontrar el texto
            var article = _stringLocalizer["Article"];
            var postName = _stringLocalizer.GetString("Welcome").Value ?? String.Empty;
            var todayIs = string.Format(_sharedResourceLocalizer.GetString("TodayIs"), DateTime.Now.ToLongDateString());
            return Ok(
                    new
                    {
                        PostType = article.Value,
                        PostName = postName,
                        TodayIs = todayIs,
                    }
                );
        }

    }
}
