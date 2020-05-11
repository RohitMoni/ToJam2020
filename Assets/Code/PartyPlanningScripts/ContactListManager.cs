﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ContactListManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        DinnerPartyGlobals globals = GameObject.FindObjectOfType<DinnerPartyGlobals>();
        for (int i = 0; i < 6; i++)
        {
            GameObject guestGameObject = transform.GetChild(i).gameObject;
            //Seating.Guest guest = guestGameObject.GetComponentInChildren<Seating.Guest>();
            //Seating.Guest globalGuest = globals.Guests[i].GetComponent<Seating.Guest>();

            guestGameObject.GetComponentInChildren<Seating.Guest>().Setup(
                             globals.Guests[i].GetComponent<Seating.Guest>());

            //guest.SetPortrait(globalGuest.Head.sprite, i);
            //guest.Hair.rectTransform.rect.Set(guest.Hair.sprite.rect.x, guest.Hair.sprite.rect.y, guest.Hair.sprite.rect.width, guest.Hair.sprite.rect.height);
            //guest.SetHair(globalGuest.Hair.sprite);
            //guest.Hair.color = globalGuest.Hair.color;
            //guest.SetEyes(globalGuest.Eyes.sprite);
            //guest.Eyes.color = globalGuest.Eyes.color;
            //guest.SetMouth(globalGuest.Mouth.sprite);
            //guest.Mouth.color = globalGuest.Mouth.color;
            //guest.SetName(globalGuest.GetName());

            guestGameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(globals.Guests[i].GetComponent<Seating.Guest>().GetName());
        }
    }
}
