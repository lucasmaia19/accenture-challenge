using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace LucasChallenge.Domain.Entities
{
    public class Supplier : Base
    {
        public string cnpj_cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
        public bool pf { get; set; }
        public string? rg { get; set; }
        public string? birth_data { get; set; }

        public ICollection<Company>? companies { get; set; }

    }
}
