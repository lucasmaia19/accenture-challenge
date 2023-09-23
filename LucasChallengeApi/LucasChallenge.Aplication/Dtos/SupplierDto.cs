using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasChallenge.Aplication.Dtos
{
    public class SupplierDto
    {
        public long Id { get; set; }
        public string cnpj_cpf { get; set; }
        public string name { get; set; }
        public string email { get; set; }
        public string cep { get; set; }
    }
}
