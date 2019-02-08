using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoCore.Models
{
    public class RecipeViewModel
    {
        public RecipeViewModel(IEnumerable<Recipe> recipes)
        {
           Recipes  = recipes ?? throw new ArgumentNullException(nameof(recipes));
        }
        public IEnumerable<Recipe> Recipes { get; private set; }
    }
}
