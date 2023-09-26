using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Infra.Data.Data.Repositorys
{
    public class RepositoryCompany : RepositoryBase<Company>, IRepositoryCompany
    {
        private readonly SqlContext sqlContext;

        public RepositoryCompany(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public ICollection<Company> GetCompany()
        {
            var companiesWithSuppliers = sqlContext.Company
               .Include(x => x.suppliers)
               .ToList();

            var companiesProjected = companiesWithSuppliers
                .Select(company => new Company
                {
                    Id = company.Id,
                    cep = company.cep,
                    cnpj = company.cnpj,
                    fantasyName = company.fantasyName,

                    suppliers = company.suppliers.Select(supplier => new Supplier
                    {
                        Id = supplier.Id,
                        name = supplier.name
                    }).ToList()
                })
                .ToList();

            return companiesProjected;
        }

        public Company GetCompanyById(long companyId)
        {
            var companyWithSuppliers = sqlContext.Company
               .Include(x => x.suppliers)
               .FirstOrDefault(x => x.Id == companyId);

            if (companyWithSuppliers == null)
                return null;

            var company = new Company
            {
                Id = companyWithSuppliers.Id,
                cep = companyWithSuppliers.cep,
                cnpj = companyWithSuppliers.cnpj,
                fantasyName = companyWithSuppliers.fantasyName,

                suppliers = companyWithSuppliers.suppliers.Select(supplier => new Supplier
                {
                    Id = supplier.Id,
                    name = supplier.name
                }).ToList()
            };

            return company;
        }
    }
}