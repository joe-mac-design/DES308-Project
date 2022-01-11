using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script Provided by: GDTitan on YouTube: https://www.youtube.com/c/GDTitans
*/

public class CheckPointController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Player")
        {
            PlayerManager._lastCheckPointPos = transform.position;
            AudioManager.instance.Play("CheckPoint");
        }
    }
}
