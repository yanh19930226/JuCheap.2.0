using JuCheap.Core;
using JuCheap.Entity.Mall;
using JuCheap.Service.Abstracts.Mall.IServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Abstracts.Mall.Services
{
    public class StoreRankService : ServiceBase<StoreRankEntity>, IDependency, IStoreRankService
    {
    }
}
