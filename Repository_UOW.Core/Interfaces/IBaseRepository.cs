using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository_UOW.Core.Interfaces
{
    public interface IBaseRepository<T> where T : class
    {
        T GetById(int id);
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAll();
        Task<T> Find(Expression<Func<T, bool>> match);
        IEnumerable<T> Find(Expression<Func<T, bool>> match, string[] includes);
        IEnumerable<T> Find(Expression<Func<T, bool>> match, string[] includes, int skip, int take);
    }
}
