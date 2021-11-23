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
        print("Player Returned to Main Menu");
        DiscordWebhooks.AddLineToTextFile("Log", "Player returned to main menu from " + SceneManager.GetActiveScene().name);
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        print("Player Progressed to Level 1");
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene(3);
        Time.timeScale = 1f;
        print("Player Progressed to Level 2");
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene(4);
        Time.timeScale = 1f;
        print("Player Progressed to Level 3");
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 3");
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
