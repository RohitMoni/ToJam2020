using _2020Vision;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoringFeedbackController : MonoBehaviour
{
    public GameObject feedbackContent;
    public GameObject feedbackTextTemplate;
    public ScrollRect feedbackScrollrect;

    public float delayBetweenFeedbackElements = 0.8f;

    private Queue<string> feedbackQueue = new Queue<string>();
    private bool isCoroutineRunning = false;

    // Start is called before the first frame update
    void Start()
    {
        var dinnerPartyGlobals = GameObject.Find("Globals").GetComponent<DinnerPartyGlobals>();
        var feedback = ScoringManager.GetFeedbackStrings(dinnerPartyGlobals.currentPartyState, dinnerPartyGlobals.requirements);
        ReplaceNamesInFeedbackStrings(feedback, dinnerPartyGlobals.Persons);
        AddFeedbackToQueue(feedback);
    }

    void AddFeedbackToQueue(List<string> feedback)
    {
        for (int i = 0; i < feedback.Count; ++i)
        {
            AddFeedbackToQueue(feedback[i]);
        }
    }

    void AddFeedbackToQueue(string feedback)
    {
        feedbackQueue.Enqueue(feedback);
        if (!isCoroutineRunning)
        {
            StartCoroutine(AddFeedbackFromQueueCoroutine());
        }
    }

    IEnumerator AddFeedbackFromQueueCoroutine()
    {
        isCoroutineRunning = true;

        while (feedbackQueue.Count > 0)
        {
            var feedback = feedbackQueue.Dequeue();
            AddFeedbackToView(feedback);

            yield return new WaitForEndOfFrame();
            feedbackScrollrect.normalizedPosition = new Vector2(0, 0);

            yield return new WaitForSeconds(delayBetweenFeedbackElements);
        }

        isCoroutineRunning = false;
    }

    void AddFeedbackToView(string feedback)
    {
        var newTextObject = GameObject.Instantiate(feedbackTextTemplate, feedbackContent.transform);
        newTextObject.GetComponent<TextMeshProUGUI>().text = feedback;
        newTextObject.SetActive(true);
    }

    void ReplaceNamesInFeedbackStrings(List<string> rawFeedback, List<Person> persons)
    {
        for (int i = 0; i < rawFeedback.Count; ++i)
        {
            var rawFeedbackString = rawFeedback[i];
            for (int j = 0; j < persons.Count; ++j)
            {
                rawFeedbackString = rawFeedbackString.Replace(persons[j].id.ToString(), persons[j].name);
            }
        }
    }
}
