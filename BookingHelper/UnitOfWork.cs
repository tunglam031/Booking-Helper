using System.Collections.Generic;
using System.Linq;

namespace Excercise1
{
    internal class UnitOfWork : IUnitOfWork
    {
        public IQueryable<T> Query<T>()
        {
            return new List<T>().AsQueryable();
        }
    }
}