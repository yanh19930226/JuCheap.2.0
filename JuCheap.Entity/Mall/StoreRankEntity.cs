using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JuCheap.Entity.Mall
{
    /// <summary>
    /// 店铺等级
    /// </summary>
    public class StoreRankEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 头像
        /// </summary>
        public string Avatar { get; set; }
        /// <summary>
        /// 诚信下限
        /// </summary>
        public int Honestieslower { get; set; }
        /// <summary>
        /// 诚信上限
        /// </summary>
        public int Honestiesupper { get; set; }
        /// <summary>
        /// 商品数量
        /// </summary>
        public int Productcount { get; set; }
    }
}