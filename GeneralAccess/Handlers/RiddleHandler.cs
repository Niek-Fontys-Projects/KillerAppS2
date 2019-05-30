using DataAccessLayer.Repository;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Handlers
{
    public class RiddleHandler
    {
        IRiddleRepo riddleRepo;
        public RiddleHandler()
        {
            riddleRepo = new RiddleRepository();
        }

        public RiddlesResultModel GetRiddlesFromCategory(string _category)
        {
            return new RiddlesResultModel() { Riddles = riddleRepo.GetRiddlesByCategory(_category) };
        }
    }
}
