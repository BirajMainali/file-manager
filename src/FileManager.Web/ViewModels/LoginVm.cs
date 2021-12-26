using System.ComponentModel.DataAnnotations;

namespace FileManager.Web.ViewModels
{
    public class LoginVm
    {
        [Required] public string Email { get; set; }

        [Required] public string Password { get; set; }
    }
}