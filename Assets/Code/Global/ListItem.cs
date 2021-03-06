﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine;

//Class for guests when they aren't placed
public class ListItem : MonoBehaviour, IPointerClickHandler
{
    public int relative;
    private CanvasGroup canvasGroup;
    [SerializeField]private ItemManager manager;

    private void Start()
    {
        relative = transform.GetSiblingIndex();
        canvasGroup = GetComponent<CanvasGroup>();
        manager = ItemManager.instance;
    }

    //The ListItem is hidden and shown based on changes to preferred height so that it is still in the same position in the list
    public void OnPointerClick(PointerEventData e)
    {
        if (e.button == PointerEventData.InputButton.Left)
        {
            manager.PickUpItem(this);
            Hide();
        }
    }

    public void Show()
    {
        GetComponent<LayoutElement>().preferredHeight = 100;
        canvasGroup.alpha = 1;
        canvasGroup.blocksRaycasts = true;
    }

    public void Hide()
    {
        GetComponent<LayoutElement>().preferredHeight = 0;
        canvasGroup.alpha = 0;
        canvasGroup.blocksRaycasts = false;
    }
}