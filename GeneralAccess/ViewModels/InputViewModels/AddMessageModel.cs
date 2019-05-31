using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ViewModels.InputViewModels
{
    public class AddMessageModel
    {
        [Required(ErrorMessage ="Please enter a message"), Display(Name ="message", Prompt ="Message"), DataType(DataType.MultilineText)]
        public string Message { get; set; }
        [Required]
        public string RiddleName { get; set; }
        [Required]
        public string UserID { get; set; }
        [Required]
        public DateTime Time { get; set; }
    }
}
