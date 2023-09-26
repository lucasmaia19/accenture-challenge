using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Domain.Core.Interfaces.Repositories
{
    public interface IRepositorySupplier : IRepositoryBase<Supplier>
    {
        public ICollection<Supplier> GetSupplier();
        public Supplier GetSupplierById(long companyId);
    }
}
