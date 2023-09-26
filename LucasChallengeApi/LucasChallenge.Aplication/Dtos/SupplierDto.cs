using LucasChallenge.Domain.Entities;
using System.Text.Json.Serialization;

namespace LucasChallenge.Aplication.Dtos
{
    public class SupplierDto
    {
        public long Id { get; set; }
        public string cnpj_cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public bool pf { get; set; }
        public string? rg { get; set; }
        public string? birth_data { get; set; }

        public ICollection<CompanyDto>? companies { get; set; }
    }
}