using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using MsCompany.Core.Contracts;
using MsCompany.Core.Model;

namespace MsCompany.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompanyUnitTestingController : ControllerBase
    {

        private readonly ICompanyService _context;

        public CompanyUnitTestingController(ICompanyService context)
        {
            _context = context;
        }        

        // GET: api/Companies
        //[HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompany()
        {
            
            return Ok(_context.Get());
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

            _context.Entry(company);

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
           
            return Ok();
        }
    }
}
