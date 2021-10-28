using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Analytics;
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
            Time.timeScale = 0f;
            Debug.Log("Player Reached the finish");
            AnalyticsResult result = AnalyticsEvent.LevelComplete("Tutorial Completed");
            print("Player Completed Tutorial " + result);
        }
    }
}
