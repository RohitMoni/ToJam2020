using System.Collections;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using UnityEngine;


public enum TextType
{
    History = 0,
    SeatingReq,
    FoodReq,
    Bringing
}

[System.Serializable]
public class TextConversation
{
    public string relative;
    public List<string[]>[] texts = new List<string[]>[4];
}

public class MessageManager : MonoBehaviour
{
    public static MessageManager instance;
    public GameObject messageRightPrefab, messageLeftPrefab;
    public Transform left, right;
    //private bool leftRight = true;
    private const string SetRegex = @"(?<Category>\w*):\r\n(?<Content>(\w*:.*\r\n)*)";
    private const string ConversationRegex = @"(?<Relative>\w*): (?<Text>.*)\r\n";
    [SerializeField] private TextAsset textAsset;
    public Dictionary<string, TextConversation> textConversations = new Dictionary<string, TextConversation>();

    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
            return;
        }

        Destroy(gameObject);
    }

    public void Start()
    {
        string inputText = textAsset.text;
        TextConversation inputConversation = new TextConversation();
        Regex setRegex = new Regex(SetRegex);
        Regex convoRegex = new Regex(ConversationRegex);
        MatchCollection setMatches = setRegex.Matches(inputText);

        for (int i = 0; i < setMatches.Count; i++)
        {
            MatchCollection convoMatches = convoRegex.Matches(setMatches[i].Groups["Content"].Value);
            List<string[]> conversation = new List<string[]>();
            for (int j = 0; j < convoMatches.Count; j++)
            {
                string relative = convoMatches[j].Groups["Relative"].Value;
                string text = convoMatches[j].Groups["Text"].Value;
                conversation.Add(new string[] {relative, text });
            }

            switch(setMatches[i].Groups["Category"].Value)
            {
                case "History":
                    inputConversation.texts[(int)TextType.History] = conversation;
                    break;
                case "Seating":
                    inputConversation.texts[(int)TextType.SeatingReq] = conversation;
                    break;
                case "Food":
                    inputConversation.texts[(int)TextType.FoodReq] = conversation;
                    break;
                case "Bringing":
                    inputConversation.texts[(int)TextType.Bringing] = conversation;
                    break;
            }
        }

        inputConversation.relative = "Granny";
        textConversations.Add(inputConversation.relative, inputConversation);
        DisplayTexts(inputConversation.relative, (int)TextType.History);
    }

    //public void AddMessage()
    //{
    //    string messageString = textConversation.textHistory[Random.Range(0, textConversation.textHistory.Count)][1];

    //    GameObject leftMessage = Instantiate(messageLeftPrefab, left);
    //    var leftTextMesh = leftMessage.GetComponentInChildren<UnityEngine.UI.Text>();

    //    GameObject rightMessage = Instantiate(messageRightPrefab, right);
    //    var rightTextMesh = rightMessage.GetComponentInChildren<UnityEngine.UI.Text>();

    //    leftTextMesh.text = messageString;
    //    rightTextMesh.text = messageString;

    //    if (leftRight)
    //    {
    //        rightMessage.GetComponent<CanvasGroup>().alpha = 0;
    //    }
    //    else
    //    {
    //        leftMessage.GetComponent<CanvasGroup>().alpha = 0;
    //    }
    //    leftRight = !leftRight;
    //}

    public void DisplayMessage(string sender, string message)
    {
        GameObject leftMessage = Instantiate(messageLeftPrefab, left);
        var leftTextMesh = leftMessage.GetComponentInChildren<UnityEngine.UI.Text>();

        GameObject rightMessage = Instantiate(messageRightPrefab, right);
        var rightTextMesh = rightMessage.GetComponentInChildren<UnityEngine.UI.Text>();

        leftTextMesh.text = message;
        rightTextMesh.text = message;

        if (sender.Contains("You"))
        {
            leftMessage.GetComponent<CanvasGroup>().alpha = 0;
        }
        else
        {
            rightMessage.GetComponent<CanvasGroup>().alpha = 0;
        }
    }

    public void ChooseMessage(int index)
    {
        DisplayTexts("Granny", index + 1);
    }

    public void DisplayTexts(string relative, int textType)
    {
        for (int i = 0; i < textConversations[relative].texts[textType].Count; i++)
        {
            DisplayMessage(textConversations[relative].texts[textType][i][0], textConversations[relative].texts[textType][i][1]);
        }
    }
}
