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

        internal CategoryHandler(ICategoryRepo _categoryRepo)
        {
            categoryRepo = _categoryRepo;
        }

        public CategoriesModel GetAllCategories()
        {
            return new CategoriesModel()
            {
                Categories = categoryRepo.GetAllCategories()
            };
        }
    }
}
