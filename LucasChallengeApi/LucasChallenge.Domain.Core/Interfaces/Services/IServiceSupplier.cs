using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Domain.Core.Interfaces.Services
{
    public interface IServiceSupplier : IServiceBase<Supplier>
    {
        public ICollection<Supplier> GetSupplier();
        public Supplier GetSupplierById(long companyId);
    }
}