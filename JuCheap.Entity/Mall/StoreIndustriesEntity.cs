using JuCheap.Entity.Base;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace JuCheap.Entity.Mall
{
    //店铺行业表
    public class StoreIndustriesEntity : BaseEntity
    {
        /// <summary>
        /// 标题
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 排序
        /// </summary>
        public int Displayorder { get; set; }
    }
}