using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace LucasChallenge.Domain.Entities
{
    public class Company : Base
    {
        public string cnpj { get; set; }
        public string fantasyName { get; set; }
        public string cep { get; set; }
    }
}
