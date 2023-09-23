using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;

namespace LucasChallenge.Aplication
{
    public class AplicationServiceCompany : IAplicationServiceCompany
    {
        private readonly IServiceCompany serviceCompany;
        private readonly IMapperCompany mapperCompany;

        public AplicationServiceCompany(IServiceCompany serviceCompany, IMapperCompany mapperCompany)
        {
            this.serviceCompany = serviceCompany;
            this.mapperCompany = mapperCompany;
        }

        public void Add(CompanyDto companyDto)
        {
            var company = mapperCompany.MapperDtoToEntity(companyDto);
            serviceCompany.Add(company);
        }

        public IEnumerable<CompanyDto> GetAll()
        {
            var companies = serviceCompany.GetAll();
            return mapperCompany.MapperListCompanyDto(companies);
        }

        public CompanyDto GetById(long id)
        {
            var company = serviceCompany.GetById(id);
            return mapperCompany.MapperEntityToDto(company);
        }

        public void Remove(CompanyDto companyDto)
        {
            var company = mapperCompany.MapperDtoToEntity(companyDto);
            serviceCompany.Remove(company);
        }

        public void Update(CompanyDto companyDto)
        {
            var company = mapperCompany.MapperDtoToEntity(companyDto);
            serviceCompany.Update(company);
        }
    }
}