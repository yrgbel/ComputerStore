using System.ComponentModel.DataAnnotations;

namespace Store.Web.Mvc.Client.Areas.Auth.ViewModels
{
    public class LoginModel
    {
        [Display(Name = "Email *")]
        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid Email")]
        public string Email { get; set; }

        [Display(Name = "Password *")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Password is required")]
        [StringLength(50, MinimumLength = 5, ErrorMessage = "Min password length is 5 characters")]
        public string Password { get; set; }

        public bool RememberMe { get; set; }
    }
}