using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Seating
{
    public class Seat : ItemSpot
    {
        public _2020Vision.SeatNode seatNode;
        public _2020Vision.Person guest;
        [SerializeField]public Seat[] connectedSeats;

        private void Start()
        {
            seatNode = new _2020Vision.SeatNode(this);
        }

    }
}