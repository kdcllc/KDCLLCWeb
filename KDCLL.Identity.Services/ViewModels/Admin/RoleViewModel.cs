using System.ComponentModel.DataAnnotations;

namespace KDCLLC.Identity.Services.ViewModels.Admin
{
    public class RoleViewModel
    {
        public int Id { get; set; }

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "RoleName")]
        public string Name { get; set; }

        [Display(Name = "Role Description")]
        public string Description { get; set; }
    }
}
