using System.Text.Json.Serialization;

namespace LucasChallenge.Domain.Entities
{
    public class Company : Base
    {
        public string cnpj { get; set; }
        public string fantasyName { get; set; }
        public string cep { get; set; }

        public ICollection<Supplier>? suppliers { get; set; }
    }
}