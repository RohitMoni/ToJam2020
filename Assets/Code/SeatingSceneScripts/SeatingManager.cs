using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace Seating
{
    public class SeatingManager : ItemManager
    {
        public new Guest dragGuest;

        public override void PlaceGuest(ItemSpot spot)
        {
            Seat seat = spot as Seat;
            if (seat == null)
                return;

            seat.guest = dragGuest.person;
        }


        public override void PickUpGuest(ListItem item)
        {
            base.PickUpGuest(item);
            dragGuest.Setup(FindObjectOfType<DinnerPartyGlobals>().Guests[item.relative]);
        }

        public void RecordSeatingToGlobalState()
        {
            DinnerPartyGlobals partyGlobals = FindObjectOfType<DinnerPartyGlobals>();

            var seatingArrangement = new _2020Vision.SeatingArrangement();
            seatingArrangement.tables = new List<_2020Vision.DinnerTable>();

            List<_2020Vision.SeatNode> seatNodes = new List<_2020Vision.SeatNode>();
            Seat[] seats = GetComponentsInChildren<Seat>();
            foreach (Seat seat in seats)
            {
                seatNodes.Add(seat.seatNode);
            }
            foreach (var seatNode in seatNodes)
            {
                foreach (var seat in seatNode.seat.connectedSeats)
                {
                    seatNode.connectedSeats.Add(seat.seatNode);
                }
            }

            seatingArrangement.tables.Add(new _2020Vision.DinnerTable());

            seatingArrangement.tables[0].head = seatNodes[0];

            partyGlobals.currentPartyState.seatingArrangement = seatingArrangement;
        }
    }
}