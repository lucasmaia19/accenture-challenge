using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LucasChallenge.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SupplierController : Controller
    {
        private readonly IAplicationServiceSupplier applicationServiceSupplier;

        public SupplierController(IAplicationServiceSupplier applicationServiceSupplier)
        {
            this.applicationServiceSupplier = applicationServiceSupplier;
        }

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(applicationServiceSupplier.GetSupplier());
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(long id)
        {
            return Ok(applicationServiceSupplier.GetSupplierById(id));
        }

        [HttpPost]
        public ActionResult Post([FromBody] SupplierDto supplierDto)
        {
            try
            {
                if (supplierDto == null)
                    return NotFound();

                applicationServiceSupplier.Add(supplierDto);
                return Ok("Fornecedor Cadastrado com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        [HttpPut]
        public ActionResult Put([FromBody] SupplierDto supplierDto)
        {
            try
            {
                if (supplierDto == null)
                    return NotFound();

                applicationServiceSupplier.Update(supplierDto);
                return Ok("Fornecedor Atualizado com sucesso!");
            }
            catch (Exception)
            {
                throw;
            }
        }

        [HttpDelete()]
        public ActionResult Delete([FromBody] SupplierDto supplierDto)
        {
            try
            {
                if (supplierDto == null)
                    return NotFound();

                applicationServiceSupplier.Remove(supplierDto);
                return Ok("Fornecedor Removido com sucesso!");
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
