using System.ComponentModel.DataAnnotations;

namespace egdbooking_v2.Models.AccountViewModels
{
    public class ForgotPasswordViewModel
    {
        [Required]
        [EmailAddress]
        public string Email { get; set; }
    }
}
