using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuCheap.Service.Dto
{
    public class StoreIndustriesDto : BaseDto
    {
        /// <summary>
        /// 标题
        /// </summary>
        [Required, DisplayName("标题"), MinLength(2), MaxLength(20)]
        public string Title { get; set; }
        public int Displayorder { get; set; }
    }
}
