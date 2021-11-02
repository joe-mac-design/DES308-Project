using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKillCollider : MonoBehaviour
{
    [SerializeField] Transform _respawnPoint;
    [SerializeField] private float _Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            Debug.Log("Player fell off map");
            DataRecorder.recordDeathPosition3D(collision.transform.position);
            collision.GetComponent<HealthController>().SendMessage("DamageTaken", _Damage);
            collision.transform.position = _respawnPoint.position;
        }
    }
}
