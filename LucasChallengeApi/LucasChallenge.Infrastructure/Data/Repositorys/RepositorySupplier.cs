using LucasChallenge.Domain.Core.Interfaces.Repositories;
using LucasChallenge.Domain.Entities;

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
    }
}