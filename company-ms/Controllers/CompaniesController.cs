using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Ms.Companies.Core.Contracts;
using Ms.Companies.Core.Model;

namespace Ms.Companies.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        //private readonly DataBaseContext _context;
        private readonly ICompanyService _context;

        public CompaniesController(ICompanyService context)
        {
            _context = context;
        }
        //public CompaniesController(DataBaseContext context)
        //{
        //    _context = context;
        //}

        // GET: api/Companies
        //[HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompany()
        {
            return  Ok(_context.Get());
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {
            var company = _context.Find(id);

            if (company == null)
            {
                return NotFound();
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                return BadRequest();
            }

            _context.Entry(company);//.State = EntityState.Modified;

            //try
            //{
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!CompanyExists(id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}

            return NoContent();
        }

        // POST: api/Companies
        [HttpPost]
        public ActionResult PostCompany(Company company)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            _context.Entry(company);
            //await _context.SaveChangesAsync();

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var company = _context.Find(id);
            if (company == null)
            {
                return NotFound();
            }

            _context.Remove(id);
            //await _context.SaveChangesAsync();

            return Ok();
        }

        //private bool CompanyExists(int id)
        //{
        //    return _context.Company.Any(e => e.CompanyId == id);
        //}
    }
}
