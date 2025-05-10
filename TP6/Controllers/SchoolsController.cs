using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolAPI.Models;

namespace TP6.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolsController : ControllerBase
    {
        private readonly SchoolDbContext _context;

        public SchoolsController(SchoolDbContext context)
        {
            _context = context;
        }

        // GET: api/Schools/get-all-schools
        [HttpGet("get-all-schools")]
        public async Task<ActionResult<IEnumerable<School>>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }

        // GET: api/Schools/get-school-by-id/5
        [HttpGet("get-school-by-id/{id}")]
        public async Task<ActionResult<School>> GetSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);

            if (school == null)
            {
                return NotFound();
            }

            return school;
        }

        // GET: api/Schools/search-by-name/{name}
        [HttpGet("search-by-name/{name}")]
        public async Task<ActionResult<IEnumerable<School>>> SearchByName(string name)
        {
            return await _context.Schools
                .Where(s => s.Name.Contains(name))
                .ToListAsync();
        }

        // PUT: api/Schools/edit-school/{id}
        [HttpPut("edit-school/{id}")]
        public async Task<IActionResult> PutSchool(int id, School school)
        {
            if (id != school.Id)
            {
                return BadRequest();
            }

            _context.Entry(school).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!SchoolExists(id))
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

        // POST: api/Schools/create-school
        [HttpPost("create-school")]
        public async Task<ActionResult<School>> PostSchool(School school)
        {
            _context.Schools.Add(school);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetSchool), new { id = school.Id }, school);
        }

        // DELETE: api/Schools/delete-school/{id}
        [HttpDelete("delete-school/{id}")]
        public async Task<IActionResult> DeleteSchool(int id)
        {
            var school = await _context.Schools.FindAsync(id);
            if (school == null)
            {
                return NotFound();
            }

            _context.Schools.Remove(school);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool SchoolExists(int id)
        {
            return _context.Schools.Any(e => e.Id == id);
        }
    }
}