using System.ComponentModel.DataAnnotations;

namespace GameOnlineShop.ViewModels
{
    public class LoginViewModel
    {
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [Display(Name = "Remember Me?")]
        public bool RememberMe { get; set; }

        public string ReturnUrl { get; set; }
    }
}

/*
 
InvalidOperationException: Unable to resolve service for type 'Microsoft.AspNetCore.Identity.UserManager`1[GameOnlineShop.Data.Models.User]' 
while attempting to activate 'Controller'.
 
 */
