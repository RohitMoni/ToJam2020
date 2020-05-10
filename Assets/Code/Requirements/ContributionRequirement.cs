namespace _2020Vision
{
    // This requirement checks that a specific contribution is made
    public class ContributionRequirement : IRequirement
    {
        public int Value { get; set; }
        public string FeedbackMessage { get; set; }
        public Contribution requiredContribution;

        public bool IsMet(RequirementContext context)
        {
            for (int i = 0; i < context.partyState.contributionArrangement.contributions.Count; ++i)
            {
                if (requiredContribution.person == context.partyState.contributionArrangement.contributions[i].person &&
                    context.partyState.contributionArrangement.contributions[i].food.DoesInclude(requiredContribution.food))
                {
                    return true;
                }
            }

            return false;
        }
    }
}