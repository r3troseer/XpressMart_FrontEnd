using System.ComponentModel.DataAnnotations;

namespace XpressMart_FrontEnd.Models.Request
{
    public abstract class BaseRequest<TKey>
    {
        public TKey Id { get; set; }
    }
}
