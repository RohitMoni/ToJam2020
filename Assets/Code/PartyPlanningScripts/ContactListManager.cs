using System.Collections;
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

            guestGameObject.GetComponentInChildren<Guest>().Setup(globals.Guests[i]);

            guestGameObject.GetComponentInChildren<TextMeshProUGUI>().SetText(globals.Guests[i].name);
        }
    }
}
