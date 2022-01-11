using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Script created by myself
*/

public class JumpPadController : MonoBehaviour
{
    [SerializeField] private float _padBounce = 20f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Rigidbody2D>().AddForce(Vector2.up * _padBounce, ForceMode2D.Impulse);
        } 
    }
}
