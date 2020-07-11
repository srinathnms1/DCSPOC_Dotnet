namespace Fuel.Infrastructure.Repositories
{
    using DcsService.Core;
    using Microsoft.EntityFrameworkCore;
    using System.Linq;
    using System.Threading.Tasks;

    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly PostgresContext _postgresContext;

        public GenericRepository(PostgresContext postgresContext)
        {
            _postgresContext = postgresContext;
        }

        public IQueryable<TEntity> GetAll()
        {
            return _postgresContext.Set<TEntity>().AsNoTracking();
        }

        public async Task<TEntity> GetById(int id)
        {
            return await _postgresContext.Set<TEntity>()
                .AsNoTracking()
                .FirstOrDefaultAsync();
        }
    }
}
