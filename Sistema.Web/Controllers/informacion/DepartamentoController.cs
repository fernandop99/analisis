using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Informacion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class DepartamentoController : Controller
    {
        private readonly DbContextSistema _context;

        public DepartamentoController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Departamento>>> GetDepartamento()
        {
            return await _context.Departamentos.ToListAsync();
        }

        [HttpGet("{idDepatamento}")]
        public async Task<ActionResult<Departamento>> GetDepartamento(int id)
        {
            var departamento = await _context.Departamentos.FindAsync(id);

            if (departamento == null)
            {
                return NotFound();
            }
            return departamento; 
        }

        [HttpPut("idDepartamento")]
        public async Task<IActionResult> PutDepartamento(int id, Departamento departamento)
        {
            if (id != departamento.Id_Depatamento)
            {
                return BadRequest();
            }

            _context.Entry(departamento)
                .State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DepartamentoExists(id))
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
        public async Task<ActionResult<Departamento>> PostDepartamento(Departamento departamento)
        {
            _context.Departamentos.Add(departamento);

            await _context.SaveChangesAsync();

            return CreatedAtAction
                ("GetDepartamento", new { id = departamento.Id_Depatamento }, departamento);
        }

        private bool DepartamentoExists(int id)
        {
            return _context.Departamentos.Any(departamento => departamento.Id_Depatamento == id);
        }
    }
}
