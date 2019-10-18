using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Model;
using MsCompany.Core.Service;

namespace MsCompany.Core.Controllers
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
        public ActionResult<CompanyAddress> GetCompanyAddress(int id)
        {
            var companyAddress = _context.CompanyAddress.Find(id);

            if (companyAddress == null)
            {
                if (_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyAddressId = CreateMessageError(3, 1) }, 1));

            }

            return companyAddress;
        }

        // PUT: api/CompanyAddresses/5
        [HttpPut("{id}")]
        public IActionResult PutCompanyAddress(int id, CompanyAddress companyAddress)
        {
            if (id != companyAddress.CompanyAddressId)
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 2) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CompanyAddressId = CreateMessageError(3, 2) }, 1));

            }
            if (!CompanyAddressExists(id))
            {
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyAddressId = CreateMessageError(3, 1) }, 1));
            }
            try
            {
                CompanyAddressUpdate(companyAddress);
            }
            catch (DbUpdateConcurrencyException e)
            {                
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e,2));    
                else
                    return BadRequest(CreateMessageReturnError(e,2));
            }

            return NoContent();
        }

        // POST: api/CompanyAddresses
        [HttpPost]
        public ActionResult PostCompanyAddress(CompanyAddress companyAddress)
        {
            if (!ModelState.IsValid)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(ModelState, 1));
                else
                    return BadRequest(CreateMessageReturnError(ModelState, 1));
            }
            try
            {
                CompanyAddressPost(companyAddress);
            }
            catch (Exception e)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e, 2));
                else
                    return BadRequest(CreateMessageReturnError(e, 2));
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
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyAddressId = _error.CreateMessageError(3, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyAddressId = CreateMessageError(3, 1) }, 1));
            }
            companyAddress.DateDeleted = DateTime.Now;
            try
            {
                CompanyAddressUpdate(companyAddress);                
            }
            catch (DbUpdateConcurrencyException e)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e,2));
                else
                    return BadRequest(CreateMessageReturnError(e,2));
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

        public Error CreateMessageReturnError(dynamic error, int message)
        {
            Error _error = new Error()
            {
                Message = "Erro ao " + Enum.GetName(typeof(Message), message) + " dados",
                Type = 1,
                Errors = error
            };
            return _error;
        }
        public string CreateMessageError(int type, int message)
        {
            switch (message)
            {
                case 1:
                    return Enum.GetName(typeof(TypeError), type) + " não encontrado na base de dados.";
                case 2:
                    return Enum.GetName(typeof(TypeError), type) + " informado está incorreto.";
                case 3:
                    return Enum.GetName(typeof(TypeError), type) + " Erro ao atualizar na base de dados.";
                case 4:
                    return Enum.GetName(typeof(TypeError), type) + " já existente na base de dados.";
                case 5:
                    return Enum.GetName(typeof(TypeError), type) + " não encontrado.";
            }

            return "Error";
        }

        enum Message
        {
            processar = 1,
            atualizar = 2
        }
        enum TypeError
        {
            companyId = 1,
            cnpjCpf = 2,
            companyAddressId = 3,
            companyParamsId = 4,
        }

    }
}
