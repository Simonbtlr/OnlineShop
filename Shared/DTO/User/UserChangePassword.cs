using System.ComponentModel.DataAnnotations;

namespace OnlineShop.Shared.DTO.User;

public class UserChangePassword
{
    [Required, StringLength(100, MinimumLength = 6)]
    public string Password { get; set; } = string.Empty;
    [Compare("Password", ErrorMessage = "Пароли не совпадают.")]
    public string ConfirmPassword { get; set; } = string.Empty;
}