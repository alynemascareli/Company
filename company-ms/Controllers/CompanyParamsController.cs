using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Model;
using MsCompany.Core.Service;

namespace MsCompany.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyParamsController : ControllerBase
    {
        private readonly DataBaseContext _context;
        private ErrorService _error;

        public CompanyParamsController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/CompanyParams
        //[HttpGet]
        //public async Task<ActionResult<IEnumerable<CompanyParams>>> GetCompanyParams()
        //{
        //    return await _context.CompanyParams.ToListAsync();
        //}

        // GET: api/CompanyParams/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CompanyParams>> GetCompanyParams(int id)
        {
            var companyParams = await _context.CompanyParams.FindAsync(id);

            if (companyParams == null)
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
            }

            return companyParams;
        }

        // PUT: api/CompanyParams/5
        [HttpPut("{id}")]
        public IActionResult PutCompanyParams(int id, CompanyParams companyParams)
        {
            if (id != companyParams.CompanyParamsId)
            {
                return BadRequest(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 2) }, 1));
            }
            if (!CompanyParamsExists(id))
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
            }

            try
            {
                CompanyParamsUpdate(companyParams);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(_error.CreateMessageReturnError(e,2));
            }

            return NoContent();
        }

        // POST: api/CompanyParams
        [HttpPost]
        public async Task<ActionResult<CompanyParams>> PostCompanyParams(CompanyParams companyParams)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(_error.CreateMessageReturnError(ModelState, 1));
            }
            try
            {
                CompanyParamsPost(companyParams);                
            }
            catch (Exception e)
            {
                return BadRequest(_error.CreateMessageReturnError(e,1));
            }

            return CreatedAtAction("GetCompanyParams", new { id = companyParams.CompanyParamsId }, companyParams);
        }

        // DELETE: api/CompanyParams/5
        [HttpDelete("{id}")]
        public async Task<ActionResult<CompanyParams>> DeleteCompanyParams(int id)
        {
            var companyParams = await _context.CompanyParams.FindAsync(id);
            if (companyParams == null)
            {
                return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
            }
            companyParams.DateDeleted = DateTime.Now;
            try
            {
                CompanyParamsUpdate(companyParams);
            }
            catch (DbUpdateConcurrencyException e)
            {
                return BadRequest(_error.CreateMessageReturnError(e,2));                
            }

            return Ok();
        }

        private bool CompanyParamsExists(int id)
        {
            return _context.CompanyParams.Any(e => e.CompanyParamsId == id);
        }
        public bool CompanyParamsUpdate(CompanyParams companyParams)
        {
            _context.Entry(companyParams).State = EntityState.Modified;
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

        public bool CompanyParamsPost(CompanyParams companyParams)
        {
            _context.CompanyParams.Add(companyParams);
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
