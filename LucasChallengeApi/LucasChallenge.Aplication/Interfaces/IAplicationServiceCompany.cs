using LucasChallenge.Aplication.Dtos;

namespace LucasChallenge.Aplication.Interfaces
{
    public interface IAplicationServiceCompany
    {
        void Add(CompanyDto companyDto);

        void Update(CompanyDto companyDto);

        void Remove(CompanyDto companyDto);

        IEnumerable<CompanyDto> GetAll();

        CompanyDto GetById(long id);
    }
}