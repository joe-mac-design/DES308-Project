using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SawController : MonoBehaviour
{

    [Header("Damage")]
    [SerializeField] private float _sawDamage;

    [Header("Movement")]
    [SerializeField] private float _horizontalDistance;
    [SerializeField] private float _sawSpeed;

    private bool _isMovingLeft;
    private float _leftEdge;
    private float _rightEdge;

    private void Awake()
    {
        _leftEdge = transform.position.x - _horizontalDistance;
        _rightEdge = transform.position.x + _horizontalDistance;
    }

    private void Update()
    {
        if(_isMovingLeft)
        {
            if(transform.position.x > _leftEdge)
            {
                transform.position = new Vector3(transform.position.x - _sawSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                _isMovingLeft = false;
            }
        }
        else
        {
            if (transform.position.x < _rightEdge)
            {
                transform.position = new Vector3(transform.position.x + _sawSpeed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
            {
                _isMovingLeft = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().DamageTaken(_sawDamage);
        }
    }
}
