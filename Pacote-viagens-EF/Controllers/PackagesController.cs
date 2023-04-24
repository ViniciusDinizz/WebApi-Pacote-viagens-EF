using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Pacote_viagens_EF.Data;
using Pacote_viagens_EF.Models;

namespace Pacote_viagens_EF.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PackagesController : ControllerBase
    {
        private readonly Pacote_viagens_EFContext _context;

        public PackagesController(Pacote_viagens_EFContext context)
        {
            _context = context;
        }

        // GET: api/Packages
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Package>>> GetPackage()
        {
          if (_context.Package == null)
          {
              return NotFound();
          }
            return await _context.Package.ToListAsync();
        }

        // GET: api/Packages/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Package>> GetPackage(int id)
        {
          if (_context.Package == null)
          {
              return NotFound();
          }
            var package = await _context.Package.FindAsync(id);

            if (package == null)
            {
                return NotFound();
            }

            return package;
        }

        // PUT: api/Packages/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPackage(int id, Package package)
        {
            if (id != package.Id)
            {
                return BadRequest();
            }

            _context.Entry(package).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PackageExists(id))
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

        // POST: api/Packages
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Package>> PostPackage(Package package)
        {
          if (_context.Package == null)
          {
              return Problem("Entity set 'Pacote_viagens_EFContext.Package'  is null.");
          }
            var client = await _context.Client.Include(c => c.Id).FirstOrDefaultAsync(c => c.Id == package.Client.Id);
            var ticket = await _context.Ticket.Include(t => t.Id).FirstOrDefaultAsync(t => t.Id == package.Ticket.Id);
            var hotel = await _context.Hotel.Include(h => h.Id).FirstOrDefaultAsync(h => h.Id == package.Hotel.Id);

            if(client == null || ticket == null|| hotel == null) 
            {
                return NotFound();
            }
            package.Client = client;
            package.Ticket = ticket;
            package.Hotel = hotel;

            _context.Package.Add(package);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPackage", new { id = package.Id }, package);
        }

        // DELETE: api/Packages/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePackage(int id)
        {
            if (_context.Package == null)
            {
                return NotFound();
            }
            var package = await _context.Package.FindAsync(id);
            if (package == null)
            {
                return NotFound();
            }

            _context.Package.Remove(package);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PackageExists(int id)
        {
            return (_context.Package?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
