using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;
using Seating;

public class ItemSpot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public ItemManager manager;
    public Item heldItem;

    public void AddItem(Item item)
    {
        heldItem = item;
    }

    public void RemoveItem()
    {
        heldItem = null;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        //Fixes the Guest into this Seat and tells it to stop updating mousePosition
        if (manager.IsDragging)
        {
            manager.dragItem.overSpot = true;
            manager.dragItem.transform.position = transform.position;
        }
    }

    public void OnPointerExit(PointerEventData e)
    {
        //Removes Guest in Seat preview
        if (manager.IsDragging)
        {
            manager.dragItem.overSpot = false;
        }
    }

    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
        {
            if (manager.IsDragging)
            {
                manager.PlaceItem(this);
            }
            else if (transform.childCount > 0)
            {
                manager.PickUpItem(GetComponentInChildren<Guest>());
            }
        }
        else if (e.button == PointerEventData.InputButton.Right)
        {
            if (transform.childCount > 0)
            {
                manager.ReturnItemToList(GetComponentInChildren<Guest>());
            }
        }
    }

}