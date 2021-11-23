using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SawController : MonoBehaviour
{
    [Header("Damage")]
    [SerializeField] private float _sawDamage;

    [Header("Movement")]
    [SerializeField] private float _horizontalDistance;
    [SerializeField] private float _verticalDistance;
    [SerializeField] private float _sawSpeed;

    // Horizontal Movement
    private bool _isMovingLeft;
    private float _leftEdge;
    private float _rightEdge;

    // Vertical Movement
    private bool _isMovingDown;
    private float _bottomEdge;
    private float _topEdge;

    private void Awake()
    {
        _leftEdge = transform.position.x - _horizontalDistance;
        _rightEdge = transform.position.x + _horizontalDistance;
        _topEdge = transform.position.y - _verticalDistance;
        _bottomEdge = transform.position.y + _verticalDistance;
    }

    private void Update()
    {
        // Horizontal Saw Movement
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

        // Vertical Saw Movement
        if (_isMovingDown)
        {
            if(transform.position.y > _topEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y - _sawSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                _isMovingDown = false;
            }
        }
        else
        {
            if (transform.position.y < _bottomEdge)
            {
                transform.position = new Vector3(transform.position.x, transform.position.y + _sawSpeed * Time.deltaTime, transform.position.z);
            }
            else
            {
                _isMovingDown = true;
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            collision.GetComponent<HealthController>().DamageTaken(_sawDamage);
            Debug.Log("Player took " + _sawDamage + " damage from SAW");
            DiscordWebhooks.AddLineToTextFile("Log", "Player took " + _sawDamage + " in level " + SceneManager.GetActiveScene().name);
        }
    }
}
