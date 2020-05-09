
namespace _2020Vision {

    public interface IRequirement {
        int Value { get; }

        bool IsMet(RequirementContext context);
    }
}