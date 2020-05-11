using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

public class MessageChoiceHandler : MonoBehaviour, IPointerClickHandler, IPointerEnterHandler, IPointerExitHandler
{
    private Color defaultColour;
    [SerializeField] private Color highlightColour;
    private Image image;

    private void Start()
    {
        image = GetComponent<Image>();
        defaultColour = image.color;
    }

    public void OnPointerClick(PointerEventData e)
    {
        if(e.button == PointerEventData.InputButton.Left)
        {
            MessageManager.instance.ChooseMessage(transform.GetSiblingIndex());
        }
    }

    public void OnPointerEnter(PointerEventData e)
    {
        image.color = highlightColour;
    }

    public void OnPointerExit(PointerEventData e)
    {
        image.color = defaultColour;
    }
}
