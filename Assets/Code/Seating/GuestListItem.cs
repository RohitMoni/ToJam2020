using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

namespace Seating
{
    //Class for guests when they aren't placed
    public class GuestListItem : MonoBehaviour, IPointerClickHandler
    {
        public int relative;
        private GameObject portrait;

        //Temp
        private void Start()
        {
            relative = transform.GetSiblingIndex();
            portrait = transform.Find("Portrait").gameObject;
        }

        //The ListItem is hidden and shown based on changes to preferred height so that it is still in the same position in the list
        public void OnPointerClick(PointerEventData e)
        {
            if (e.button == PointerEventData.InputButton.Left)
            {
                SeatingManager.instance.PickUpGuest(this);
                Hide();
            }
        }

        public void Show()
        {
            GetComponent<LayoutElement>().preferredHeight = 100;
            portrait.SetActive(true); // This might not work if we need other parts of the gameobject to be active
        }

        public void Hide()
        {
            GetComponent<LayoutElement>().preferredHeight = 0;
            portrait.SetActive(false);
        }
    }
}