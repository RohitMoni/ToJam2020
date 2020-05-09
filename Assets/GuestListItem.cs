using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

//Class for guests when they aren't placed
public class GuestListItem : MonoBehaviour, IPointerClickHandler
{
    public int relative;

    //Temp
    private void Start()
    {
        relative = transform.GetSiblingIndex();
    }

    //The ListItem is hidden and shown based on changes to preferred height so that it is still in the same position in the list
    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
        {
            SeatingManager.instance.PickUpGuest(this);
            GetComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 0;
        }
    }

    public void Show()
    {
        GetComponent<UnityEngine.UI.LayoutElement>().preferredHeight = 100;
    }
}