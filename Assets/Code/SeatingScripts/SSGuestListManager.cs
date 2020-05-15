using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SSGuestListManager : MonoBehaviour
{
    public GameObject[] guestList;

    // Start is called before the first frame update
    void Start()
    {
        // Setup Guest list with global generated
        var dinnerPartyGlobals = GameObject.Find("Globals").GetComponent<DinnerPartyGlobals>();

        for (int i = 0; i < guestList.Length; ++i)
        {
            var nameObject = guestList[i].transform.Find("Name");
            GuestData globalGuest = dinnerPartyGlobals.Guests[i];
            Transform portrait = guestList[i].transform.GetChild(0);

            nameObject.GetComponent<TextMeshProUGUI>().text = dinnerPartyGlobals.Persons[i].name;

            portrait.GetChild(0).gameObject.GetComponent<Image>().sprite = globalGuest.Head;

            if (globalGuest.relative == 0)
                continue;

            portrait.GetChild(1).gameObject.GetComponent<Image>().sprite = globalGuest.Hair;
            portrait.GetChild(2).gameObject.GetComponent<Image>().sprite = globalGuest.Eyes;
            portrait.GetChild(3).gameObject.GetComponent<Image>().sprite = globalGuest.Mouth;
        }
    }
}
