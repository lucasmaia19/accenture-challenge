using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
                name = supplierDto.name,
                birth_data = supplierDto.birth_data,
                pf = supplierDto.pf,
                rg = supplierDto.rg,
                companies = supplierDto.companies.Select(company => new Company
                {
                    Id = company.Id,
                    cep = company.cep,
                    cnpj = company.cnpj,
                    fantasyName = company.fantasyName,
                    
                }).ToList()
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
                name = supplier.name,
                birth_data = supplier.birth_data,
                pf = supplier.pf,
                rg = supplier.rg,
                companies = supplier.companies.Select(company => new CompanyDto
                {
                    Id = company.Id,
                    cep = company.cep,
                    cnpj = company.cnpj,
                    fantasyName = company.fantasyName,

                }).ToList()
            };

            return supplierDto;
        }

        public ICollection<SupplierDto> MapperListSupplierDto(ICollection<Supplier> suppliers)
        {
            var dto = suppliers.Select(x => new SupplierDto
            {
                Id = x.Id,
                cep = x.cep,
                birth_data = x.birth_data,
                cnpj_cpf = x.cnpj_cpf,
                email = x.email,
                name = x.name,
                pf = x.pf,
                rg = x.rg,

                companies = x.companies?.Select(company => new CompanyDto
                {
                    Id = company.Id,
                    fantasyName = company.fantasyName,
                    // Outras propriedades de CompanyDto
                }).ToList()
            }).ToList();

            return dto;
        }

    }
}
