using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallBox : MonoBehaviour
{
    public Transform _PointA;
    public Transform _PointB;
    public float _speed;
    public Vector3 _location;

     // Update is called once per frame
    void Update()
    {

        if (transform.position == _PointA.position)
        {
            _location = _PointB.position;
        }
        else if (transform.position == _PointB.position)
        {
            _location = _PointA.position;
        }

        transform.position = Vector3.MoveTowards(transform.position, _location, _speed);
    }
}
