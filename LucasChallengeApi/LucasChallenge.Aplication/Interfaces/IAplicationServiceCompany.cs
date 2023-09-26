using LucasChallenge.Aplication.Dtos;
using LucasChallenge.Domain.Entities;

namespace LucasChallenge.Aplication.Interfaces
{
    public interface IAplicationServiceCompany
    {
        void Add(CompanyDto companyDto);

        void Update(CompanyDto companyDto);

        void Remove(CompanyDto companyDto);

        IEnumerable<CompanyDto> GetAll();

        CompanyDto GetById(long id);

        ICollection<CompanyDto> GetCompany();
        CompanyDto GetCompanyById(long companyId);

    }
}