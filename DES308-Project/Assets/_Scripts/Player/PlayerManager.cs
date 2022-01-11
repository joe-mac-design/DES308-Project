using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script Provided by: GDTitan on YouTube: https://www.youtube.com/c/GDTitans
*/

public class PlayerManager : MonoBehaviour
{
    public static Vector2 _lastCheckPointPos = new Vector2(-7,0);

    private void Awake()
    {
        _lastCheckPointPos = transform.position;
        GameObject.FindGameObjectWithTag("Player").transform.position = _lastCheckPointPos;
    }
}
