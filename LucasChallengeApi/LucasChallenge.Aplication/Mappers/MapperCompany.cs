using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;

namespace LucasChallenge.Infrastructure.CrossCutting.Mapper
{
    public class MapperCompany : IMapperCompany
    {
        public Company MapperDtoToEntity(CompanyDto companyDto)
        {
            var company = new Company()
            {
                Id = companyDto.Id,
                fantasyName = companyDto.fantasyName,
                cep = companyDto.cep,
                cnpj = companyDto.cnpj,
                suppliers = companyDto.suppliers.Select(supplierDto => new Supplier
                {
                    Id = supplierDto.Id,
                    name = supplierDto.name,
                    email = supplierDto.email,
                    cep = supplierDto.cep,
                    pf = supplierDto.pf,
                    cnpj_cpf = supplierDto.cnpj_cpf,
                    birth_data = supplierDto.birth_data,
                    rg = supplierDto.rg
                }).ToList()
            };

            return company;
        }

        public CompanyDto MapperEntityToDto(Company company)
        {
            var companyDto = new CompanyDto()
            {
                Id = company.Id,
                fantasyName = company.fantasyName,
                cep = company.cep,
                cnpj = company.cnpj,
                suppliers = company.suppliers.Select(supplier => new SupplierDto
                {
                    Id = supplier.Id,
                    name = supplier.name,
                    email = supplier.email,
                    cep = supplier.cep,
                    pf = supplier.pf,
                    cnpj_cpf = supplier.cnpj_cpf,
                    birth_data = supplier.birth_data,
                    rg = supplier.rg
                }).ToList()
            };

            return companyDto;
        }  
        public CompanyDto MapperEntityToDto2(Company company)
        {
            var companyDto = new CompanyDto()
            {
                Id = company.Id,
                fantasyName = company.fantasyName,
                cep = company.cep,
                cnpj = company.cnpj,
                suppliers = company.suppliers.Select(supplier => new SupplierDto
                {
                    Id = supplier.Id,
                    name = supplier.name,
                    email = supplier.email,
                    cep = supplier.cep,
                    pf = supplier.pf,
                    cnpj_cpf = supplier.cnpj_cpf,
                    birth_data = supplier.birth_data,
                    rg = supplier.rg
                }).ToList()
            };

            return companyDto;
        }

        //public IEnumerable<CompanyDto> MapperListCompanyDto(IEnumerable<Company> companies)
        //{
        //    var dto = companies.Select(x => new CompanyDto
        //    {
        //        Id = x.Id,
        //        cep = x.cep,
        //        cnpj = x.cnpj,
        //        fantasyName = x.fantasyName,
        //        suppliers = x.suppliers?.Select(supplier => new SupplierDto
        //        {
        //            Id = supplier.Id,
        //            name = supplier.name,
        //            email = supplier.email,
        //            cep = supplier.cep,
        //            pf = supplier.pf,
        //            cnpj_cpf = supplier.cnpj_cpf,
        //            birth_data = supplier.birth_data,
        //            rg = supplier.rg
        //        }).ToList()
        //    });

        //    return dto;
        //}     
        
        public ICollection<CompanyDto> MapperListCompanyDto2(ICollection<Company> companies)
        {
            var dto = companies.Select(x => new CompanyDto
            {
                Id = x.Id,
                cep = x.cep,
                cnpj = x.cnpj,
                fantasyName = x.fantasyName,
                suppliers = x.suppliers?.Select(supplier => new SupplierDto
                {
                    Id = supplier.Id,
                    name = supplier.name,
                    //email = supplier.email,
                    //cep = supplier.cep,
                    //pf = supplier.pf,
                    //cnpj_cpf = supplier.cnpj_cpf,
                    //birth_data = supplier.birth_data,
                    //rg = supplier.rg
                }).ToList()
            }).ToList();

            return dto;
        }
    }
}