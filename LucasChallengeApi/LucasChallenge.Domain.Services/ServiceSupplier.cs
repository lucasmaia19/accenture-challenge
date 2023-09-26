using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Domain.Services
{
    public class ServiceSupplier : ServiceBase<Supplier>, IServiceSupplier
    {
        private readonly IRepositorySupplier repositorySupplier;

        public ServiceSupplier(IRepositorySupplier repositorySupplier) : base(repositorySupplier)
        {
            this.repositorySupplier = repositorySupplier;
        }

        public ICollection<Supplier> GetSupplier()
        => repositorySupplier.GetSupplier();

        public Supplier GetSupplierById(long supplierId)
            => repositorySupplier.GetSupplierById(supplierId);
    }
}