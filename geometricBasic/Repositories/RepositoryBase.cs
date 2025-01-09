using geometricBasic.Repositories.Contracts;
using System.Linq.Expressions;

namespace geometricBasic.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T>
        where T : class
    {
        protected readonly AppDbContext _context;

        public RepositoryBase(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Create(T entity) => _context.Set<T>().Add(entity);

        public void Delete(T entity) => _context.Set<T>().Remove(entity);

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition) => _context.Set<T>().Where(condition);

        public IQueryable<T> GetAll() => _context.Set<T>();

        public void Update(T entity) => _context.Set<T>().Update(entity);
    }
}
