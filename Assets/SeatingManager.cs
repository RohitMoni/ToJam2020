using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatingManager : MonoBehaviour
{
    public Guest[] Guests;
    public static SeatingManager instance;
    public Guest dragGuest;
    public GameObject inventory;
    public GameObject guestPrefab;
    public Seat overSlot;
    public bool IsDragging { get => dragGuest; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(this);
    }

    public void PlaceGuest(Seat seat)
    {
        dragGuest.SeatGuest(seat.transform);

        if (seat.transform.childCount == 1)
        {
            dragGuest = null;
        }
        else
        {
            Guest oldGuest = seat.transform.GetChild(0).GetComponent<Guest>();
            PickUpGuest(oldGuest);
        }
    }

    public void PickUpGuest(Guest item)
    {
        dragGuest = item;
        dragGuest.transform.SetParent(transform);
        dragGuest.StartDrag(item.relative);
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape) || (Input.GetMouseButtonDown(1) && IsDragging))
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

            //Make sure there isn't already a Guest in the seat, don't hink this is possible so may remove
            if (seat.transform.childCount == 0)
            {
                PlaceGuest(seat);
            }
            return;
        }
        //Else the Guest came fromo the GuestList

        //Get the ListItems into a list and find uncollapse the item
        List<GuestListItem> guestList = new List<GuestListItem>();
        guestList.AddRange(inventory.GetComponentsInChildren<GuestListItem>());
        

        guestList.Find(g => g.relative == dragGuest.relative).Show();

        Destroy(dragGuest.gameObject);
    }

    public void PickUpGuest(GuestListItem item)
    {
        //Release the held Guest
        if (IsDragging)
        {
            ReleaseGuest();
        }

        //Spawn Guest from ListItem to mousePosition
        dragGuest = Instantiate(guestPrefab, transform).GetComponent<Guest>();
        dragGuest.StartDrag(item.relative);
        dragGuest.transform.position = Input.mousePosition;
    }
}