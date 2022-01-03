using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerKillCollider : MonoBehaviour
{
    //[SerializeField] Transform _respawnPoint;
    [SerializeField] private float _Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            DataRecorder.recordDeathPosition3D(collision.transform.position);
            DiscordWebhooks.AddLineToTextFile("Log", "Player fell of the map at: " + collision.transform.position + " in level: " + SceneManager.GetActiveScene().name + " and took " + _Damage + " damage");
            collision.GetComponent<HealthController>().SendMessage("DamageTaken", _Damage);
            collision.transform.position = PlayerManager._lastCheckPointPos;
        }
    }
}
