using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using LucasChallenge.Domain.Entities;
using LucasChallenge.Infra.Data.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IAplicationServiceCompany applicationServiceCompany;
        private readonly SqlContext sqlContext;

        public CompanyController(IAplicationServiceCompany applicationServiceCompany, SqlContext sqlContext)
        {
            this.applicationServiceCompany = applicationServiceCompany;
            this.sqlContext = sqlContext;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceCompany.GetCompany());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return Ok(applicationServiceCompany.GetCompanyById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] CompanyDto companyDto)
        {
            try
            {
                if (companyDto == null)
                    return NotFound();

                applicationServiceCompany.Add(companyDto);
                return Ok("Empresa cadastrada com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        // TO-DO: adicionar esta regra nas outras camadas
        [HttpPost("CompanySupplier")]
        public async Task<ActionResult<Company>> AddCompanySupplier(CompanySupplierDto companySupplierDto)
        {
            var company = await sqlContext.Company
                .Where(x => x.Id == companySupplierDto.companiesId)
                .Include(x => x.suppliers)
                .FirstOrDefaultAsync();

            if (company == null) return NotFound();

            var supplier = await sqlContext.Supplier.FindAsync(companySupplierDto.suppliersId);
            if (supplier == null) return NotFound();
            company.suppliers.Add(supplier);
            await sqlContext.SaveChangesAsync();
            return company;
        }

        [HttpPut]
        public ActionResult Put([FromBody] CompanyDto companyDto)
        {
            try
            {
                if (companyDto == null)
                    return NotFound();

                applicationServiceCompany.Update(companyDto);
                return Ok("Empresa atualizada com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] CompanyDto companyDto)
        {
            try
            {
                if (companyDto == null)
                    return NotFound();

                applicationServiceCompany.Remove(companyDto);
                return Ok("Empresa removida com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}