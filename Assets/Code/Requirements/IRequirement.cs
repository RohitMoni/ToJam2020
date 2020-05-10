namespace _2020Vision
{
    public interface IRequirement {
        int Value { get; set; }

        bool IsMet(RequirementContext context);
    }
}