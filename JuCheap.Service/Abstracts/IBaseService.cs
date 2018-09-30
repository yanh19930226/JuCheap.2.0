using JuCheap.Service.Dto;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Abstracts
{
    public interface IBaseService<T>  where T:class
    {
        IQueryable<T> GetQuery<OrderKeyType>(DbSet<T> dbSet, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true);
        IQueryable<T> GetQuery(DbSet<T> dbSet, Expression<Func<T, bool>> exp,
            string orderBy, string orderDir);
        IQueryable<T> GetQuery<IncludeKeyType, OrderKeyType>(DbSet<T> dbSet, Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true);
        IQueryable<T> GetQuery<IncludeKeyType>(DbSet<T> dbSet, Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            string orderBy, string orderDir);
        T GetOne(Expression<Func<T, bool>> exp);
        ResultDto<T> GetWithPages(QueryBase queryBase, Expression<Func<T, bool>> exp, string orderBy, string orderDir = "desc");
        bool Add(T entity);
        bool Add(List<T> entities);
        bool Update(T entity);
        bool Update(IEnumerable<T> entities);
        bool Delete(Expression<Func<T, bool>> exp);
    }
}
