using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Almacen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistema.Web.Controllers.almacen
{
    public class ArticulosController : Controller
    {
        private readonly DbContextSistema _context;

        public ArticulosController(DbContextSistema context)
        {
            _context = context;
        }


        [HttpGet]
        public async Task<ActionResult<IEnumerable<articulo>>> GetArticulo()
        {
            return await _context.Articulos.ToListAsync();
        }

        [HttpGet("{idarticulo}")]
        public async Task<ActionResult<articulo>> GetArticulo(int id)
        {

            var articulo = await _context.Articulos.FindAsync(id);


            if (articulo == null)
            {
                return NotFound();
            }
            return articulo; 
        }


        [HttpPut("idarticulo")]
        public async Task<IActionResult> PutArticulo(int id, articulo articulo)
        {
            if (id != articulo.idarticulo)
            {
                return BadRequest();
            }

            _context.Entry(articulo).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ArticuloExists(id))
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
        public async Task<ActionResult<articulo>> PostArticulo(articulo articulo)
        {
            _context.Articulos.Add(articulo);

            await _context.SaveChangesAsync();

            return CreatedAtAction("Getarticulo", new { id = articulo.idarticulo }, articulo);

        }


        private bool ArticuloExists(int id)
        {
            return _context.Articulos.Any(articulo => articulo.idarticulo == id);
        }
    }
}
