
using System.Collections.Generic;

namespace _2020Vision {

    public class SeatedNextToRequirement : IRequirement {
        public int Value { get; }
        public string PersonA { get; }
        public string PersonB { get; }

        public bool IsMet(RequirementContext context)
        {
            // Find Person A in the seating arrangement
            var seating = context.seatingArrangement;
            for (int i = 0; i < seating.tables.Count; ++i)
            {
                var table = seating.tables[i];
                var seat = table.GetSeatFor(PersonA);
                if (seat != null)
                {
                    // Found PersonA seated at this table. Check the connected seats to see if we have PersonB
                    for (int j = 0; j < seat.connectedSeats.Count; ++j)
                    {
                        if (seat.connectedSeats[j].IsSeated(PersonB))
                        {
                            // We found PersonB next to PersonA
                            return true;
                        }
                    }

                    // If we found PersonA, but PersonB wasn't next to them, this requirement isn't met
                    return false;
                }
            }

            // We couldn't find PersonA at any table
            return false;
        }
    }
}