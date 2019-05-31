using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ViewModels.InputViewModels
{
    public class AddMessageModel
    {
        [Required(ErrorMessage ="Please enter a message"), Display(Name ="Message", Prompt ="Message"), DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Required(ErrorMessage ="Enter the riddle name you would like to reply to"), Display(Name ="RiddleName", Prompt ="RiddleName")]
        public string RiddleName { get; set; }
        [Required]
        public string UserID { get; set; }
    }
}
