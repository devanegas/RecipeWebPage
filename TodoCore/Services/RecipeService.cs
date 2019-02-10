using Microsoft.EntityFrameworkCore;
using TodoCore.Models.MyBogusNS;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Data;
using TodoCore.Models;

namespace TodoCore.Services
{
    public class RecipeService : IRecipeService
    {
        private readonly ApplicationDbContext _context;

        public RecipeService(ApplicationDbContext dbContext)
        {
            _context = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public async Task<bool> AddRecipeAsync(Recipe newRecipe)
        {
            newRecipe.Id = Guid.NewGuid();
            newRecipe.IsDone = false;

            _context.Recipes.Add(newRecipe);

            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);
        }

        public async Task<bool> AddIngredientsAsync(Guid parentId, Ingredients ingredients)
        {
            var parent = _context.Recipes.Single(x => x.Id == parentId);
            ingredients.RecipeParent = parent;
            ingredients.IsUsed = false;

            //if (ingredients.Quantity == 0)
            //    return false;

            _context.Ingredients.Add(ingredients);

            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);
        }

        public Task<Recipe[]> GetIncompleteRecipesAsync()
        {
            return _context.Recipes
                .Where(i => i.IsDone == false)
                .Include(i => i.Ingredients)
                .ToArrayAsync();
        }

        public async Task<bool> MarkDoneAsync(Guid id)
        {
            var recipe = await _context.Recipes.Where(x => x.Id == id)
                .SingleOrDefaultAsync();

            if (recipe == null)
            {
                return false;
            }

            recipe.IsDone = true;

            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);
        }

        public async Task<bool> ToggleIngredientAsync(Guid id)
        {
            var ingredient = await _context.Ingredients.Where(i => i.Id == id).SingleOrDefaultAsync();
            if (ingredient == null)
                return false;

            ingredient.IsUsed = !ingredient.IsUsed;
            var saveResult = await _context.SaveChangesAsync();
            return (saveResult == 1);

        }
    }
}
