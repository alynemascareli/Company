using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MsCompany.Core.Model;
using MsCompany.Core.Service;
using MsCompany.Service;

namespace MsCompany.Core.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CompaniesController : ControllerBase
    {
        
        private readonly DataBaseContext _context;
        public ErrorService _error;

        public CompaniesController(DataBaseContext context)
        {
            _context = context;
        }

        // GET: api/Companies
        [HttpGet]
        public ActionResult<IEnumerable<Company>> GetCompany()
        {

            return Ok(_context.Company.Include(x => x.CompanyAddress).Include(x => x.CompanyParams).ToList());
        }

        // GET: api/Companies/5
        [HttpGet("{id}")]
        public ActionResult<Company> GetCompanyById(int id)
        {

            var company = _context.Company.Include(x => x.CompanyAddress).Include(x => x.CompanyParams).FirstOrDefault(x => x.CompanyId == id);
            if (company == null)
            {
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyId = _error.CreateMessageError(1, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyId = CreateMessageError(1, 1) }, 1));
            }

            return Ok(company);
        }

        // PUT: api/Companies/5
        [HttpPut("{id}")]
        public IActionResult PutCompany(int id, Company company)
        {
            if (id != company.CompanyId)
            {
                if (_error != null)
                    return BadRequest(CreateMessageReturnError(new { CompanyId = CreateMessageError(1, 2) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CompanyId = CreateMessageError(1, 2) }, 1));

            }
            if (!CompanyExists(id))
            {
                if (_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyId = _error.CreateMessageError(1, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyId = CreateMessageError(1, 1) }, 1));

            }

            if (!CnpjValidation(company.CnpjCpf))
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(new { CnjCpf = _error.CreateMessageError(2, 2) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CnjCpf = CreateMessageError(2, 2) }, 1));

            }
            if (CnpjExist(company.CnpjCpf, company.CompanyId))
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(new { CnjCpf = _error.CreateMessageError(2, 4) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CnjCpf = CreateMessageError(2, 4) }, 1));
            }

            try
            {
                CompanyUpdate(company);
            }
            catch (DbUpdateConcurrencyException e)
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e, 2)); 
                else
                    return BadRequest(CreateMessageReturnError(e, 2));
            }
            if (company.CompanyAddress != null && company.CompanyAddress.Count > 0)
            {
                CompanyAddressUpdate(company.CompanyAddress);
            }
            if (company.CompanyParams != null && company.CompanyParams.Count > 0)
            {
                CompanyParamsUpdate(company.CompanyParams);
            }

            return NoContent();

        }

        // POST: api/Companies
        [HttpPost]
        public async Task<ActionResult> PostCompanyAsync(Company company)
        {
            if (!ModelState.IsValid)
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(ModelState, 1));
                else
                    return BadRequest(CreateMessageReturnError(ModelState, 1));
            }
            if(!CnpjValidation(company.CnpjCpf))
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError( new { CnjCpf = _error.CreateMessageError(2, 2) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CnjCpf = CreateMessageError(2, 2) }, 1));
            }
            if (CnpjExist(company.CnpjCpf, company.CompanyId))
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(new { CnjCpf = _error.CreateMessageError(2, 4) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CnjCpf = CreateMessageError(2, 4) }, 1));
            }
            _context.Company.Add(company);
            try
            {
                await _context.SaveChangesAsync();                
            }
            catch (Exception e)
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e, 2));
                else
                    return BadRequest(CreateMessageReturnError(e, 2));
            }

            return CreatedAtAction("GetCompany", new { id = company.CompanyId }, company);
        }

        // DELETE: api/Companies/5
        [HttpDelete("{id}")]
        public ActionResult DeleteCompany(int id)
        {
            var company = _context.Company.FirstOrDefault(x => x.CompanyId == id);
            if (company == null)
            {
                if (_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyId = _error.CreateMessageError(1, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyId = CreateMessageError(1, 1) }, 1));
            }
            company.DateDeleted = DateTime.Now;
            try
            {
                CompanyUpdate(company);
            }
            catch (Exception e)
            {
                if (_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e, 2));
                else
                    return BadRequest(CreateMessageReturnError(e, 2));
            }

            return Ok();
        }

        private bool CompanyExists(int id)
        {
            return _context.Company.Any(e => e.CompanyId == id);
        }

        private void CompanyAddressUpdate(List<CompanyAddress> companyAddress)
        {
            CompanyAddressesController addressController = new CompanyAddressesController(_context);
            // addressController.CompanyAddressUpdate(companyAddress);

            for (int i = 0; i < companyAddress.Count; i++)
            {
                if(companyAddress[i].CompanyAddressId != 0)
                {
                    addressController.CompanyAddressUpdate(companyAddress[i]);
                }
                else
                {
                    addressController.CompanyAddressPost(companyAddress[i]);
                }
            }
        }

        private void CompanyParamsUpdate(List<CompanyParams> companyParams)
        {
            CompanyParamsController paramsController = new CompanyParamsController(_context);
            for (int i = 0; i < companyParams.Count; i++)
            {
                if(companyParams[i].CompanyParamsId != 0)
                {
                    paramsController.CompanyParamsUpdate(companyParams[i]);
                }
                else
                {
                    paramsController.CompanyParamsPost(companyParams[i]);
                }
            }
        }

        private bool CnpjValidation(string cnpj)
        {
            ValidationService validation = new ValidationService();
            if (cnpj== null || !validation.cpfCnpj(cnpj) )
            {
                return false;
            }
            return true;
        }

        private bool CnpjExist(string cnpj, int companyId)
        {
            return _context.Company.Any(e => e.CnpjCpf == cnpj && e.CompanyId != companyId);
        }

        private bool CompanyUpdate(Company company)
        {
            company.DateUpdated = DateTime.Now;
            _context.Entry(company).State = EntityState.Modified;
            try
            {
                _context.SaveChangesAsync();
                return true;
            }
            catch (Exception)
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