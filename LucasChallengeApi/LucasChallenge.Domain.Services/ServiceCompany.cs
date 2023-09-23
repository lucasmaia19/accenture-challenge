using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Domain.Services
{
    public class ServiceCompany : ServiceBase<Company>, IServiceCompany
    {
        private readonly IRepositoryCompany repositoryCompany;

        public ServiceCompany(IRepositoryCompany repositoryCompany) : base(repositoryCompany)
        {
            this.repositoryCompany = repositoryCompany;
        }
    }
}