using LucasChallenge.Domain.Core.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;

namespace LucasChallenge.Infra.Data.Data.Repositorys
{
    public class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        private readonly SqlContext sqlContext;
          
        public RepositoryBase(SqlContext sqlContext)
        {
            this.sqlContext = sqlContext;
        }

        public void Add(T obj)
        {
            try
            {
                sqlContext.Set<T>().Add(obj);
                sqlContext.SaveChanges();
            }
            catch (DbUpdateException ex)
            {
                // Log the exception message and any relevant details
                Console.WriteLine("DbUpdateException: " + ex.Message);

                // Get the innermost exception
                Exception innerException = ex;
                while (innerException.InnerException != null)
                {
                    innerException = innerException.InnerException;
                }

                // Log or handle the inner exception
                Console.WriteLine("Inner Exception: " + innerException.Message);
                // Optionally, throw the original exception or a custom one
                throw;
            }
            catch (Exception ex)
            {
                // Log or handle other exceptions
                Console.WriteLine("An unexpected error occurred: " + ex.Message);
                // Optionally, throw the original exception or a custom one
                throw;
            }
        }

        public IEnumerable<T> GetAll()
        {
            return sqlContext.Set<T>().ToList();
        }

        public T GetById(long id)
        {
            return sqlContext.Set<T>().Find(id);
        }

        public void Remove(T obj)
        {
            try
            {
                sqlContext.Set<T>().Remove(obj);
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public void Update(T obj)
        {
            try
            {
                sqlContext.Entry(obj).State = EntityState.Modified;
                sqlContext.SaveChanges();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
