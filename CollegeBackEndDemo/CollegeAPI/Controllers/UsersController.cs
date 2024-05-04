using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CollegeAPI.DataAccess;
using CollegeAPI.Models.DataModels;

namespace CollegeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly CollegeDBContext _context; // Tener en cuenta que este CollegeDB es el "userRepository" que podemos usar para podemos realizar las operaciones de CRUD.

        public UsersController(CollegeDBContext context)
        {
            _context = context; // inicializamos el repositorio de "UserRepository"
        }

        // GET: https://localhost:7109/api/v1/users
        [HttpGet]
        public async Task<ActionResult<IEnumerable<User>>> GetUsers()
        {
            return await _context.Users.ToListAsync(); // Mostramos toda la lista de los usuarios.
        }

        // GET: https://localhost:7109/api/v1/users/4
        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id); // Buscamos con el metodo "FindAsync(id)" un usuario y si hay devolvemos el usuario sino un NotFount() response.

            if (user == null)
            {
                return NotFound();
            }

            return user;
        }

        // PUT: https://localhost:7109/api/v1/users/
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser (int id, User user)
        {
            if (id != user.Id)
            {
                return BadRequest();
            }

            _context.Entry(user).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync(); // si exise el "ID" de user, modificamos   y guardamos los cambios en DDBB.
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (!UserExists(id))
                {
                    Console.WriteLine("[PUT] Request failed: " + e.Message);
                    return NotFound();
                }
                else
                {
                    throw e;
                }
            }

            return NoContent();
        }

        // POST: https://localhost:7109/api/v1/users
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<User>> CreateUser (User user)
        {
            _context.Users.Add(user);  // Este metodo nos permite crear Users mediante el metodo POST verbo y la misma ruta.
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUser", new { id = user.Id }, user);
        }

        // DELETE: https://localhost:7109/api/v1/users/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id); // Encontramos el User con el ID y si existe eliminamos con el metodo Delete().
            if (user == null)
            {
                return NotFound();
            }

            _context.Users.Remove(user);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool UserExists(int id)
        {
            return _context.Users.Any(e => e.Id == id);
        }
    }
}
