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
            collision.transform.position = _respawnPoint.position;
            collision.GetComponent<HealthController>().DamageTaken(_Damage);
            DataRecorder.recordFallPosition3D(transform.position);
        }
    }
}
