using Microsoft.EntityFrameworkCore;
using StoreWebApp.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace StoreWebApp.EF.Repository
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        private ApplicationDbContext _db;
        public BaseRepository(ApplicationDbContext db)
        {
            _db = db;
        }
       

        public int complate()
        {
           
            return _db.SaveChanges();
        }
        public T AddData(T entity)
        {
            _db.Set<T>().Add(entity);
            return entity;
        }
        public T ModifyData(T entity)
        {
          
            _db.Set<T>().Update(entity);
            return entity;
        }
       
        public T RemoveData(T entity)
        {
            _db.Set<T>().Remove(entity);
             return entity;
        }

        public Task<T> GetByEmail(string email)
        {
            throw new NotImplementedException();
        }

        
        public async Task<T> GetByIdAsync(int id)
        {
            return await _db.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            var entity = _db.Set<T>().Find(id);

          
            _db.Entry(entity).State = EntityState.Detached;
            return entity;
        }
        public IEnumerable<T> GetAllAsync()
        {

            return _db.Set<T>().ToList();
        }

        public IEnumerable<T> GetAllAsyncWithJoin(string Name)
        {
            return _db.Set<T>().Include(Name).ToList();
        }
        public IEnumerable<T>GetEntities(Expression<Func<T, bool>> predicate = null)  
        {

            IQueryable<T> data = _db.Set<T>();
            if (predicate != null)
            {
                data = data.Where(predicate);
            }

            return data.ToList();

        }
        public T GetEntitie(Expression<Func<T, bool>> predicate = null)
        {

             var  data = _db.Set<T>();
            if (predicate != null)
            {
               var result = data.Where(predicate).FirstOrDefault();
                return result;
            }
            else
                return null;


        }


    }
}
