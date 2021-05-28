using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Users_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : Controller
    {

        private readonly DbContextSistema _context;

        public UsuarioController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<usuario>>> GetUsuario()
        {
            return await _context.Usuarios.ToListAsync();
        }
        [HttpGet("{idUsuario}")]
        public async Task<ActionResult<usuario>> GetUsuario(int id)
        {
            var usuario = await _context.Usuarios.FindAsync(id);

            if (usuario == null)
            {
                return NotFound();
            }
            return usuario; 
        }

        [HttpPut("idUsuario")]
        public async Task<IActionResult> PutUsuario(int id, usuario usuario)
        {
            if (id != usuario.id_usuario)
            {
                return BadRequest();
            }
            _context.Entry(usuario).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!UsuarioExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }

            }
            return NoContent();
        }

        [HttpPost]
        public async Task<ActionResult<usuario>> PostUsuario(usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetUsuario", new { id = usuario.id_usuario }, usuario);

        }

        
        private bool UsuarioExists(int id)
        {
            return _context.Usuarios.Any(usuario => usuario.id_usuario == id);
        }
    }
}
