using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public static Vector2 _lastCheckPointPos = new Vector2(-7,0);

    private void Awake()
    {
        GameObject.FindGameObjectWithTag("Player").transform.position = _lastCheckPointPos;
    }
}
