using System.Linq.Expressions;

namespace geometricBasic.Repositories.Contracts
{
    public interface IRepositoryBase<T>
    {
        IQueryable<T> GetAll();
        IQueryable<T> FindByCondition(Expression<Func<T, bool>> condition);
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
