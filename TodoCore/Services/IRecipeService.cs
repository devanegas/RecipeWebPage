using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Models;

namespace TodoCore.Services
{
    public interface IRecipeService
    {
        Task<Recipe[]> GetIncompleteRecipesAsync();
        Task<bool> AddRecipeAsync(Recipe newRecipe);
        Task<bool> MarkDoneAsync(Guid id);
        Task<bool> AddIngredientsAsync(Guid parentId, Ingredients ingredients);
        Task<bool> ToggleIngredientAsync(Guid id);
    }
}
