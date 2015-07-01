using System.ComponentModel.DataAnnotations;

namespace KDCLLC.Identity.Services.ViewModels.Account
{
    public class ExternalLoginConfirmationViewModel
    {
        [Required]
        [Display(Name = "Email")]
        public string Email { get; set; }

        public string UserName { get; set; }

    }
}
