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
    public class RolController : Controller
    {
        private readonly DbContextSistema _context;

        public RolController(DbContextSistema context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<Rol>>> GetRol()
        {
            return await _context
                .Rols.ToListAsync();
        }


        [HttpGet("{idrol}")]
        public async Task<ActionResult<Rol>> GetRol(int id)
        {
            var rol = await _context.Rols.FindAsync(id);

            if (rol == null)
            {
                return NotFound();
            }
            return rol;
        }



        [HttpPut("idrol")]
        public async Task<IActionResult> PutRol(int id, Rol rol)
        {
            if (id != rol.idrol)
            {
                return BadRequest();
            }
            _context.Entry(rol).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RolExists(id))
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
        public async Task<ActionResult<Rol>> PostRol(Rol rol)
        {
            _context.Rols.Add(rol);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRol", new { id = rol.idrol }, rol);

        }



        private bool RolExists(int id)
        {
            return _context
                .Rols.Any(rol => rol.idrol == id);
        }

    }
}
