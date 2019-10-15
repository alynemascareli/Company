using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ms.Companies.Core.Model;

namespace Ms.Companies.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyParamsController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CompanyParamsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CompanyParams
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyParams>>> GetCompanyParams()
        {
            return await _context.CompanyParams.ToListAsync();
        }

        // GET: api/CompanyParams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyParams>> GetCompanyParams(int id)
        {
            var companyParams = await _context.CompanyParams.FindAsync(id);

            if (companyParams == null)
            {
                return NotFound();
            }

            return companyParams;
        }

        // PUT: api/CompanyParams/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyParams(int id, CompanyParams companyParams)
        {
            if (id != companyParams.CompanyParamsId)
            {
                return BadRequest();
            }

            _context.Entry(companyParams).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyParamsExists(id))
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

        // POST: api/CompanyParams
        [HttpPost]
        public async Task<ActionResult<CompanyParams>> PostCompanyParams(CompanyParams companyParams)
        {
            _context.CompanyParams.Add(companyParams);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyParams", new { id = companyParams.CompanyParamsId }, companyParams);
        }

        // DELETE: api/CompanyParams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyParams>> DeleteCompanyParams(int id)
        {
            var companyParams = await _context.CompanyParams.FindAsync(id);
            if (companyParams == null)
            {
                return NotFound();
            }

            _context.CompanyParams.Remove(companyParams);
            await _context.SaveChangesAsync();

            return companyParams;
        }

        private bool CompanyParamsExists(int id)
        {
            return _context.CompanyParams.Any(e => e.CompanyParamsId == id);
        }
    }
}
