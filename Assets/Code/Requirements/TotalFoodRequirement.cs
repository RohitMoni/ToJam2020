using System.Collections.Generic;

namespace _2020Vision
{
    // This requirement checks that the required food is contained within a set of food passed in by context
    public class TotalFoodRequirement : IRequirement
    {
        public int Value { get; }
        public FoodArrangement requiredFood;

        public bool IsMet(RequirementContext context)
        {
            var duplicateFood = new List<Food>();
            duplicateFood.AddRange(context.foodArrangement.food);

            for (int i = 0; i < requiredFood.food.Count; ++i)
            {
                var required = requiredFood.food[i];
                bool requiredFound = false;
                for (int j = 0; j < duplicateFood.Count; ++j)
                {
                    var foodInArrangement = duplicateFood[j];
                    if (required == foodInArrangement)
                    {
                        // We found the required food in the arrangement, check the next one
                        // Make sure we don't count this food in the arrangement twice by removing it from the list for next time
                        duplicateFood.RemoveAt(j);
                        j--;
                        requiredFound = true;
                        break;
                    }
                }

                if (!requiredFound)
                {
                    // If we got here, it means that a required food was NOT found in the food arrangement. Requirement has not been met.
                    return false;
                }
            }

            return true;
        }
    }
}