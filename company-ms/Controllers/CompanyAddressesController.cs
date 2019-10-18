using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Model;
using MsCompany.Core.Service;

namespace MsCompany.Core
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyAddressesController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private ErrorService _error;

        public CompanyAddressesController(DataBaseContext context)
        {
            _context = context;
        }

        //// GET: api/CompanyAddresses
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CompanyAddress>>> GetCompanyAddress()
        //{
        //    return await _context.CompanyAddress.ToListAsync();
        //}


        // GET: api/CompanyAddresses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyAddress>> GetCompanyAddress(int id)
        {
            var companyAddress = await _context.CompanyAddress.FindAsync(id);

            if (companyAddress == null)
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1)}, 1));
            }

            return companyAddress;
        }

        // PUT: api/CompanyAddresses/5
        [HttpPut("{id}")]
        public IActionResult PutCompanyAddress(int id, CompanyAddress companyAddress)
        {
            if (id != companyAddress.CompanyAddressId)
            {
                return BadRequest(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 2) }, 1));
            }
            if (!CompanyAddressExists(id))
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1) }, 1));
            }
            try
            {
                CompanyAddressUpdate(companyAddress);
            }
            catch (DbUpdateConcurrencyException e)
            {                
                return BadRequest(_error.CreateMessageReturnError(e,2));                
            }

            return NoContent();
        }

        // POST: api/CompanyAddresses
        [HttpPost]
        public async Task<ActionResult<CompanyAddress>> PostCompanyAddress(CompanyAddress companyAddress)
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(_error.CreateMessageReturnError(ModelState, 1));
            }
            try
            {
                CompanyAddressPost(companyAddress);
            }
            catch(Exception e)
            {
                return BadRequest(_error.CreateMessageReturnError(e, 2));
            }

            return CreatedAtAction("GetCompanyAddress", new { id = companyAddress.CompanyAddressId }, companyAddress);
        }

       
        // DELETE: api/CompanyAddresses/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyAddress>> DeleteCompanyAddress(int id)
        {
            var companyAddress = await _context.CompanyAddress.FindAsync(id);
            if (companyAddress == null)
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1) }, 1));
            }
            companyAddress.DateDeleted = DateTime.Now;
            try
            {
                CompanyAddressUpdate(companyAddress);                
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(_error.CreateMessageReturnError(e,2));
            }

            return companyAddress;
        }

        private bool CompanyAddressExists(int id)
        {
            return _context.CompanyAddress.Any(e => e.CompanyAddressId == id);
        }

        public bool CompanyAddressPost(CompanyAddress companyAddress)
        {
            _context.CompanyAddress.Add(companyAddress);
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }


        public bool CompanyAddressUpdate(CompanyAddress companyAddress)
        {
            var _companyAddress = _context.CompanyAddress.Find(companyAddress);
            if (companyAddress == null)
            {
                return false;
            }

            companyAddress.DateUpdated = DateTime.Now;
            _context.Entry(companyAddress).State = EntityState.Modified;
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
