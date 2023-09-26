using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Domain.Core.Interfaces.Services
{
    public interface IServiceCompany : IServiceBase<Company>
    {
        public ICollection<Company> GetCompany();
        public Company GetCompanyById(long companyId);

    }
}