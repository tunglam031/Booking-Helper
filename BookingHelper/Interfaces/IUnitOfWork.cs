using System.Linq;

namespace Excercise1
{
    public interface IUnitOfWork
    {
        IQueryable<T> Query<T>();
    }
}