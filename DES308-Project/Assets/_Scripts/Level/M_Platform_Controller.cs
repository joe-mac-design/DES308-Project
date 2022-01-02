using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class M_Platform_Controller : MonoBehaviour
{
    [Header("Movement")]
    public float _speed;
    public int _startingPoint;
    public Transform[] _points;

    private int _arrayIndex;

    private void Start()
    {
        transform.position = _points[_startingPoint].position;
    }

    private void Update()
    {
        if (Vector2.Distance(transform.position, _points[_arrayIndex].position) < 0.02f)
        {
            _arrayIndex++;
            if(_arrayIndex == _points.Length)
            {
                _arrayIndex = 0;
            }
        }

        transform.position = Vector2.MoveTowards(transform.position, _points[_arrayIndex].position, _speed * Time.deltaTime);

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.position.y > transform.position.y)
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        collision.transform.SetParent(null);
    }
}
