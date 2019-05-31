using ModelLayer.General_Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ServiceLayer.ViewModels.OutputViewModels
{
    public class RiddlesResultModel
    {
        public IEnumerable<IRiddle> Riddles { get; internal set; }
    }
}
