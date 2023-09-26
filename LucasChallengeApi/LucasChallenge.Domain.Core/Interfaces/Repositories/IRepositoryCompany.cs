using LucasChallenge.Domain.Entities;
using System.Collections;
using System.Collections.Generic;
using System.Net.Sockets;

namespace LucasChallenge.Domain.Core.Interfaces.Repositories
{
    public interface IRepositoryCompany : IRepositoryBase<Company>
    {
        public ICollection<Company> GetCompany();
        public Company GetCompanyById(long companyId);

    }
}
