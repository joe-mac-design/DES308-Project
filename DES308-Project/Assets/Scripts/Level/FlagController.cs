using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FlagController : MonoBehaviour
{
    [SerializeField] private GameObject tutorialCanvas;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.CompareTag("Player"))
        {
            tutorialCanvas.SetActive(true);
            Debug.Log("Player Reached the finish");
        }
    }
}
