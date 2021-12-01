using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
        DiscordWebhooks.AddLineToTextFile("Log", "Player returned to main menu from " + SceneManager.GetActiveScene().name);
    }

    public void MainMenuCompletion()
    {
        SceneManager.LoadScene(0);
        DiscordWebhooks.AddLineToTextFile("Log", "Player completed level: " + SceneManager.GetActiveScene().name + " and returned to main menu");
    }

    public void MainMenuFail()
    {
        SceneManager.LoadScene(0);
        DiscordWebhooks.AddLineToTextFile("Log", "Player failed level: " + SceneManager.GetActiveScene().name + " and returned to main menu");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 1");
    }

    public void RestartLevel1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player restarted Level 1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 2");
    }

    public void RestartLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player restarted Level 2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 3");
    }

    public void RestartLevel3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player restarted Level 3");
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Tutorial");
    }

    public void RestartTutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player restarted Tutorial");
    }

    public void QuitGame()
    {
        //If we are running in a standalone build of the game
#if UNITY_STANDALONE
        //Quit the application
        DiscordWebhooks.AddLineToTextFile("Log", "Player Quit game from: " + SceneManager.GetActiveScene().name);
        Application.Quit();
#endif

        //If we are running in the editor
#if UNITY_EDITOR
        //Stop playing the scene
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        
    }
 
}
