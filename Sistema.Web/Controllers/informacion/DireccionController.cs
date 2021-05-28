using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Informacion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class DireccionController : Controller
    {
        private readonly DbContextSistema _context;

        public DireccionController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Direccion>>> GetDireccion()
        {
            return await _context
                .Direccions.ToListAsync();
        }

        [HttpGet("{Id_Direccion}")]
        public async Task<ActionResult<Direccion>> GetDireccion(int id)
        {
            var direccion = await _context
                .Direccions.FindAsync(id);

            if (direccion == null)
            {
                return NotFound();
            }
            return direccion; 
        }


        [HttpPut("Id_Direccion")]
        public async Task<IActionResult> PutDireccion(int id, Direccion direccion)
        {
            if (id != direccion.Id_Direccion)
            {
                return BadRequest();
            }

            _context.Entry(direccion)
                .State = EntityState.Modified;

            try
            {
                await _context
                    .SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DireccionExists(id))
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
        public async Task<ActionResult<Direccion>> PostDireccion(Direccion direccion)
        {
            _context.Direccions
                .Add(direccion);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetDireccion", new { id = direccion.Id_Direccion }, direccion);
        }

       

        private bool DireccionExists(int id)
        {
            return _context.Direccions
                .Any(direccion => direccion.Id_Direccion == id);
        }
    }
}
