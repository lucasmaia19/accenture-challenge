using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Exceptions;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;
using LucasChallenge.Infrastructure.CrossCutting.Mapper;

namespace LucasChallenge.Aplication
{
    public class AplicationServiceSupplier : IAplicationServiceSupplier
    {
        private readonly IServiceSupplier serviceSupplier;
        private readonly IMapperSupplier mapperSupplier;

        public AplicationServiceSupplier(IServiceSupplier serviceSupplier, IMapperSupplier mapperSupplier)
        {
            this.serviceSupplier = serviceSupplier;
            this.mapperSupplier = mapperSupplier;
        }

        public void Add(SupplierDto supplierDto)
        {
            var result = GetSupplier();
            var hasCnpj = result.Any(supplier => supplier.cnpj_cpf == supplierDto.cnpj_cpf);

            if (hasCnpj)
            {
                throw new ExpectionsResult("Documento já existente.");
            }
            else
            {
                var supplier = mapperSupplier.MapperDtoToEntity(supplierDto);
                serviceSupplier.Add(supplier);
            }

        }

        //public IEnumerable<SupplierDto> GetAll()
        //{
        //    var supplies = serviceSupplier.GetAll();
        //    return mapperSupplier.MapperListSupplierDto(supplies);
        //}

        public SupplierDto GetById(long id)
        {
            var supplier = serviceSupplier.GetById(id);
            return mapperSupplier.MapperEntityToDto(supplier);
        }

        public void Remove(SupplierDto supplierDto)
        {
            var supplier = mapperSupplier.MapperDtoToEntity(supplierDto);
            serviceSupplier.Remove(supplier);
        }

        public void Update(SupplierDto supplierDto)
        {
            var supplier = mapperSupplier.MapperDtoToEntity(supplierDto);
            serviceSupplier.Update(supplier);
        }

        public ICollection<SupplierDto> GetSupplier()
        {
            var suppliers = serviceSupplier.GetSupplier();
            return mapperSupplier.MapperListSupplierDto(suppliers);
        }
        public SupplierDto GetSupplierById(long supplierId)
        {
            var companies = serviceSupplier.GetSupplierById(supplierId);
            return mapperSupplier.MapperEntityToDto(companies);
        }
    }
}