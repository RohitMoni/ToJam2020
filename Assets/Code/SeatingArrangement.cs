
using System;
using System.Collections.Generic;

namespace _2020Vision {

    public class SeatData
    {
        public string assignedTo;
    }

    public class SeatNode
    {
        public SeatData data;
        public List<SeatNode> connectedSeats;

        public bool IsSeated(string name)
        {
            return String.Equals(data.assignedTo, name, StringComparison.OrdinalIgnoreCase);
        }
    }

    public class DinnerTable
    {
        public SeatNode head;

        public SeatNode GetSeatFor(string name)
        {
            SeatNode rv = null;

            var nodesToVisit = new List<SeatNode>();
            nodesToVisit.Add(head);

            var visitedNodes = new List<SeatNode>();

            while (nodesToVisit.Count > 0)
            {
                var currentNode = nodesToVisit[0];
                visitedNodes.Add(currentNode);
                if (currentNode.IsSeated(name))
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
                }
            }

            return rv;
        }
    }

    public class SeatingArrangement
    {
        public List<DinnerTable> tables;
    }
}