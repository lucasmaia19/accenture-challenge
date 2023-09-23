using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Entities;

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
    }
}