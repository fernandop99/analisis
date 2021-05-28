using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sistema.Datos;
using Sistema.Entidades.Informacion;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sistemas.Web.Controllers.Personal_Information_Controllers
{
    public class EmailController : Controller
    {
        private readonly DbContextSistema _context;

        public EmailController(DbContextSistema context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Email>>> GetEmail()
        {
            return await _context.Emails.ToListAsync();
        }

        [HttpGet("{Id_Email}")]
        public async Task<ActionResult<Email>> GetEmail(int id)
        {
            var email = await _context.Emails.FindAsync(id);

            if (email == null)
            {
                return NotFound();
            }
            return email; 
        }

        [HttpPut("Id_Email")]
        public async Task<IActionResult> PutEmail(int id, Email email)
        {
            if (id != email.Id_Email)
            {
                return BadRequest();
            }

            _context.Entry(email).State = EntityState.Modified;
            try
            {
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmailExists(id))
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
        public async Task<ActionResult<Email>> PostEmail(Email email)
        {
            _context.Emails.Add(email);

            await _context.SaveChangesAsync();

            return CreatedAtAction
                ("GetEmail", new { id = email.Id_Email }, email);
        }

       

        private bool EmailExists(int id)
        {
            return _context.Emails
                .Any(email => email.Id_Email == id);
        }
    }
}
