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
            string completedHealth = GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>()._currentHealth + "HP Left";
            DiscordWebhooks.AddLineToTextFile("Log", "Player Reached the finish at level: " + SceneManager.GetActiveScene().name + " with a time of: " + Time.timeSinceLevelLoad + " with " + completedHealth);
        }
    }
}
