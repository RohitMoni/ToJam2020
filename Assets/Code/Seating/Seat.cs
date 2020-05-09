using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine;

namespace Seating
{
    public class Seat : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
    {
        public SeatingManager manager;

        private void Start()
        {
            manager = SeatingManager.instance;
        }

        public void OnPointerEnter(PointerEventData e)
        {
            //Fixes the Guest into this Seat and tells it to stop updating mousePosition
            if (manager.IsDragging)
            {
                manager.dragGuest.overSeat = true;
                manager.dragGuest.transform.position = transform.position;
            }
        }

        public void OnPointerExit(PointerEventData e)
        {
            //Removes Guest in Seat preview
            if (manager.IsDragging)
            {
                manager.dragGuest.overSeat = false;
            }
        }

        public void OnPointerClick(PointerEventData e)
        {
            if (manager.IsDragging)
            {
                manager.PlaceGuest(this);
            }
        }

    }
}