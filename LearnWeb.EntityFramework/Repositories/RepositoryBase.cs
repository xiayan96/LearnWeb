using Microsoft.EntityFrameworkCore;
using Sample.GameManagement.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LearnWeb.EntityFramework.Repositories
{
    internal class RepositoryBase<T> : IRepositoryBase<T> where T : class
    {
        protected GameManagementDbContext GameDbContext { get; set; }

        protected RepositoryBase(GameManagementDbContext repositoryContext)
        {
            GameDbContext = repositoryContext;
        }

        public IQueryable<T> FindAll()
        {
            return GameDbContext.Set<T>().AsNoTracking();
        }

        public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression)
        {
            return GameDbContext.Set<T>().Where(expression).AsNoTracking();
        }

        public void Create(T entity)
        {
            GameDbContext.Set<T>().Add(entity);
        }

        public void Update(T entity)
        {
            GameDbContext.Set<T>().Update(entity);
        }

        public void Delete(T entity)
        {
            GameDbContext.Set<T>().Remove(entity);
        }
    }
}
