using LucasChallenge.Aplication.Dtos;

namespace LucasChallenge.Aplication.Interfaces
{
    public interface IAplicationServiceSupplier
    {
        void Add(SupplierDto supplierDto);

        void Update(SupplierDto supplierDto);

        void Remove(SupplierDto supplierDto);

        IEnumerable<SupplierDto> GetAll();

        SupplierDto GetById(long id);
    }
}