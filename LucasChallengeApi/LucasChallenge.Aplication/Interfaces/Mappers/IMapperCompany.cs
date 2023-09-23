using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Infrastructure.CrossCutting.Interfaces
{
    public interface IMapperCompany
    {
        Company MapperDtoToEntity(CompanyDto companyDto);

        IEnumerable<CompanyDto> MapperListCompanyDto(IEnumerable<Company> companies);

        CompanyDto MapperEntityToDto(Company company);
    }
}