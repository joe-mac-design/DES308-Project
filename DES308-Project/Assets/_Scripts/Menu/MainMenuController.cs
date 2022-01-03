using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Analytics;
using UnityEngine.SceneManagement;
using TMPro;

public class MainMenuController : MonoBehaviour
{

    public Canvas ConsentCanvas;
    public GameObject MainMenuCanvas;

    [SerializeField] private TMP_InputField _usernameInput;
    public Button _playButton;

    // Start is called before the first frame update
    private void Start()
    {
        if (PlayerPrefs.HasKey("Consented"))
        {
            if (PlayerPrefs.GetInt("Consented") == 1)
            {
                ConsentCanvas.gameObject.SetActive(false);
                MainMenuCanvas.SetActive(true);
            }
        }

        _usernameInput.onEndEdit.AddListener(delegate { UserNameCheck(); });

        PPUserNameCheck();
        UserNameCheck();
    }

    void PPUserNameCheck() //  Testing only
    {
        if (PlayerPrefs.HasKey("Username"))
        {
            _usernameInput.text = PlayerPrefs.GetString("Username");
            _usernameInput.interactable = false;
        } else
        {
            _usernameInput.text = "";
            _usernameInput.interactable = true;
        }
    }

    public void Consent()
    {
        PlayerPrefs.SetInt("Consented", 1);
        PlayerPrefs.Save();
    }

    public void URL()
    {
        Application.OpenURL("https://forms.gle/usvp49Tt7gwFpGPTA");
        Debug.Log("URL Opened");
    }
    public void ClearData() // Testing only
    {
        PlayerPrefs.DeleteAll();
        PPUserNameCheck();
        UserNameCheck();
    }

    public void PlayTutorial()
    {
        SceneManager.LoadScene(1);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Tutorial");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene(2);
        Time.timeScale = 1f;
        DiscordWebhooks.AddLineToTextFile("Log", "Player started Level 1");
    }

    void UserNameCheck()
    {

        if (_usernameInput.text.Length >= 3)
        {
            _playButton.interactable = true;
            PlayerPrefs.SetString("Username", _usernameInput.text); // FileName
            PlayerPrefs.Save();

            DiscordWebhooks.AddLineToTextFile("Log", "Username: " + _usernameInput.text);
            _usernameInput.GetComponent<Image>().color = Color.green;
            _usernameInput.interactable = false;
        } else
        {
            _playButton.interactable = false;
            _usernameInput.GetComponent<Image>().color = Color.red;
        }
    }

    public void ButtonPressed(string a_button)
    {
        DiscordWebhooks.AddLineToTextFile("Log", "Player Clicked: " + a_button);
    }

    public void ScreenVisited(string a_scene)
    {
        DiscordWebhooks.AddLineToTextFile("Log", "Player Viewed: " + a_scene);
    }

    public void LevelProgression(string a_scene)
    {
        DiscordWebhooks.AddLineToTextFile("Log", "Player Progressd to: " + a_scene);
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
        //Debug.Log("Quitting Game");
    }

}
