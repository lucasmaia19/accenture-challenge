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
            };

            return companyDto;
        }

        public IEnumerable<CompanyDto> MapperListCompanyDto(IEnumerable<Company> companies)
        {
            var dto = companies.Select(x => new CompanyDto { Id = x.Id,
                                                                cep = x.cep,
                                                                cnpj = x.cnpj,
                                                                fantasyName = x.fantasyName});

            return dto;
        }
    }
}
