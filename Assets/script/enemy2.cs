using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemy2 : MonoBehaviour
{
    public Transform _PointA;
    public Transform _PointB;
    public float _speed;
    public Vector3 _location;
    private SpriteRenderer _sprit;
    public bool _Die;
    public Animator _anim;
    // Start is called before the first frame update
    void Start()
    {
        _sprit = GetComponent<SpriteRenderer>();
        _Die = false;
        _anim = GetComponent<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (_Die == false)
        {
                if (transform.position == _PointA.position)
            {
                _sprit.flipX = false;
                _location = _PointB.position;
            }
            else if (transform.position == _PointB.position)
            {
                _sprit.flipX = true;
                _location = _PointA.position;
            }
            transform.position = Vector3.MoveTowards(transform.position, _location, _speed);
        }
        else if (_Die == true)
        {
            _anim.SetBool("Die", true);
            StartCoroutine("_enemyDES");

        }
        

    }
    public void die()
    {
        _Die = true;
    }
    IEnumerator _enemyDES()
    {
        yield return new WaitForSeconds(1f);
        Destroy(gameObject);
    }

}
