using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ms.Companies.Core.Model;

namespace Ms.Companies.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAddressesController : ControllerBase
    {
        private readonly DataBaseContext _context;

        public CompanyAddressesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CompanyAddresses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CompanyAddress>>> GetCompanyAddress()
        {
            return await _context.CompanyAddress.ToListAsync();
        }


        // GET: api/CompanyAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAddress>> GetCompanyAddress(int id)
        {
            var companyAddress = await _context.CompanyAddress.FindAsync(id);

            if (companyAddress == null)
            {
                return NotFound();
            }

            return companyAddress;
        }

        // PUT: api/CompanyAddresses/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCompanyAddress(int id, CompanyAddress companyAddress)
        {
            if (id != companyAddress.CompanyAddressId)
            {
                return BadRequest();
            }

            _context.Entry(companyAddress).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CompanyAddressExists(id))
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

        // POST: api/CompanyAddresses
        [HttpPost]
        public async Task<ActionResult<CompanyAddress>> PostCompanyAddress(CompanyAddress companyAddress)
        {
            _context.CompanyAddress.Add(companyAddress);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompanyAddress", new { id = companyAddress.CompanyAddressId }, companyAddress);
        }

        // DELETE: api/CompanyAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyAddress>> DeleteCompanyAddress(int id)
        {
            var companyAddress = await _context.CompanyAddress.FindAsync(id);
            if (companyAddress == null)
            {
                return NotFound();
            }

            _context.CompanyAddress.Remove(companyAddress);
            await _context.SaveChangesAsync();

            return companyAddress;
        }

        private bool CompanyAddressExists(int id)
        {
            return _context.CompanyAddress.Any(e => e.CompanyAddressId == id);
        }
    }
}
