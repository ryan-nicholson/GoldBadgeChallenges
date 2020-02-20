using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01_KCafe
{
    public class Meal
    {
        static void Main(string[] args)
        {
        }
        public string MealName { get; set; }
        public int MealNumber { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public string Ingredients { get; set; }

        public Meal() { } //Open Constructor

        public Meal (string mealName, int mealNumber, string description, decimal price, string ingredients)
        {
            MealName = mealName;
            MealNumber = mealNumber;
            Description = description;
            Price = price;
            Ingredients = ingredients;
        }
    }
}
