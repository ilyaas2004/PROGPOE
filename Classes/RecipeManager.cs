using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PROGPOE.Classes;

namespace PROGPOE.Classes
{
    public class RecipeManager
    {
        private List<Recipe> recipes = new List<Recipe>();
        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnCaloriesExceed;

        public RecipeManager()
        {
            OnCaloriesExceed += NotifyCaloriesExceed;
        }

        private void NotifyCaloriesExceed(string message)
        {
            Console.WriteLine(message); // Example: Output to console
            // You can add more logic here as needed
        }

        public void AddRecipe(string recipeName, List<Ingredient> ingredients)
        {
            Recipe recipe = new Recipe { Name = recipeName, Ingredients = ingredients };
            recipes.Add(recipe);
            recipes = recipes.OrderBy(r => r.Name).ToList(); // Keep recipes sorted alphabetically
        }

        public List<Recipe> GetRecipes()
        {
            return recipes;
        }

        public void DisplayAllRecipes()
        {
            Console.WriteLine("\nAll Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplaySpecificRecipe(string recipeName)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.DisplayRecipe();
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        public void ScaleRecipe(string recipeName, decimal factor)
        {
            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                recipe.ScaleRecipe(factor);
                Console.WriteLine($"Recipe scaled by a factor of {factor}");
            }
            else
            {
                Console.WriteLine("Recipe not found!");
            }
        }

        public void ResetQuantities()
        {
            foreach (var recipe in recipes)
            {
                recipe.ResetQuantities();
            }
            Console.WriteLine("Quantities reset to original values.");
        }

        public void ClearAllData()
        {
            recipes.Clear();
            Console.WriteLine("All data cleared.");
        }
    }
}