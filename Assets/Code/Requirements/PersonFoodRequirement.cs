namespace _2020Vision
{
    // This requirement checks that a specific food required is in the arrangement
    public class PersonFoodRequirement : IRequirement
    {
        public int Value { get; set; }
        public Food requiredFood;

        public bool IsMet(RequirementContext context)
        {
            for (int i = 0; i < context.partyState.foodArrangement.food.Count; ++i)
            {
                if (context.partyState.foodArrangement.food[i].DoesInclude(requiredFood))
                {
                    return true;
                }
            }

            return false;
        }
    }
}