using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ReadInput : MonoBehaviour
{

    private string _input;

    public void ReadStringInput(string TextInput)
    {
        _input = TextInput;
        DataRecorder.recordPlayerID(_input);

        PlayerPrefs.SetString("Username", _input); // FileName
        PlayerPrefs.Save();

        DiscordWebhooks.AddLineToTextFile("Log", "Username: " + _input);

    }
}
