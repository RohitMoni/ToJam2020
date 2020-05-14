using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Seating;

    public class ItemManager : MonoBehaviour
    {
        public static ItemManager instance;
        public Item dragGuest;
        public GameObject inventory;
        public GameObject guestPrefab;

        public bool IsDragging { get => dragGuest; }

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
                return;
            }

            Destroy(gameObject);
        }

        public virtual void PlaceGuest(ItemSpot spot)
        {
            dragGuest.SeatGuest(spot.transform);

            if (spot.transform.childCount == 1)
            {
                dragGuest = null;
            }
            else
            {
                Guest oldGuest = spot.transform.GetChild(0).GetComponent<Guest>();
                PickUpGuest(oldGuest);
            }
        }

        public void PickUpGuest(Guest item)
        {
            dragGuest = item;
            dragGuest.transform.SetParent(transform);
            dragGuest.StartDrag();
        }

        public void Update()
        {
            if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) && IsDragging && !dragGuest.overSpot)
            {
                ReleaseGuest();
            }
        }

        public void ReleaseGuest()
        {
            //If the Guest was in a seat return them
            if (dragGuest.seatIndex > -1)
            {
                Seat seat = transform.GetChild(dragGuest.seatIndex).GetComponent<Seat>();

                if (seat.transform.childCount == 0)
                {
                    PlaceGuest(seat);
                    return;
                }
            }
            //Else the Guest came from the GuestList
            ReturnGuestToList(dragGuest);
        }

        public virtual void PickUpGuest(ListItem item)
        {
            //Release the held Guest
            if (IsDragging)
            {
                ReleaseGuest();
            }

            //Spawn Guest from ListItem to mousePosition
            dragGuest = Instantiate(guestPrefab, transform).GetComponent<Guest>();
            dragGuest.StartDrag();
            //dragGuest.SetPortrait(item.relative);
            dragGuest.transform.position = Input.mousePosition;
        }

        public void ReturnGuestToList(Item guest)
        {
        //Get the ListItems into a list and find uncollapse the item
        List<ListItem> guestList = new List<ListItem>();
            guestList.AddRange(inventory.GetComponentsInChildren<ListItem>());


            guestList.Find(g => g.relative == guest.listIndex).Show();

            Destroy(guest.gameObject);
        }

        public void RecordFoodToGlobalState()
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