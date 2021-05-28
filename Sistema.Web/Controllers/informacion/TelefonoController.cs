using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Informacion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class TelefonoController : Controller
    {
        private readonly DbContextSistema _context;

        public TelefonoController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Telefono>>> GetTelefono()
        {
            return await _context.Telefonos.ToListAsync();
        }

        [HttpGet("{Id_Telefono}")]
        public async Task<ActionResult<Telefono>> GetTelefono(int id)
        {
            var telefono = await _context.Telefonos.FindAsync(id);

            if (telefono == null)
            {
                return NotFound();
            }
            return telefono; 
        }


        [HttpPut("Id_Telefono")]
        public async Task<IActionResult> PutTelefono(int id, Telefono telefono)
        {
            if (id != telefono.Id_Telefono)
            {
                return BadRequest();
            }

            _context.Entry(telefono).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!TelefonoExists(id))
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
        public async Task<ActionResult<Telefono>> PostTelefono(Telefono telefono)
        {
            _context.Telefonos.Add(telefono);

            await _context.SaveChangesAsync();

            return CreatedAtAction
                ("GetTelefono", new { id = telefono.Id_Telefono }, telefono);
        }

       

        private bool TelefonoExists(int id)
        {
            return _context.Telefonos.Any(telefono => telefono.Id_Telefono == id);
        }
    }
}
