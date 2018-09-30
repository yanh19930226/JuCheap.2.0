using AutoMapper;
using EntityFramework.Extensions;
using JuCheap.Core;
using JuCheap.Entity.Mall;
using JuCheap.Service.Abstracts.Mall.IServices;
using JuCheap.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Abstracts.Mall.Services
{
    public class StoreIndustriesService:ServiceBase<StoreIndustriesEntity>, IDependency, IStoreIndustriesService
    {
        //public Mehdime.Entity.IDbContextScopeFactory _dbScopeFactory { get; set; }
        //public bool Add(StoreIndustriesDto dto)
        //{
        //    using (var scope = _dbScopeFactory.Create())
        //    {
        //        var db = GetDb(scope);
        //        var dbSet = GetDbSet(db);
        //        var entity = Mapper.Map<StoreIndustriesDto, StoreIndustriesEntity>(dto);
        //        dbSet.Add(entity);
        //        var count = db.SaveChanges();
        //        return count > 0;
        //    }
        //}
        //public ResultDto<StoreIndustriesEntity> GetWithPages(QueryBase queryBase, Expression<Func<StoreIndustriesEntity, bool>> exp, string orderBy, string orderDir = "desc")
        //{
        //    using (var scope = _dbScopeFactory.CreateReadOnly())
        //    {
        //        var db = GetDb(scope);
        //        var dbSet = GetDbSet(db);
        //        var query = GetQuery(dbSet, exp, orderBy, orderDir);

        //        var query_count = query.FutureCount();
        //        var query_list = query.Skip(queryBase.Start).Take(queryBase.Length).Future();
        //        var list = query_list.ToList();

        //        var dto = new ResultDto<StoreIndustriesEntity>
        //        {
        //            recordsTotal = query_count.Value,
        //            data = list
        //        };
        //        return dto;
        //    }
        //}
    }
}
