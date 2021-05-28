using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Informacion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class MunicipioController : Controller
    {
        private readonly DbContextSistema _context;

        public MunicipioController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Municipio>>> GetMunicipio()
        {
            return await _context.Municipios.ToListAsync();
        }

        [HttpGet("{Id_Municipio}")]
        public async Task<ActionResult<Municipio>> GetMunicipio(int id)
        {
            var municipio = await _context
                .Municipios.FindAsync(id);

            if (municipio == null)
            {
                return NotFound();
            }
            return municipio; 
        }

        [HttpPut("Id_Municipio")]
        public async Task<IActionResult> PutMunicipio(int id, Municipio municipio)
        {
            if (id != municipio.Id_Municipio)
            {
                return BadRequest();
            }

            _context.Entry(municipio)
                .State = EntityState.Modified;
            try
            {
                await _context
                    .SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MunicipioExists(id))
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
        public async Task<ActionResult<Municipio>> PostMunicipio(Municipio municipio)
        {
            _context.Municipios
                .Add(municipio);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetMunicipio", new { id = municipio.Id_Municipio }, municipio);
        }

       

        private bool MunicipioExists(int id)
        {
            return _context.Municipios
                .Any(municipio => municipio.Id_Municipio == id);
        }
    }
}
