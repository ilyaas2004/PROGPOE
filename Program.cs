using PROGPOE.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;


namespace PROGPOE
{
    internal class Program
    {
        static void Main(string[] args)
        {
            RecipeManager recipeManager = new RecipeManager();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display All Recipes");
                Console.WriteLine("3. Display Specific Recipe");
                Console.WriteLine("4. Scale Recipe");
                Console.WriteLine("5. Reset Quantities");
                Console.WriteLine("6. Clear All Data");
                Console.WriteLine("7. Exit");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            recipeManager.EnterRecipeDetails();
                            break;
                        case 2:
                            recipeManager.DisplayAllRecipes();
                            break;
                        case 3:
                            recipeManager.DisplaySpecificRecipe();
                            break;
                        case 4:
                            recipeManager.ScaleRecipe();
                            break;
                        case 5:
                            recipeManager.ResetQuantities();
                            break;
                        case 6:
                            recipeManager.ClearAllData();
                            break;
                        case 7:
                            Environment.Exit(0);
                            break;
                        default:
                            Console.WriteLine("Invalid choice! Please select again.");
                            break;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Invalid input! Please enter a valid number.");
                }
                catch (OverflowException)
                {
                    Console.WriteLine("Input value is too large or too small!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred: {ex.Message}");
                }
            }
        }
    }
}

