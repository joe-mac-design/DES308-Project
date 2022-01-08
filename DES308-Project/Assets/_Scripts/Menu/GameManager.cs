using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Analytics;
using System;

public class GameManager : MonoBehaviour
{
    private GameManager m_Instance;

    // Start is called before the first frame update
    void Awake()
    {
        GameObject[] l_GameManagers = GameObject.FindGameObjectsWithTag("GameManager");
        if (l_GameManagers.Length > 1)
        {
            m_Instance = null;
            Destroy(this.gameObject);
            return;
        }
        DontDestroyOnLoad(this.gameObject);
        m_Instance = this;

        Application.wantsToQuit += WantsToQuit;

        DiscordWebhooks.ClearTextFile("Log");
        DiscordWebhooks.AddLineToTextFile("Log", "Game Started " + AnalyticsSessionInfo.sessionElapsedTime);
        DiscordWebhooks.AddLineToTextFile("Log", "App version is: " + Application.version);

        AudioManager.instance.Play("Music");

    }

    bool WantsToQuit()
    {
        Debug.Log("Player prevented from quitting.");
        m_Instance.StartCoroutine(SubmitFiles());
        return false;
    }

    IEnumerator SubmitFiles()
    {
        DiscordWebhooks.PostToDiscord(a_FileName: "Log", a_FileRename: "Username " + PlayerPrefs.GetString("Username") + " SessionID " + AnalyticsSessionInfo.sessionCount);
        yield return new WaitForSecondsRealtime(0.2f);
        Application.wantsToQuit -= WantsToQuit;
        Application.Quit();
    }

}