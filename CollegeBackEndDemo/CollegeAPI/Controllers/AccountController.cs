using CollegeAPI.DataAccess;
using CollegeAPI.helpers;
using CollegeAPI.Models;
using CollegeAPI.Models.DataModels;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CollegeAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly JwtSettings _jwtSettings;
        private readonly CollegeDBContext _context;

        public AccountController(JwtSettings jwtSettings, CollegeDBContext context)
        {
            _jwtSettings = jwtSettings;
            _context = context;
        }

        // TODO: Cambiar por los usuarios reales de al base de datos o que estan en la ase de datos.
        private IEnumerable<User> _logins = new List<User>()
        {
            new User()
            {
                Id = 1,
                Email = "user1@user1.com",
                Name = "Admin",
                Password = "Admin"
            },
            new User()
            {
                Id = 2,
                Email = "user2@user2.com",
                Name = "User 1",
                Password = "User 1"
            }
        };


        // tenemos que especiificar una ruta de tipo POST
        [HttpPost]
        public IActionResult GetToken(UserLogin userLogin)
        {
            try
            {
                var token = new UserTokens();

                // Buscar un Usuario en el contexto mediante consultas LinQ
                var searchUser = (from user in _context.Users // hacemos una consulta a la base de datos.
                                  where user.Name.Equals(userLogin.UserName) && user.Password == userLogin.Password
                                  select user).FirstOrDefault(); // devolvermos todo los datos del primer usuario de la lista.

                Console.WriteLine(searchUser);

                // Ahora esto quedaria obselto con la busqeuda de lineas arriba.
                //var valid = _logins.Any(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
     

                // si es valido el usuario generamosel token 
                if (searchUser != null)
                {
                    //var user = _logins.FirstOrDefault(user => user.Name.Equals(userLogin.UserName, StringComparison.OrdinalIgnoreCase));
                    // ahora con el contexto podemos buscar un usuario 
                    // var user = await _context.Users.FindAsync(userLogin.UserName);

                    // generamos el token
                    token = JwtHelpers.GeneateTokenKey(new UserTokens()
                    {
                        UserName = searchUser.Name,
                        EmailId = searchUser.Email,
                        Id = searchUser.Id,
                        GuidId = Guid.NewGuid(),
                    }, _jwtSettings);
                } else
                {
                    // si el usuario no exite en la lista de usuarios devolvemos un error.
                    return BadRequest("Wrong Password");
                }
                return Ok(token);
            } catch(Exception e)
            {
                throw new Exception("Error al generar el token: " + e.Message);
            }
        }


        // Con esto le dicimo que permite el acceso a las rutas a los usuarios con el "rol" de "Administrator"
        [HttpGet]
        [Authorize (AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme, Roles = "Administrator")] // eto espera el esquema de autorizacion, y el dara acceso a solo adminstradores.
        public IActionResult GetUserList()
        {
            return Ok(_logins); // return all list of users.
        }

    }
}
