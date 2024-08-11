using System.ComponentModel.DataAnnotations;

namespace XpressMart_FrontEnd.Models.Auth
{
    public class ChangePasswordModel : LoginModel
    {
        [Required]
        [StringLength(50, MinimumLength = 5)]
        public string NewPassword { get; set; }
    }
}
