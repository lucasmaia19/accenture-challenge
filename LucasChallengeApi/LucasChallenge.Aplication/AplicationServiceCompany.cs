using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Aplication.Interfaces;
using LucasChallenge.Domain.Core.Interfaces.Services;
using LucasChallenge.Domain.Entities;
using LucasChallenge.Domain.Exceptions;
using LucasChallenge.Infrastructure.CrossCutting.Interfaces;
using LucasChallenge.Infrastructure.CrossCutting.Mapper;

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
            var result = GetCompany();
            var hasCnpj = result.Any(company => company.cnpj == companyDto.cnpj);

            if (hasCnpj)
            {
                throw new ExpectionsResult("CNPJ já existente.");
            }
            else
            {
                var company = mapperCompany.MapperDtoToEntity(companyDto);
                serviceCompany.Add(company);
            }

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
        
        public ICollection<CompanyDto> GetCompany()
        {
            var companies = serviceCompany.GetCompany();
            return mapperCompany.MapperListCompanyDto2(companies);
        }
        public CompanyDto GetCompanyById(long companyId)
        {
            var companies = serviceCompany.GetCompanyById(companyId);
            return mapperCompany.MapperEntityToDto(companies);
        }

        IEnumerable<CompanyDto> IAplicationServiceCompany.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}