using System.Collections;
using UnityEngine;

public class ScoringStarController : MonoBehaviour
{
    public float starScoreDelay = 2f;
    public GameObject[] Stars;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TriggerStarScoringDelayed(3, starScoreDelay));
    }

    IEnumerator TriggerStarScoringDelayed(int numStars, float delay)
    {
        yield return new WaitForSeconds(delay);
        StartCoroutine(TriggerStarScoring(numStars));
    }

    IEnumerator TriggerStarScoring(int numStars)
    {
        if (numStars < 1)
        {
            yield break;
        }

        TriggerStarPop(0);

        // Trigger the rest of the stars slightly staggered
        for (int i = 1; i < Stars.Length; ++i)
        {
            if (numStars < i+1)
            {
                yield break;
            }
            yield return new WaitForSeconds(0.5f);

            TriggerStarPop(i);
        }
    }

    void TriggerStarPop(int index)
    {
        Stars[index].GetComponent<Animator>().SetTrigger("Start");
    }
}
