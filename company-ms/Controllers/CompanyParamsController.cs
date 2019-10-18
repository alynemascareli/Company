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
        public ActionResult<CompanyParams> GetCompanyParams(int id)
        {
            var companyParams = _context.CompanyParams.Find(id);

            if (companyParams == null)
            {
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyParamsId = CreateMessageError(4, 1) }, 1));
            }

            return companyParams;
        }

        // PUT: api/CompanyParams/5
        [HttpPut("{id}")]
        public IActionResult PutCompanyParams(int id, CompanyParams companyParams)
        {
            if (id != companyParams.CompanyParamsId)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 2) }, 1));
                else
                    return BadRequest(CreateMessageReturnError(new { CompanyParamsId = CreateMessageError(4, 2) }, 1));
            }
            if (!CompanyParamsExists(id))
            {
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyParamsId = CreateMessageError(4, 1) }, 1));
            }

            try
            {
                CompanyParamsUpdate(companyParams);
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

        // POST: api/CompanyParams
        [HttpPost]
        public ActionResult PostCompanyParams(CompanyParams companyParams)
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
                CompanyParamsPost(companyParams);
            }
            catch (Exception e)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e, 1));
                else
                    return BadRequest(CreateMessageReturnError(e, 1));
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
                if(_error != null)
                    return NotFound(_error.CreateMessageReturnError(new { CompanyParamsId = _error.CreateMessageError(4, 1) }, 1));
                else
                    return NotFound(CreateMessageReturnError(new { CompanyParamsId = CreateMessageError(4, 1) }, 1));
            }
            companyParams.DateDeleted = DateTime.Now;
            try
            {
                CompanyParamsUpdate(companyParams);
            }
            catch (DbUpdateConcurrencyException e)
            {
                if(_error != null)
                    return BadRequest(_error.CreateMessageReturnError(e,2));
                else
                    return BadRequest(CreateMessageReturnError(e, 2));
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
