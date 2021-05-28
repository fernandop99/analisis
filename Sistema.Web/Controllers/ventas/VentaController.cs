using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Ventas;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Sales_Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VentasController : Controller
    {

        private readonly DbContextSistema _context;

        public VentasController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<venta>>> GetVenta()
        {
            return await _context.Ventas.ToListAsync();
        }
        [HttpGet("{idventa}")]
        public async Task<ActionResult<venta>> GetVenta(int id)
        {
            var venta = await _context.Ventas.FindAsync(id);

            if (venta == null)
            {
                return NotFound();
            }
            return venta; 
        }

        [HttpPut("idventa")]
        public async Task<IActionResult> PutVenta(int id, venta venta)
        {
            if (id != venta.idventa)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(venta).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en venta 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!VentaExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;// por si desconocemos el error
                }

            }
            return NoContent();
        }

        //POST api/venta
        [HttpPost]
        public async Task<ActionResult<venta>> PostVenta(venta venta)
        {
            _context.Ventas.Add(venta);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetVenta", new { id = venta.idventa }, venta);

        }

       
        private bool VentaExists(int id)
        {
            return _context.Ventas.Any(venta => venta.idventa == id);
        }
    }
}
