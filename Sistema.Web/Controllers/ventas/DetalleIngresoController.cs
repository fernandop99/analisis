using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Ventas;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Purchases_Controllers
{

    [Route("api/[controller]")]
    [ApiController]

    public class DetalleIngresoController : Controller
    {
        private readonly DbContextSistema _context;

        public DetalleIngresoController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<detalle_ingreso>>> GetDetalleIngreso()
        {
            return await _context.Detalle_Ingresos.ToListAsync();
        }
        //Get api/para traer solomente un id o una solo detalle
        [HttpGet("{id_detalle_ingreso}")]
        public async Task<ActionResult<detalle_ingreso>> GetDetalleIngreso(int id)
        {
            //variable detIngreso para el findAsync que pedira el id
            var detIngreso = await _context.Detalle_Ingresos.FindAsync(id);
            //si Detalle ingreso retorna vacia

            if (detIngreso == null)
            {
                return NotFound();// aca nos aseguramos que no se llene de spam
            }
            return detIngreso; // si encuentra retorna el valores
        }
        //PUT esta nos sirve para mandar informacion a nuestra API
        //Put api/Detalle Ingreso
        [HttpPut("id_detalle_ingreso")]
        public async Task<IActionResult> PutDetalleIngreso(int id, detalle_ingreso detIngreso)
        {
            if (id != detIngreso.id_detalle_ingreso)
            {
                return BadRequest();// si es diferente no da un badrequest
            }
            _context.Entry(detIngreso).State = EntityState.Modified;/*indicar al dbcontexr con el entity que lo que hay en detalle ingreso 
                                                                     vamos a realizar una modificacion , las entidad ya tiene las propiedades
                                                                       o informacion que vamos a guardar*/

            /*el manejo de erro try nos evitará  tener problemas a evitar que si hay error que la api no falle*/
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)//esto lo que hara un rollback a la operacion que se esta realizando
            {
                if (!DetalleIngresoExists(id))
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
        public async Task<ActionResult<detalle_ingreso>> PostDetalleIngreso(detalle_ingreso detIngreso)
        {
            _context.Detalle_Ingresos.Add(detIngreso);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetDetalleIngreso", new { id = detIngreso.id_detalle_ingreso }, detIngreso);

        }

        private bool DetalleIngresoExists(int id)
        {
            return _context.Detalle_Ingresos.Any(detIngreso => detIngreso.id_detalle_ingreso == id);
        }
    }
}