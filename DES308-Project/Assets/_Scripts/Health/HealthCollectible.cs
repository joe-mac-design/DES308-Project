using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthCollectible : MonoBehaviour
{
    [SerializeField] private float _healthValue; // value of collectible in hearts 1/3

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().AddHealth(_healthValue);
            gameObject.SetActive(false);
            Debug.Log("Player picked up Health");
        }
    }
}
