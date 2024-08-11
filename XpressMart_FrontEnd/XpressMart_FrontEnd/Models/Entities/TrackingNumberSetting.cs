using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class TrackingNumberSetting : BaseEntity<int>
    {
        public int LastSequentialNumber { get; set; }
    }
}
