using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TodoCore.Models;

namespace TodoCore.Models
{
    public class Recipe
    {
        public Guid Id { get; set; }
        public bool IsDone { get; set; }
        [Required]
        public string Title { get; set; }
        public string Type { get; set; }
        public ICollection<Ingredients> Ingredients { get; set; }
    }


    public class Ingredients
    {
        public Guid Id { get; set; }
        public Recipe RecipeParent { get; set; }
        public string Units { get; set; }
        public double Quantity { get; set; }
        public bool IsUsed { get; set; }
        public string Title { get; set; }


        public Ingredients()
        {

        }

        public Ingredients(Recipe parent)
        {
            RecipeParent = parent;
        }


    }


    namespace MyBogusNS
    {
        public static class Extensions
        {
            public static bool IsAwesome(this Recipe item)
            {
                return true;
            }
        }
    }
}