using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XpressMart_FrontEnd.Models.Request;

namespace XpressMart_FrontEnd.Models.Request.CategoryRequest
{
    public class CategoryUpdateRequestModel : BaseRequest<int>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
