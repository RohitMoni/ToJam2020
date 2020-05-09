using System.Collections.Generic;

namespace _2020Vision
{
    // Mutually exclusive
    public enum FoodCourse
    {
        Appetizer,
        Main,
        Dessert
    }

    // Not mutually exclusive. Food can have multiple tags
    public enum FoodTag
    {
        Drinks,
        Veg,
        NonVeg,
        Fish,
        Vegan,
        GlutenFree,
    }

    public class Food
    {
        public FoodCourse course;
        public List<FoodTag> tags;
    }

    // A food arrangement, including the number and types of food
    public class FoodArrangement
    {
        public List<Food> food;
    }
}