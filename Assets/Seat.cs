using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

public class Seat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public SeatingManager manager;
    public bool mouseOver = false;


    private void Start()
    {
        manager = SeatingManager.instance;
    }

    public void OnPointerEnter(PointerEventData e)
    {
        if (manager.IsDragging)
        {
            manager.PreviewGuest(this);
        }
    }

    public void OnPointerExit(PointerEventData e)
    {
        if (manager.IsDragging)
        {
            manager.EndPreview();
        }
    }

    public void OnPointerClick(PointerEventData e)
    {
        if(manager.IsDragging)
        {
            manager.PlaceGuest(this);
        }
    }

}