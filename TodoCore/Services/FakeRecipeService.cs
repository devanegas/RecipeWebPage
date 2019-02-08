using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Services;
using TodoCore.Models;

namespace TodoCore.Services
{
    public class FakeRecipeService : IRecipeService
    {
        public Task<bool> AddRecipeAsync(Recipe recipe)
        {
            throw new NotImplementedException();
        }

        public Task<bool> AddIngredientsAsync(Guid parentId, Ingredients ingredients)
        {
            throw new NotImplementedException();
        }

        public Task<Recipe[]> GetIncompleteRecipesAsync()
        {
            var item1 = new Recipe
            {
                Title = "Water"
            };

            var item2 = new Recipe
            {
                Title = "Eggs",
            };

            return Task.FromResult(new[] { item1, item2 });
        }

        public Task<bool> MarkDoneAsync(Guid id)
        {
            throw new NotImplementedException();
        }


        public Task<bool> ToggleIngredientAsync(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
 