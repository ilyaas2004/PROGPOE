using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    public  class Recipe
    {
        public string Name { get; set; }
        public List<Ingredient> Ingredients { get; set; } = new List<Ingredient>();
        public List<string> Steps { get; set; } = new List<string>();
        private decimal factor;

        public void DisplayRecipe()
        {
            Console.WriteLine($"\nRecipe: {Name}");
            Console.WriteLine("Ingredients:");
            foreach (var ingredient in Ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}, {ingredient.Calories} calories, Food Group: {ingredient.FoodGroup}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < Steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {Steps[i]}");
            }
            Console.WriteLine($"Total Calories: {CalculateTotalCalories()}");
        }

        public void ScaleRecipe(decimal scaleFactor)
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.Quantity *= scaleFactor;
            }
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in Ingredients)
            {
                ingredient.ResetQuantity();
            }
        }

        public int CalculateTotalCalories()
        {
            return Ingredients.Sum(ingredient => ingredient.Calories);
        }
    }

   
    }



