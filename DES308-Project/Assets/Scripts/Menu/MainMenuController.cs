using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MainMenuController : MonoBehaviour
{

    public Canvas ConsentCanvas;
    public GameObject MainMenuCanvas;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("Consented"))
        {
            if (PlayerPrefs.GetInt("Consented") == 1)
            {
                ConsentCanvas.gameObject.SetActive(false);
                PlayerPrefs.DeleteAll();
                MainMenuCanvas.SetActive(true);
            }
        }

    }
    public void Consent()
    {
        PlayerPrefs.SetInt("Consented", 1);
        PlayerPrefs.Save();
    }

    public void URL()
    {
        Application.OpenURL("https://forms.gle/cffUVRJ3LVz3rQdt8");
        Debug.Log("URL Opened");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        AnalyticsResult result = AnalyticsEvent.LevelStart(1);
        print("Player Started Tutorial" + result);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        AnalyticsResult result = AnalyticsEvent.LevelStart(2);
        print("Player Progressed to Level 1" + result);
    }

    public void QuitGame()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Debug.Log("Quitting Game");
    }

}
