using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe
{
    public class Menu_Repository
    {
        protected List<Meal> _menu = new List<Meal>();
        public bool AddMealToMenu(Meal meal)
        {
        int menu = _menu.Count();
        _menu.Add(meal);
        bool wasAdded = menu + 1 == _menu.Count();
        return wasAdded;
        }
        public List<Meal> GetAllMeal()
        {
            return _menu;
        }
        public Meal GetMealByName(string mealName)
        {
            foreach (Meal meal in _menu)
            {
                if (meal.MealName.ToLower() == mealName.ToLower())
                {
                    return meal;
                }
            }
            return null;
        }
        public bool DeleteExistingMeal(string name)
        {
            Meal foundContent = GetMealByName(name);
            bool deletedResult = _menu.Remove(foundContent);
            return deletedResult;
        }
    }
}
