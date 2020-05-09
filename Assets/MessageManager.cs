using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MessageManager : MonoBehaviour
{
    public GameObject messageRightPrefab, messageLeftPrefab;
    public Transform left, right;
    private bool leftRight = true;
    string[] messages = {   "Hey there! Heard you were the organizer for the reunion! Glad we got somebody capable this time around. Just a heads up, I'm still allergic to [allergy]!",
                            "Not coming unless there's [food].",
                            "Hey cousin! Want to head out for the night? I know a fantastic bar on Second St.",
                            "Oh dear is this the right number? I certainly hope this is [you]! I'm bringing my famous 3 bean dip that I know everyone loves! [Relative 4]",
                            "Do you need someone to bring streamers? I have 3 boxes of unused streamers of many colours that I would LOVE to bring ;D",
                            "Dearest beloved, I adore your passion and commitment to this endeavor.  It is a rare sight to behold such dedication for no recognition.  As such, I shall do my best to assist in easing your worries, for I will be gifting this banquet a glorious turkey that none have ever seen, one so luscious and plump that their mouths will water!"};
    public void AddMessage()
    {
        string messageString = messages[Random.Range(0, messages.Length)];

        GameObject leftMessage = Instantiate(messageLeftPrefab, left);
        var leftTextMesh = leftMessage.GetComponentInChildren<UnityEngine.UI.Text>();

        GameObject rightMessage = Instantiate(messageRightPrefab, right);
        var rightTextMesh = rightMessage.GetComponentInChildren<UnityEngine.UI.Text>();

        leftTextMesh.text = messageString;
        rightTextMesh.text = messageString;

        if (leftRight)
        {
            rightMessage.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            leftMessage.GetComponent<CanvasGroup>().alpha = 0;
        }
        leftRight = !leftRight;
    }
}
