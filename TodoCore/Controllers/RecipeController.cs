using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TodoCore.Services;
using TodoCore.Models;

namespace TodoCore.Controllers
{
    public class RecipeController : Controller
    {
        private readonly IRecipeService recipeService;

        public RecipeController(IRecipeService recipeService)
        {
            this.recipeService = recipeService;
        }

        public async Task<IActionResult> Index()
        {
            var recipes = await recipeService.GetIncompleteRecipesAsync();
            var model = new RecipeViewModel(recipes);
            return View(model);
        }

        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecipe(Recipe newRecipe)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");


            var successful = await recipeService.AddRecipeAsync(newRecipe);
            if (!successful)
                return BadRequest("Could not add recipe");
            return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddIngredient(Guid id, Ingredients newIngredient)
        {
            if (!ModelState.IsValid)
                return RedirectToAction("Index");

            if (newIngredient.Quantity <= 0 || newIngredient.Title == null)
                return RedirectToAction("Index");


            var successful = await recipeService.AddIngredientsAsync(id, newIngredient);
            if (!successful)
                return BadRequest("Could not add ingredient");
            return RedirectToAction("Index");
        }


        [ValidateAntiForgeryToken]
        public async Task<IActionResult> MarkDone(Guid id)
        {
            if(id==Guid.Empty)
            {
                return RedirectToAction("Index");
            }

            var successful = await recipeService.MarkDoneAsync(id);
            if (!successful)
                return BadRequest("Could not mark item as done.");
            return RedirectToAction("Index");
        }
    }
}