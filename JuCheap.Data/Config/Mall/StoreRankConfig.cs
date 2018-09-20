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
    public class StoreRankConfig : EntityTypeConfiguration<StoreRankEntity>
    {
        public StoreRankConfig()
        {
            ToTable("StoreRank");
            HasKey(item => item.Id);
            Property(item => item.Id).HasDatabaseGeneratedOption(DatabaseGeneratedOption.Identity);
            Property(item => item.Title).HasColumnType("varchar").IsRequired().HasMaxLength(100);
            Property(item => item.Avatar).HasColumnType("varchar").IsRequired();
            Property(item => item.Honestieslower).IsRequired();
            Property(item => item.Honestiesupper).IsRequired();
            Property(item => item.Productcount).IsRequired();
        }
    }
}
