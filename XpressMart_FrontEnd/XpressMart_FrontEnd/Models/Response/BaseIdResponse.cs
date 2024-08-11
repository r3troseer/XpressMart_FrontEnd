using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart_FrontEnd.Models.Response
{
    public class BaseIdResponse<TKey>
    {
        public TKey Id { get; set; }
    }
}
