namespace _2020Vision
{
    // This requirement checks that a specific contribution is made
    public class ContributionRequirement : IRequirement
    {
        public int Value { get; }
        public Contribution requiredContribution;

        public bool IsMet(RequirementContext context)
        {
            for (int i = 0; i < context.partyState.contributionArrangement.contributions.Count; ++i)
            {
                if (requiredContribution == context.partyState.contributionArrangement.contributions[i])
                {
                    return true;
                }
            }

            return false;
        }
    }
}