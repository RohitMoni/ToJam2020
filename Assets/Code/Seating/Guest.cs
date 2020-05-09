using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Seating
{
    public class Guest : MonoBehaviour, IPointerClickHandler
    {
        public bool inDrag = false, overSeat = false;
        public CanvasGroup canvasGroup;
        public int relative, seatIndex = -1;

        void Awake()
        {
            canvasGroup = GetComponent<CanvasGroup>();
        }

        public void StartDrag(int relativeIndex)
        {
            inDrag = true;
            canvasGroup.blocksRaycasts = false;
            relative = relativeIndex;
        }

        public void SeatGuest(Transform seatTransform)
        {
            inDrag = false;
            canvasGroup.blocksRaycasts = true;
            overSeat = false;

            transform.position = seatTransform.position;
            transform.SetParent(seatTransform);
            seatIndex = seatTransform.GetSiblingIndex();
        }

        public void OnPointerClick(PointerEventData e)
        {
            SeatingManager.instance.PickUpGuest(this);
        }

        public void Update()
        {
            if (inDrag && !overSeat)
            {
                transform.position = Input.mousePosition;
            }
        }
    }
}