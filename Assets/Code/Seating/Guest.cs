using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Seating
{
    public class Guest : MonoBehaviour
    {
        public bool inDrag = false, overSeat = false;
        public Image portrait;
        public int relative, seatIndex = -1;

        void Awake()
        {
            portrait = transform.GetChild(0).GetComponent<Image>();
        }

        public void SetPortrait(int relativeIndex)
        {
            relative = relativeIndex;
            portrait.sprite = FindObjectOfType<SeatingManager>().guestHeads[relative];
        }

        public void StartDrag()
        {
            inDrag = true;
        }

        public void SeatGuest(Transform seatTransform)
        {
            inDrag = false;
            overSeat = false;

            transform.position = seatTransform.position;
            transform.SetParent(seatTransform);
            seatIndex = seatTransform.GetSiblingIndex();
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