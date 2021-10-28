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
    }
}
