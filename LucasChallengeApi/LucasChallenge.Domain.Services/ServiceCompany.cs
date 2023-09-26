using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Entities;
using System.Net.Sockets;

namespace LucasChallenge.Domain.Services
{
    public class ServiceCompany : ServiceBase<Company>, IServiceCompany
    {
        private readonly IRepositoryCompany repositoryCompany;

        public ServiceCompany(IRepositoryCompany repositoryCompany) : base(repositoryCompany)
        {
            this.repositoryCompany = repositoryCompany;
        }

        public  ICollection<Company> GetCompany()
            => repositoryCompany.GetCompany();
        
        public  Company GetCompanyById(long companyId)
            => repositoryCompany.GetCompanyById(companyId);
    }
}