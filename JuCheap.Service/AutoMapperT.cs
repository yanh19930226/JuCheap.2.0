using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service
{
    public static class AutoMapperT
    {
        /// <summary>
        /// 集合对集合的转换
        /// </summary>
        /// <typeparam name="TSource">源类型</typeparam>
        /// <typeparam name="TResult">结果类型</typeparam>
        /// <param name="self">数据</param>
        /// <returns></returns>
        public static IEnumerable<TResult> MapTo<TSource, TResult>(this IEnumerable<TSource> self)
        {
            if (self == null)
                throw new ArgumentNullException();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(typeof(TSource), typeof(TResult));
            });
            return config.CreateMapper().Map<IEnumerable<TSource>, IEnumerable<TResult>>(self);
        }

        /// <summary>
        /// 对象对对象
        /// </summary>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="self"></param>
        /// <returns></returns>
        public static TResult MapTo<TResult>(this object self)
        {
            if (self == null)
                throw new ArgumentNullException();
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap(self.GetType(), typeof(TResult));
            });
            return (TResult)config.CreateMapper().Map(self, self.GetType(), typeof(TResult));
        }
    }
}
