using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KDCLLC.Web.Models.ViewModels
{
    public class SignupViewModel
    {
        [Required]
        //[DisplayName("First Name")] //don't have to use this because HumanizedLabels.Register(); is used
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        [DisplayFormat(DataFormatString = "d/M/yyyy", ApplyFormatInEditMode = true)]
        public DateTime DateOfBirth { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string EmailAddress { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        public MembershipType MembershipType { get; set; }

        [DataType(DataType.Url)]
        public string Homepage { get; set; }
        [DataType(DataType.MultilineText)]
        public string Bio { get; set; }

        [Required]
        public bool TermsAndConditions { get; set; }
    }

    public enum MembershipType
    {
        Standard,
        Bonze,
        Silver,
        Gold,
        Platinum
    }
}
