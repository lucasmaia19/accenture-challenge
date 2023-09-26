using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasChallenge.Domain.Exceptions
{
    public class ExpectionsResult : Exception
    {
        public ExpectionsResult(string message) : base(message) { }

    }
}
