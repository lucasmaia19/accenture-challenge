using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LucasChallenge.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class CompanyController : Controller
    {
        private readonly IAplicationServiceCompany applicationServiceCompany;

        public CompanyController(IAplicationServiceCompany applicationServiceCompany)
        {
            this.applicationServiceCompany = applicationServiceCompany;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceCompany.GetAll());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return Ok(applicationServiceCompany.GetById(id));
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