using _01_KCafe;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Menu_Repository_ConcoleUI.UI
{
    public class ProgramUI
    {
        private readonly Menu_Repository _menuRepo = new Menu_Repository();
        private IConsole _console;
        public ProgramUI(IConsole console)
        {
            _console = console;
        }
        public void Run() //method to start ProgramUI
        {
            SeedContent();
            RunMenu();
        }
        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                _console.Clear();
                _console.WriteLine("Select an option number:\n" +
                    "1. Show all meals\n" +
                    "2. Add a meal\n" +
                    "3. Remove a meal\n" +
                    "4. Exit");
                string userInput = _console.ReadLine();
                userInput = userInput.Replace(" ", "");
                userInput = userInput.Trim();
                switch (userInput)
                {
                    case "1":
                        //--Show All Meals
                        GetAllMeal();
                        break;
                    case "2":
                        //--Add meal
                        AddNewMeal();
                        break;
                    case "3":
                        //--Delete meal
                        DeleteMeal();
                        break;
                    case "4":
                        //--Exit
                        continueToRun = false;
                        break;
                    default:
                        break;
                }
            }
        }
        private void AddNewMeal()
        {
            Meal content = new Meal();
            _console.WriteLine("Hello there, please enter a name");
            content.MealName = _console.ReadLine();

            _console.WriteLine("Now, add a description");
            content.Description = _console.ReadLine();

            _console.WriteLine("What is the meal number");
            content.MealNumber = Convert.ToInt32(_console.ReadLine());

            _console.WriteLine("What is the meal price");
            content.Price = Convert.ToDecimal(_console.ReadLine());

            _console.WriteLine("Last step! What are the ingredients");
            content.Ingredients = _console.ReadLine();
            _menuRepo.AddMealToMenu(content);
            _console.WriteLine("Your meal has been added! Press any key to return to the main menu");
            _console.ReadKey();
        }
        private void GetAllMeal()
        {
            Console.Clear();
            // Get all of our content
            List<Meal> directory = _menuRepo.GetAllMeal();

            // Go through each item and display its properties
            foreach (Meal content in directory)
            {
                Console.WriteLine($"Title: {content.MealName}\n" +
                    $"Description: {content.Description}\n" +
                    $"MealNumber: {content.MealNumber}\n" +
                    $"Price: {content.Price}\n" +
                    $"Ingredients: {content.Ingredients}\n");
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
        private void DeleteMeal()
        {
            GetAllMeal();
            Console.WriteLine("\nEnter the name of the meal you'd like to remove:");
            string userInput = Console.ReadLine();
            bool wasDeleted = _menuRepo.DeleteExistingMeal(userInput);
            if (wasDeleted)
            {
                Console.WriteLine("The meal was successfully deleted.");
            }
            else
            {
                Console.WriteLine("The meal could not be deleted.");
            }
            Console.ReadLine();
        }
        private void SeedContent()
        {
            Meal steak = new Meal("Steak", 1, "Juicy aged ribeye", 10.00m, "steak, salt, pepper, butter" );
            _menuRepo.AddMealToMenu(steak);
            Meal chicken = new Meal("Chicken", 2, "Amish Chicken", 8.00m, "chicken, salt, pepper, lemon, butter");
            _menuRepo.AddMealToMenu(chicken);
            Meal fish = new Meal("Fish", 3, "Fresh Salmon", 12.00m, "salmon, lemon, olive oil");
            _menuRepo.AddMealToMenu(fish);
        }
    }
}