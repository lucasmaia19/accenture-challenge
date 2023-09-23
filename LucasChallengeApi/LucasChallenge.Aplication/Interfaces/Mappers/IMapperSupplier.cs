using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Infrastructure.CrossCutting.Interfaces
{
    public interface IMapperSupplier
    {
        Supplier MapperDtoToEntity(SupplierDto supplierDto);

        IEnumerable<SupplierDto> MapperListSupplierDto(IEnumerable<Supplier> suppliers);

        SupplierDto MapperEntityToDto(Supplier supplier);
    }
}