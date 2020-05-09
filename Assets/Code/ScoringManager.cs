using System;
using System.Collections.Generic;

namespace _2020Vision
{
    public class ScoringManager
    {
        public const int MinScoreStars = 0;
        public const int MaxScoreStars = 3;

        // Get our score in terms of number of stars.
        // Generally rounds down
        public int CalcScoreStars(PartyState state, List<IRequirement> requirements)
        {
            var scorePercentage = CalcScorePercentage(state, requirements);

            // Take the score as a percentage (ex: 0.8)
            // Add epsilon to account for floating point error (Ex: 0.999 should be 1.x). Important because we floor the value later
            // Multiply by the max score (0.8 * 3 = 2.4)
            // Floor it to get the number of stars (2.4 => 2)
            return (int) Math.Floor((scorePercentage + float.Epsilon) * MaxScoreStars);
        }

        // Returns a number between 0 and 1, representing the percentage score accomplished by the state passed in
        // Total point value is determined by the combined value of all requirements
        public float CalcScorePercentage(PartyState state, List<IRequirement> requirements)
        {
            var reqContext = new RequirementContext()
            {
                partyState = state
            };

            int maxScore = 0;
            int evalScore = 0;
            for (int i = 0; i < requirements.Count; ++i)
            {
                var req = requirements[i];
                maxScore += req.Value;
                if (req.IsMet(reqContext))
                {
                    evalScore += req.Value;
                }
            }

            return evalScore / maxScore;
        }
    }
}