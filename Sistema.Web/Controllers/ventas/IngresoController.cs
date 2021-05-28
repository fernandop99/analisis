using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Ventas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Purchases_Controllers
{
    public class IngresoController : Controller
    {
        private readonly DbContextSistema _context;

        public IngresoController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ingreso>>> GetIngreso()
        {
            return await _context.Ingresos.ToListAsync();
        }
        [HttpGet("{idIngreso}")]
        public async Task<ActionResult<ingreso>> GetIngreso(int id)
        {
            var ingreso = await _context.Ingresos.FindAsync(id);

            if (ingreso == null)
            {
                return NotFound();
            }
            return ingreso; 
        }

        [HttpPut("idIngreso")]
        public async Task<IActionResult> PutIngreso(int id, ingreso ingreso)
        {
            if (id != ingreso.idingreso)
            {
                return BadRequest();
            }
            _context.Entry(ingreso).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!IngresoExists(id))
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
        public async Task<ActionResult<ingreso>> PostIngreso(ingreso ingreso)
        {
            _context.Ingresos.Add(ingreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetIngreso", new { id = ingreso.idingreso }, ingreso);

        }

       
        private bool IngresoExists(int id)
        {
            return _context.Ingresos.Any(ingreso => ingreso.idingreso == id);
        }
    }
}
