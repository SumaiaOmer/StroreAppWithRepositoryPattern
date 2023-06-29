using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebApp.Core.Interface
{
  public  interface IBaseRepository<T> where T : class
    {

        Task<T> GetByIdAsync(int id);
        T GetById(int id);
        Task<T> GetByEmail(string email);
        T ModifyData(T entity);
        IEnumerable<T> GetAllAsync();
        IEnumerable<T> GetAllAsyncWithJoin(string Name);
        T AddData(T entity);
        T RemoveData(T entity);
        int complate();
        IEnumerable<T> GetEntities(Expression<Func<T, bool>> predicate = null);
        T GetEntitie(Expression<Func<T, bool>> predicate = null);
    }
}
