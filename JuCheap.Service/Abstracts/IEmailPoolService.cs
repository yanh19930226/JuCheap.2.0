using System.Collections.Generic;
using JuCheap.Service.Dto;

namespace JuCheap.Service.Abstracts
{
    public partial interface IEmailPoolService
    {
        /// <summary>
        /// 获取指定数量的待发送邮件
        /// </summary>
        /// <param name="top"></param>
        /// <returns></returns>
        List<EmailPoolDto> GetWithReceivers(int top);
    }
}
