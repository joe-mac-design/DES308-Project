using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class HealthController : MonoBehaviour
{
    [SerializeField] private float _defaultHealth;
    [SerializeField] private GameObject deathCanvas;
    public float _currentHealth { get; private set; } // available in other scripts but can only bet set in this script

    private void Awake()
    {
        _currentHealth = _defaultHealth; // at the start of the game, the _currentHealth will be the _defaultHealth of 3
    }

    public void DamageTaken(float _enemyDamage)
    {
        _currentHealth = Mathf.Clamp(_currentHealth - _enemyDamage, 0, _defaultHealth); // Assign a value to the object

        if (_currentHealth <= 0) // if the player health is 0, destroy the player (gameObject)
        {
            DataRecorder.recordDeathPosition3D(transform.position);
            deathCanvas.SetActive(true);
            Destroy(gameObject);
            Time.timeScale = 0f;
            AudioManager.instance.Play("GameOver");
            DiscordWebhooks.AddLineToTextFile("Log", "Player Died in level: " + SceneManager.GetActiveScene().name);
        }
        
    }

    public void AddHealth(float _healthValue)
    {
        _currentHealth = Mathf.Clamp(_currentHealth + _healthValue, 0, _defaultHealth); // Assign a value to the object
        DiscordWebhooks.AddLineToTextFile("Log", "Player restored " + _healthValue + "HP in level: " + SceneManager.GetActiveScene().name);
    }
}
