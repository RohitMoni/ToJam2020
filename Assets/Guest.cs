using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public enum ItemType
{
    GHOST = -2,
    WILDCARD = -1,
    WEAPON = 0,
    MOVEMENT,
    UTILITY
}

public class Guest : MonoBehaviour, IPointerClickHandler
{
    public bool inDrag = false;
    public bool overSeat = false;
    public CanvasGroup canvasGroup;
    public int seatIndex = -1;
    public int relative;

    void Awake()
    {
        canvasGroup = GetComponent<CanvasGroup>();
        //inventory = SeatingManager.instance.inventory;
    }

    public void Setup(int relativeIndex)
    {
        inDrag = true;
        canvasGroup.blocksRaycasts = false;
        relative = relativeIndex;
    }

    public void OnPointerClick(PointerEventData e)
    {
        SeatingManager.instance.PickUpGuest(this, transform.parent.GetSiblingIndex());
    }

    public void Update()
    {
        if (overSeat)
            return;
        if(inDrag)
        {
            transform.position = Input.mousePosition;
        }
    }
}