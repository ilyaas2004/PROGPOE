using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class RecipeManager
    {
        private List<recipeItems> recipes = new List<recipeItems>();
        public delegate void CalorieNotification(string message);
        public event CalorieNotification OnCaloriesExceed;

        public RecipeManager()
        {
            OnCaloriesExceed += NotifyCaloriesExceed;
        }

        public void EnterRecipeDetails()
        {
            recipeItems recipe = new recipeItems();

            Console.Write("Enter the recipe name: ");
            recipe.Name = Console.ReadLine();

            string Ingname;
            decimal Ingquantity;
            string Ingunit;
            int calories;
            string foodGroup;

            try
            {
                Console.WriteLine("Please enter the amount of ingredients:");
                int numOfIngredients = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfIngredients; i++)
                {
                    Console.WriteLine($"Enter details for ingredient {i + 1}:");
                    Console.Write("Name: ");
                    Ingname = Console.ReadLine();

                    Console.Write("Quantity: ");
                    Ingquantity = decimal.Parse(Console.ReadLine());

                    Console.Write("Unit of Measurement: ");
                    Ingunit = Console.ReadLine();

                    Console.Write("Calories: ");
                    calories = int.Parse(Console.ReadLine());

                    Console.Write("Food Group: ");
                    foodGroup = Console.ReadLine();

                    recipe.Ingredients.Add(new Ingredient(Ingname, Ingquantity, Ingunit, calories, foodGroup));
                }

                Console.WriteLine("Enter the number of steps:");
                int numOfSteps = int.Parse(Console.ReadLine());

                for (int i = 0; i < numOfSteps; i++)
                {
                    Console.WriteLine($"Enter step {i + 1}:");
                    recipe.Steps.Add(Console.ReadLine());
                }

                recipes.Add(recipe);
                recipes = recipes.OrderBy(r => r.Name).ToList(); // Keep recipes sorted alphabetically
                Console.WriteLine("Recipe details entered successfully!");

                if (recipe.CalculateTotalCalories() > 300)
                {
                    OnCaloriesExceed?.Invoke($"The recipe '{recipe.Name}' exceeds 300 calories!");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format! Please enter a valid number.");
            }
            catch (OverflowException)
            {
                Console.WriteLine("Input value is too large or too small!");
            }
        }

        public void DisplayAllRecipes()
        {
            Console.WriteLine("\nAll Recipes:");
            foreach (var recipe in recipes)
            {
                Console.WriteLine(recipe.Name);
            }
        }

        public void DisplaySpecificRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to display:");
            string recipeName = Console.ReadLine();

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

        public void ScaleRecipe()
        {
            Console.WriteLine("Enter the name of the recipe to scale:");
            string recipeName = Console.ReadLine();

            var recipe = recipes.FirstOrDefault(r => r.Name.Equals(recipeName, StringComparison.OrdinalIgnoreCase));
            if (recipe != null)
            {
                try
                {
                    Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
                    decimal factor = decimal.Parse(Console.ReadLine());
                    recipe.ScaleRecipe(factor);
                    Console.WriteLine($"Recipe scaled by a factor of {factor}");
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format! Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input value is too large or too small!");
                }
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

        private void NotifyCaloriesExceed(string message)
        {
            Console.WriteLine(message);
        }
    }
}

