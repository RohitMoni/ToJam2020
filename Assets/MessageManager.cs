using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public GameObject messagePrefab;
    string[] messages = {   "Hey there! Heard you were the organizer for the reunion! Glad we got somebody capable this time around. Just a heads up, I'm still allergic to [allergy]!",
                            "Not coming unless there's [food].",
                            "Hey cousin! Want to head out for the night? I know a fantastic bar on Second St.",
                            "Oh dear is this the right number? I certainly hope this is [you]! I'm bringing my famous 3 bean dip that I know everyone loves! [Relative 4]",
                            "Do you need someone to bring streamers? I have 3 boxes of unused streamers of many colours that I would LOVE to bring ;D",
                            "Dearest beloved, I adore your passion and commitment to this endeavor.  It is a rare sight to behold such dedication for no recognition.  As such, I shall do my best to assist in easing your worries, for I will be gifting this banquet a glorious turkey that none have ever seen, one so luscious and plump that their mouths will water!"};
    public void AddMessage()
    {
        GameObject GO = Instantiate(messagePrefab, transform);
        var textMesh = GO.GetComponentInChildren<UnityEngine.UI.Text>();
        string message = messages[Random.Range(0, messages.Length)];
        textMesh.text = message;
    }
}
