using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.InputViewModels
{
    public class LogInModel
    {
        [Required(ErrorMessage = "UserName is required"), Display(Name ="Username", Prompt ="Username")]
        public string Username { get; set; }
        [Required(ErrorMessage = "Password is required"), Display(Name = "Password", Prompt = "Password"), DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
