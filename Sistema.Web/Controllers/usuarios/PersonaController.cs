using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Usuarios;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Persons_Controllers
{
    public class PersonaController : Controller
    {
        private readonly DbContextSistema _context;

        public PersonaController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<persona>>> GetPersona()
        {
            return await _context
                .Personas.ToListAsync();
        }

        [HttpGet("{idpersona}")]
        public async Task<ActionResult<persona>> GetPersona(int id)
        {
            var persona = await _context
                .Personas.FindAsync(id);

            if (persona == null)
            {
                return NotFound();
            }
            return persona; 
        }

        [HttpPut("idpersona")]
        public async Task<IActionResult> PutPersona(int id, persona persona)
        {
            if (id != persona.idpersona)
            {
                return BadRequest();
            }

            _context.Entry(persona)
                .State = EntityState.Modified;
            try
            {
                await _context
                    .SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonaExists(id))
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
        public async Task<ActionResult<persona>> PostPersona(persona persona)
        {
            _context.Personas
                .Add(persona);

            await _context
                .SaveChangesAsync();

            return CreatedAtAction
                ("GetPersona", new { id = persona.idpersona }, persona);
        }

        private bool PersonaExists(int id)
        {
            return _context.Personas
                .Any(persona => persona.idpersona == id);
        }
    }
}
