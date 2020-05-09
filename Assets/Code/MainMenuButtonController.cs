using UnityEngine;

public class MainMenuButtonController : MonoBehaviour
{
    public void OnPlay()
    {

    }

    public void OnSettings()
    {

    }

    public void OnCredits()
    {

    }

    public void OnExit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
