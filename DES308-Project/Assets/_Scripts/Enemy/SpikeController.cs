using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
Script created by myself.
*/

public class SpikeController : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float _stDamage;
    [SerializeField] private Renderer _playerRenderer;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().DamageTaken(_stDamage);
            _playerRenderer.material.color = Color.red;
            AudioManager.instance.Play("Damage");
            DiscordWebhooks.AddLineToTextFile("Log", "Player took " + _stDamage + "HP, from Spike Trap, in level: " + SceneManager.GetActiveScene().name);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            _playerRenderer.material.color = Color.white;
        }
    }

}
