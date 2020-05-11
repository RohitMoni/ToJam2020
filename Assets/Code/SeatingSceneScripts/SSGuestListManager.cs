using TMPro;
using UnityEngine;

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
            var portraitObject = guestList[i].transform.Find("Portrait");
            var nameObject = guestList[i].transform.Find("Name");
            Transform globalGuest = dinnerPartyGlobals.Guests[i].transform;
            Transform portrait = guestList[i].transform.GetChild(0);

            for (int j = 0; j < globalGuest.childCount; j++)
            {
                Instantiate(globalGuest.GetChild(j), portrait).position = portrait.position;
                portrait.localScale = new Vector3(0.67f, 0.67f);
            }

            //// Set up portrait object to be replaced by our guest object
            //// Set up the guests transform to be the same as the old portrait transform
            //dinnerPartyGlobals.Guests[i].transform.SetParent(portraitObject.transform);
            //dinnerPartyGlobals.Guests[i].transform.localPosition = Vector3.zero;
            //dinnerPartyGlobals.Guests[i].transform.localRotation = Quaternion.identity;
            //dinnerPartyGlobals.Guests[i].transform.localScale = Vector3.zero;

            //// Move the guest to be a sibling of the old guest item
            //dinnerPartyGlobals.Guests[i].transform.SetParent(guestList[i].transform);

            //// Delete the old portrait object
            //Destroy(portraitObject);

            // We don't need to replace the entire name object, instead just change the text
            nameObject.GetComponent<TextMeshProUGUI>().text = dinnerPartyGlobals.Persons[i].name;
        }
    }
}
