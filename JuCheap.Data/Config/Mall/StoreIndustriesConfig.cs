/*******************************************************************************
* Copyright (C) JuCheap.Com
* 
* Author: dj.wong
* Create Date: 09/04/2015 11:47:14
* Description: Automated building by service@JuCheap.com 
* 
* Revision History:
* Date         Author               Description
*
*********************************************************************************/
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using JuCheap.Entity;
using JuCheap.Entity.Mall;

namespace JuCheap.Data.Config
{
    /// <summary>
    /// 店铺等级表配置
    /// </summary>
    public class StoreIndustriesConfig : EntityTypeConfiguration<StoreIndustriesEntity>
    {
        /// <summary>
        /// 店铺行业表配置
        /// </summary>
        public StoreIndustriesConfig()
        {
            ToTable("StoreIndustries");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Title).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            Property(item => item.Displayorder).IsRequired();
        }
    }
}
