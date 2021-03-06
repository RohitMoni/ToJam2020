using System.Collections.Generic;

namespace _2020Vision
{
    // Seat data as a node, for use as a graph of seat nodes, representing a table and
    // connecting seats.
    // Need to use a graph vs a circular list because we have design requirements like having the seat 'across' the table be considered 'next to' the current seat.
    public class SeatNode
    {
        public Seat seat;
        public List<SeatNode> connectedSeats;

        public bool IsSeated(Person person)
        {
            return seat.person == person;
        }

        public SeatNode(Seat seat)
        {
            this.seat = seat;
            connectedSeats = new List<SeatNode>();
        }
    }

    // A dinner table: Class mostly used for helper functions
    public class DinnerTable
    {
        public SeatNode head;

        public SeatNode GetSeatFor(Person person)
        {
            SeatNode rv = null;

            List<SeatNode> nodesToVisit = new List<SeatNode>
            {
                head
            };

            var visitedNodes = new List<SeatNode>();

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit[0];
                visitedNodes.Add(currentNode);
                if (currentNode.IsSeated(person))
                {
                    rv = currentNode;
                    break;
                }
                else
                {
                    for (int i = 0; i < currentNode.connectedSeats.Count; ++i)
                    {
                        var connectedNode = currentNode.connectedSeats[i];

                        // Add connected node if we haven't already visited it
                        bool alreadyVisited = false;
                        for (int j = 0; j < visitedNodes.Count; ++j)
                        {
                            if (visitedNodes[j] == connectedNode)
                            {
                                alreadyVisited = true;
                                break;
                            }
                        }

                        if (!alreadyVisited)
                        {
                            nodesToVisit.Add(connectedNode);
                        }
                    }
                    nodesToVisit.RemoveAt(0);
                }
            }

            return rv;
        }
    }

    // A seating arrangement. Represents the sum total of seating data
    public class SeatingArrangement
    {
        public List<DinnerTable> tables;
    }
}