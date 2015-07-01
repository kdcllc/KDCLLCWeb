using System.ComponentModel.DataAnnotations;

namespace KDCLLC.Identity.Services.ViewModels.Account
{
    public class ForgotViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }
    }
}
