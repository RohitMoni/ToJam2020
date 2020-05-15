using System.Collections.Generic;

namespace _2020Vision
{
    // Mutually exclusive
    public enum FoodCourse
    {
        Appetizer,
        Main,
        Dessert,
        Cutlery,
        Drinks,
        None
    }

    // Not mutually exclusive. Food can have multiple tags
    public enum FoodTag
    {
        Veg,
        NonVeg,
        Fish,
        Vegan,
        GlutenFree,
    }
    
    [System.Serializable]
    public class Food
    {
        public FoodCourse course = FoodCourse.None;
        public HashSet<FoodTag> tags = new HashSet<FoodTag>();

        // Need to use this for a lot of the requirements vs == because of the inclusive nature of tags
        // Ex: A Fish dish requirement is met by a NonVeg Fish dish.
        public bool DoesInclude(Food other)
        {
            return course == other.course && tags.IsSupersetOf(other.tags);
        }
    }

    // A food arrangement, including the number and types of food
    public class FoodArrangement
    {
        public List<Food> food;
    }
}