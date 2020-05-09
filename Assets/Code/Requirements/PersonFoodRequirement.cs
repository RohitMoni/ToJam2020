namespace _2020Vision
{
    // This requirement checks that a specific food required is in the arrangement
    public class PersonFoodRequirement : IRequirement
    {
        public int Value { get; }
        public Food requiredFood;

        public bool IsMet(RequirementContext context)
        {
            for (int i = 0; i < context.foodArrangement.food.Count; ++i)
            {
                if (requiredFood == context.foodArrangement.food[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}