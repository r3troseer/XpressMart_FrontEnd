using Microsoft.AspNetCore.Identity;

namespace XpressMart_FrontEnd.Models.Entities
{
    public class ApplicationUser : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public virtual Customer Customer { get; set; }
    }
}
