using System.ComponentModel.DataAnnotations;

namespace ServiceLayer.InputViewModels
{
    public class AddUserModel
    {
        [Required(ErrorMessage = "UserName is required"), Display(Name = "Username", Prompt = "Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required"), Display(Name = "Password", Prompt = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
        [Required(ErrorMessage = "Email is required"), Display(Name = "Email", Prompt = "Email"), DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}
