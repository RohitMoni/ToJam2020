using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using Seating;

public class ItemManager : MonoBehaviour
{
    public static ItemManager instance;
    public Item dragItem;
    public GameObject inventory;
    public GameObject guestPrefab;

    public bool IsDragging { get => dragItem; }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public virtual void PlaceItem(ItemSpot spot)
    {
        dragItem.SeatGuest(spot.transform);
        spot.AddItem(dragItem);

        if (spot.transform.childCount == 1)
        {
            dragItem = null;
        }
        else
        {
            Item oldGuest = spot.transform.GetChild(0).GetComponent<Item>();
            PickUpItem(oldGuest);
        }
    }

    public void PickUpItem(Item item)
    {
        dragItem = item;
        dragItem.transform.SetParent(transform);
        dragItem.StartDrag();
    }

    public void Update()
    {
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetMouseButtonDown(1)) && IsDragging && !dragItem.overSpot)
        {
            ReleaseItem();
        }
    }

    public void ReleaseItem()
    {
        //If the Guest was in a seat return them
        if (dragItem.seatIndex > -1)
        {
            ItemSpot spot = transform.GetChild(dragItem.seatIndex).GetComponentInChildren<ItemSpot>();

            if (spot.transform.childCount == 0)
            {
                PlaceItem(spot);
                return;
            }
        }
        //Else the Guest came from the GuestList
        ReturnItemToList(dragItem);
    }

    public virtual void PickUpItem(ListItem item)
    {
        //Release the held Guest
        if (IsDragging)
        {
            ReleaseItem();
        }

        //Spawn Guest from ListItem to mousePosition
        dragItem = Instantiate(guestPrefab, transform).GetComponent<Item>();
        dragItem.StartDrag();
        dragItem.listIndex = item.relative;
        dragItem.transform.position = Input.mousePosition;
    }

    public void ReturnItemToList(Item guest)
    {
        //Get the ListItems into a list and find uncollapse the item
        List<ListItem> guestList = new List<ListItem>();
        guestList.AddRange(inventory.GetComponentsInChildren<ListItem>());


        guestList.Find(g => g.relative == guest.listIndex).Show();

        Destroy(guest.gameObject);
    }
}