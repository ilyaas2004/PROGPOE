using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROGPOE.Classes
{
    internal class recipeItems
    {
        private List<Ingredient> ingredients = new List<Ingredient>();
        private List<string> steps = new List<string>();
        private int numOfIngredients;
        private int numOfSteps;
        private decimal factor;
        
        public void EnterRecipeDetails()
        {
            string Ingname;
            decimal Ingquantity;
            string Ingunit;

            try
            {
                Console.WriteLine("please Enter the amount of ingredients:");
                numOfIngredients = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("your value is invalid, Please enter a numeric value such as 5 or 2.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("your value is too large or too small");
                return;
            }

            for (int i = 0; i < numOfIngredients; i++)
            {
                Console.WriteLine($"Enter the  details for your ingredient {i + 1}:");
                Console.Write("Name: ");
                Ingname = Console.ReadLine();

                try
                {
                    Console.Write("Quantity: ");
                    Ingquantity = decimal.Parse(Console.ReadLine());

                    Console.Write("Unit of Measurement: ");
                    Ingunit = Console.ReadLine();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input format, Please enter a valid number.");
                    return;
                }
                catch (OverflowException)
                {
                    Console.WriteLine("your value is too large or too small");
                    return;
                }

                ingredients.Add(new Ingredient(Ingname, Ingquantity, Ingunit));
            }

            try
            {
                Console.WriteLine("Enter the number of steps:");
                numOfSteps = int.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input format, Please enter a valid number.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("your  value is too large or too small");
                return;
            }

            for (int i = 0; i < numOfSteps; i++)
            {
                string step;

                Console.WriteLine($"Enter step {i + 1}:");
                step = Console.ReadLine();
                steps.Add(step);
            }

            Console.WriteLine("Recipe details captured successfully!");
        }

        public void DisplayRecipe()
        {
            Console.WriteLine("\nRecipe:");
            Console.WriteLine("Ingredients:");

            foreach (var ingredient in ingredients)
            {
                Console.WriteLine($"{ingredient.Quantity} {ingredient.Unit} of {ingredient.Name}");
            }

            Console.WriteLine("\nSteps:");
            for (int i = 0; i < steps.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {steps[i]}");
            }
        }

        public void ScaleRecipe()
        {
            try
            {
                Console.WriteLine("Enter the scaling factor (0.5, 2, or 3):");
                factor = decimal.Parse(Console.ReadLine());
            }
            catch (FormatException)
            {
                Console.WriteLine("your value is invalid, Please enter a valid number.");
                return;
            }
            catch (OverflowException)
            {
                Console.WriteLine("your  value is too large or too small");
                return;
            }

            foreach (var ingredient in ingredients)
            {
                ingredient.Quantity *= factor;
            }

            Console.WriteLine($"Your Recipe has been scaled by a factor of {factor}");
        }

        public void ResetQuantities()
        {
            foreach (var ingredient in ingredients)
            {
                ingredient.ResetQuantity();
            }

            Console.WriteLine("Quantities reverted to original values.");
        }

        public void ClearData()
        {
            ingredients.Clear();
            steps.Clear();
            Console.WriteLine("All data has been cleared.");
        }
    }

   
    }



