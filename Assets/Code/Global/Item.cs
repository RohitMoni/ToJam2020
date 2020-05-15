using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class Item : MonoBehaviour
{
    public bool inDrag = false, overSpot = false;
    public int seatIndex = -1, listIndex = -1;

    public virtual void StartDrag()
    {
        inDrag = true;
    }

    public virtual void SeatGuest(Transform spotTransform)
    {
        inDrag = false;
        overSpot = false;

        transform.position = spotTransform.position;
        transform.SetParent(spotTransform);
    }

    public virtual void Update()
    {
        if (inDrag && !overSpot)
        {
            transform.position = Input.mousePosition;
        }
    }
}