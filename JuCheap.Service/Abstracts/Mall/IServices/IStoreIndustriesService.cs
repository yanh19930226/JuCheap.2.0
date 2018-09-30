using JuCheap.Entity.Mall;
using JuCheap.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Abstracts.Mall.IServices
{
    public interface IStoreIndustriesService: IBaseService<StoreIndustriesEntity>
    {
        /// <summary>
        /// 添加店铺行业
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        //bool Add(StoreIndustriesDto StoreIndustries);
        /// <summary>
        /// 分页获取店铺行业列表
        /// </summary>
        /// <typeparam name="OrderKeyType"></typeparam>
        /// <param name="queryBase"></param>
        /// <param name="exp"></param>
        /// <param name="orderExp"></param>
        /// <param name="isDesc"></param>
        /// <returns></returns>
        //ResultDto<StoreIndustriesEntity> GetWithPages(QueryBase queryBase, Expression<Func<StoreIndustriesEntity, bool>> exp, string orderBy, string orderDir = "desc");
    }
}
