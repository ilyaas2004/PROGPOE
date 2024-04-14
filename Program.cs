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
            recipeItems recipe = new recipeItems();

            while (true)
            {
                Console.WriteLine("Select an option:");
                Console.WriteLine("1. Enter Recipe Details");
                Console.WriteLine("2. Display Recipe");
                Console.WriteLine("3. Scale Recipe");
                Console.WriteLine("4. Reset Quantities");
                Console.WriteLine("5. Clear All Data");
                Console.WriteLine("6. Exit");

                try
                {
                    int choice = int.Parse(Console.ReadLine());

                    switch (choice)
                    {
                        case 1:
                            recipe.EnterRecipeDetails();
                            break;
                        case 2:
                            recipe.DisplayRecipe();
                            break;
                        case 3:
                            recipe.ScaleRecipe();
                            break;
                        case 4:
                            recipe.ResetQuantities();
                            break;
                        case 5:
                            recipe.ClearAllData();
                            break;
                        case 6:
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

