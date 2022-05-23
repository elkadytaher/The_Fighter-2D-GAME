using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    private Rigidbody2D _rigi;
    private CapsuleCollider2D _colli;
    public float speed;
    private SpriteRenderer _sprit;
    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _colli = GetComponent<CapsuleCollider2D>();
        _sprit = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        _rigi.velocity = new Vector2(horizontal * speed, _rigi.velocity.y);

        if (horizontal > 0)
        {
            _sprit.flipX = false;
        }
        else if (horizontal < 0)
        {
            _sprit.flipX = true;
        }
    }
}