
/*******************************************************************************
* Copyright (C)  JuCheap.Com
* 
* Author: dj.wong
* Create Date: 02/17/2016 17:07:54
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/

using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Linq.Expressions;
using EntityFramework.Extensions;
using JuCheap.Core.Extentions;
using JuCheap.Data;
using JuCheap.Service.Dto;
using Mehdime.Entity;

namespace JuCheap.Service.Abstracts
{
    public abstract class ServiceBase<T> where T: class
    {
        public IDbContextScopeFactory _dbScopeFactory { get; set; }

        #region Private
        /// <summary>
        /// 获取DB
        /// </summary>
        /// <param name="scope">上下文</param>
        /// <returns></returns>
	    public DbContext GetDb(IDbContextScope scope)
        {
            return scope.DbContexts.Get<JuCheapContext>();
        }

        /// <summary>
        /// 获取只读DB
        /// </summary>
        /// <param name="scope">上下文</param>
        /// <returns></returns>
        public DbContext GetDb(IDbContextReadOnlyScope scope)
        {
            return scope.DbContexts.Get<JuCheapContext>();
        }

        /// <summary>
        /// 获取DbSet
        /// </summary>
        /// <param name="db"></param>
        /// <returns></returns>
	    public DbSet<T> GetDbSet(DbContext db)
        {
            return db.Set<T>();
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="OrderKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<OrderKeyType>(DbSet<T> dbSet, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var query = dbSet.AsNoTracking().OrderByDescending(orderExp).Where(exp);
            if (!isDesc)
                query = dbSet.AsNoTracking().OrderBy(orderExp).Where(exp);
            return query;
        }

        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="exp"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery(DbSet<T> dbSet, Expression<Func<T, bool>> exp,
            string orderBy, string orderDir)
        {
            var query = dbSet.AsNoTracking().OrderBy(orderBy, orderDir).Where(exp);
            return query;
        }
        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="OrderKeyType"></typeparam>
        /// <typeparam name="IncludeKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="includeExp"></param>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<IncludeKeyType, OrderKeyType>(DbSet<T> dbSet, Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            Expression<Func<T, OrderKeyType>> orderExp, bool isDesc = true)
        {
            var query = dbSet.AsNoTracking().Include(includeExp).OrderByDescending(orderExp).Where(exp);
            if (!isDesc)
            {
                query = dbSet.AsNoTracking().Include(includeExp).OrderBy(orderExp).Where(exp);
            }
            return query;
        }
        /// <summary>
        /// 获取IQueryable对象
        /// </summary>
        /// <typeparam name="IncludeKeyType"></typeparam>
        /// <param name="dbSet"></param>
        /// <param name="includeExp"></param>
        /// <param name="exp"></param>
        /// <param name="orderBy"></param>
        /// <param name="orderDir"></param>
        /// <returns></returns>
        public IQueryable<T> GetQuery<IncludeKeyType>(DbSet<T> dbSet, Expression<Func<T, IncludeKeyType>> includeExp, Expression<Func<T, bool>> exp,
            string orderBy, string orderDir)
        {
            var query = dbSet.AsNoTracking().Include(includeExp).OrderBy(orderBy, orderDir).Where(exp);
            return query;
        }
        /// <summary>
        /// 获取单条数据
        /// </summary>
        /// <param name="exp"></param>
        /// <returns></returns>
        public T GetOne(Expression<Func<T, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbset = GetDbSet(db);
                var entity = dbset.AsNoTracking().FirstOrDefault(exp);
                return entity;
            }
        }
        public ResultDto<T> GetWithPages(QueryBase queryBase, Expression<Func<T, bool>> exp, string orderBy, string orderDir = "desc")
        {
            using (var scope = _dbScopeFactory.CreateReadOnly())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var query = GetQuery(dbSet, exp, orderBy, orderDir);

                var query_count = query.FutureCount();
                var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
                var list = query_list.ToList();

                var dto = new ResultDto<T>
                {
                    recordsTotal = query_count.Value,
                    data = list
                };
                return dto;
            }
        }
        public bool Add(T entity)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbset = GetDbSet(db);
                dbset.Add(entity);
                var count = db.SaveChanges();
                return count > 0;
            }
        }
        public bool Add(List<T> entities)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.AddRange(entities);
                return db.SaveChanges() > 0;
            }
        }
        public bool Update(T entity)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbset = GetDbSet(db);
                dbset.AddOrUpdate(entity);
                return db.SaveChanges() > 0;
            }
        }
        public bool Update(IEnumerable<T> entities)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                dbSet.AddOrUpdate(entities.ToArray());
                return db.SaveChanges() > 0;
            }
        }
        public bool Delete(Expression<Func<T, bool>> exp)
        {
            using (var scope = _dbScopeFactory.Create())
            {
                var db = GetDb(scope);
                var dbSet = GetDbSet(db);
                var models = dbSet.Where(exp);
                dbSet.RemoveRange(models);
                return db.SaveChanges() > 0;
            }
        }
        #endregion
    }
}
