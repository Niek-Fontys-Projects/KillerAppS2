using DataAccessLayer.Repository;
using ModelLayer.Structural_Interfaces;
using ServiceLayer.ViewModels.OutputViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace ServiceLayer.Handlers
{
    public class CategoryHandler
    {
        private readonly ICategoryRepo categoryRepo;
        public CategoryHandler()
        {
            categoryRepo = new CategoryRepository();
        }

        public CatrgoriesModel GetAllCategories()
        {
            return new CatrgoriesModel()
            {
                Categories = categoryRepo.GetAllCategories()
            };
        }
    }
}
