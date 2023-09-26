using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Infra.Data.Data.Repositorys
{
    public class RepositorySupplier : RepositoryBase<Supplier>, IRepositorySupplier
    {
        private readonly SqlContext sqlContext;

        public RepositorySupplier(SqlContext sqlContext)
            : base(sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public ICollection<Supplier> GetSupplier()
        {
            var companiesWithCompanies = sqlContext.Supplier
               .Include(x => x.companies)
               .ToList();

            var companiesProjected = companiesWithCompanies
                .Select(supplier => new Supplier
                {
                    Id = supplier.Id,
                    cep = supplier.cep,
                    cnpj_cpf = supplier.cnpj_cpf,
                    name = supplier.name,
                    birth_data = supplier.birth_data,
                    email = supplier.email,
                    pf = supplier.pf,
                    rg = supplier.rg,

                    companies = supplier.companies.Select(company => new Company
                    {
                        Id = company.Id,
                        fantasyName = company.fantasyName
                    }).ToList()
                })
                .ToList();

            return companiesProjected;
        }

        public Supplier GetSupplierById(long supplierId)
        {
            var companyWithSuppliers = sqlContext.Supplier
               .Include(x => x.companies)
               .FirstOrDefault(x => x.Id == supplierId);

            if (companyWithSuppliers == null)
                return null;

            var supplier = new Supplier
            {
                Id = companyWithSuppliers.Id,
                birth_data = companyWithSuppliers.birth_data,
                cep = companyWithSuppliers.cep,
                cnpj_cpf = companyWithSuppliers.cnpj_cpf,
                email = companyWithSuppliers.email,
                pf = companyWithSuppliers.pf,
                name = companyWithSuppliers.name,
                rg = companyWithSuppliers.rg,

                companies = companyWithSuppliers.companies.Select(company => new Company
                {
                    Id = company.Id,
                    fantasyName = company.fantasyName
                }).ToList()
            };

            return supplier;
        }

    }
}