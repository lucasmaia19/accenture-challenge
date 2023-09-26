using LucasChallenge.Domain.Entities;
using System.Text.Json.Serialization;

namespace LucasChallenge.Aplication.Dtos
{
    public class CompanyDto
    {
        public long Id { get; set; }
        public string cnpj { get; set; }
        public string fantasyName { get; set; }
        public string cep { get; set; }
        public ICollection<SupplierDto>? suppliers { get; set; }
    }
}