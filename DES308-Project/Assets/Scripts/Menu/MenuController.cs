using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        AnalyticsResult result = AnalyticsEvent.LevelStart(0);
        print("Player Returned to Main Menu" + result);
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

    public void PlayLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        AnalyticsResult result = AnalyticsEvent.LevelStart(3);
        print("Player Progressed to Level 2" + result);
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        AnalyticsResult result = AnalyticsEvent.LevelStart(4);
        print("Player Progressed to Level 3" + result);
    }

    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quitting Game");
    }
}
