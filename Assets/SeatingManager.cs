using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeatingManager : MonoBehaviour
{
    public Guest[] Guests;
    public static SeatingManager instance;
    public Guest dragItem;
    public GameObject inventory;
    public GameObject guestPrefab;
    public Seat overSlot;
    public bool IsDragging { get => dragItem; }

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
        dragItem.transform.SetParent(seat.transform);
        dragItem.inDrag = false;
        dragItem.overSeat = false;
        dragItem.canvasGroup.blocksRaycasts = true;
        dragItem.transform.position = seat.transform.position;
        dragItem.seatIndex = seat.transform.GetSiblingIndex();

        if (seat.transform.childCount == 1)
        {
            dragItem = null;
        }
        else
        {
            Guest oldGuest = seat.transform.GetChild(0).GetComponent<Guest>();
            PickUpGuest(oldGuest, seat.transform.GetSiblingIndex());
        }
    }

    public void PickUpGuest(Guest item, int seatIndex)
    {
        dragItem = item;
        dragItem.seatIndex = seatIndex;
        dragItem.transform.SetParent(transform);
        dragItem.Setup(item.relative);
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
        if (dragItem.seatIndex > -1)
        {
            Seat seat = transform.GetChild(dragItem.seatIndex).GetComponent<Seat>();
            if (seat.transform.childCount == 0)
                PlaceGuest(seat);
            return;
        }

        List<GuestListItem> guestList = new List<GuestListItem>(inventory.GetComponentsInChildren<GuestListItem>());
        guestList.Find(g => g.relative == dragItem.relative).Show();

        Destroy(dragItem.gameObject);
    }

    public void PickUpGuest(GuestListItem item)
    {
        if (IsDragging)
        {
            ReleaseGuest();
        }

        //Spawn Guest from item
        dragItem = Instantiate(guestPrefab, transform).GetComponent<Guest>();
        dragItem.Setup(item.relative);
        dragItem.transform.position = Input.mousePosition;
    }

    public void PreviewGuest(Seat seat)
    {
        dragItem.overSeat = true;
        dragItem.transform.position = seat.transform.position;
    }

    public void EndPreview()
    {
        dragItem.overSeat = false;
    }
}