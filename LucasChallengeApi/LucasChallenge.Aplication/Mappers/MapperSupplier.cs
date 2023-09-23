using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LucasChallenge.Infrastructure.CrossCutting.Mapper
{
    public class MapperSupplier : IMapperSupplier
    {
        public Supplier MapperDtoToEntity(SupplierDto supplierDto)
        {
            var supplier = new Supplier()
            {
                Id = supplierDto.Id,
                cep = supplierDto.cep,
                cnpj_cpf = supplierDto.cnpj_cpf,
                email = supplierDto.email,
                name = supplierDto.name
            };

            return supplier;
        }

        public SupplierDto MapperEntityToDto(Supplier supplier)
        {
            var supplierDto = new SupplierDto()
            {
                Id = supplier.Id,
                cep = supplier.cep,
                cnpj_cpf = supplier.cnpj_cpf,
                email = supplier.email,
                name = supplier.name
            };

            return supplierDto;
        }

        public IEnumerable<SupplierDto> MapperListSupplierDto(IEnumerable<Supplier> suppliers)
        {
            var dto = suppliers.Select(x => new SupplierDto
            {
                Id = x.Id,
                cep = x.cep,
                cnpj_cpf = x.cnpj_cpf,
                email = x.email,
                name = x.name
            });

            return dto;
        }
    }
}
