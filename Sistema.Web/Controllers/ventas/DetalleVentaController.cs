using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Ventas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Sales_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DetalleVentaController : Controller
    {
        private readonly DbContextSistema _context;

        public DetalleVentaController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<detalle_venta>>> GetDetalleVenta()
        {
            return await _context.Detalle_Ventas.ToListAsync();
        }
        [HttpGet("{idDetalleVenta}")]
        public async Task<ActionResult<detalle_venta>> GetDetalleVenta(int id)
        {
            var detVenta = await _context.Detalle_Ventas.FindAsync(id);

            if (detVenta == null)
            {
                return NotFound();
            }
            return detVenta; 
        }

        [HttpPut("idDetalleVenta")]
        public async Task<IActionResult> PutDetalleVenta(int id, detalle_venta detVenta)
        {
            if (id != detVenta.id_detalle_venta)
            {
                return BadRequest();
            }
            _context.Entry(detVenta).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DetalleVentaExists(id))
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
        public async Task<ActionResult<detalle_venta>> PostDetalleVenta(detalle_venta detVenta)
        {
            _context.Detalle_Ventas.Add(detVenta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleVenta", new { id = detVenta.id_detalle_venta }, detVenta);

        }

        private bool DetalleVentaExists(int id)
        {
            return _context.Detalle_Ventas.Any(detVenta => detVenta.id_detalle_venta == id);
        }
    }
}
