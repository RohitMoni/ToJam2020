using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GuestListItem : MonoBehaviour, IPointerClickHandler
{
    public int relative;

    //Temp
    private void Start()
    {
        relative = transform.GetSiblingIndex();
    }

    public void OnPointerClick(PointerEventData e)
    {
        SeatingManager.instance.PickUpGuest(this);
        GetComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 0;
    }

    public void Show()
    {
        GetComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 100;
    }
}