using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    private Rigidbody2D _rigi;
    private CapsuleCollider2D _colli;
    private SpriteRenderer _sprit;
    public LayerMask _ground;
    public Animator _ani;
    private bool _grounded;
    public float speed;
    public float jump;
    private bool _die;
    public Transform AttackPoint;
    public float AttackRange = 0.5f;
    public LayerMask enemyLayers;
    //private bool m_FacingRight = true;  // For determining which way the player is currently facing.

    // Start is called before the first frame update
    void Start()
    {
        _rigi = GetComponent<Rigidbody2D>();
        _colli = GetComponent<CapsuleCollider2D>();
        _sprit = GetComponent<SpriteRenderer>();
        _die = false;
    }

    // Update is called once per frame
    void Update()
    {
        _ani.SetBool("Fight", false);
        if (_die == false)
        {
            _grounded = Physics2D.IsTouchingLayers(_colli, _ground);
            float horizontal = Input.GetAxis("Horizontal");
            _rigi.velocity = new Vector2(horizontal * speed, _rigi.velocity.y);
            _ani.SetFloat("Move", Mathf.Abs(horizontal));
            //Move the player left and right
            if (horizontal > 0)
            {
                _sprit.flipX = false;
                
            }
            else if (horizontal < 0)
            {
                _sprit.flipX = true;
                
            }
           // player jumped
            _ani.SetBool("Jump", false);

            if ((Input.GetKey(KeyCode.Space) && _grounded) || (Input.GetKey(KeyCode.Z) && _grounded))
            {
                _rigi.velocity = new Vector2(_rigi.velocity.x, jump);
                _ani.SetBool("Jump", _grounded);

            }
            else if (Input.GetKey(KeyCode.X))
            {
                //Player hit animation
                _ani.SetBool("Fight",true);
                //Detect enemies in the Range of attack
                Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position, AttackRange, enemyLayers);
                //Damage them
                foreach (Collider2D enemy in hitEnemies)
                {
                    Debug.Log("We hit" + enemy.name);
                }


            }
        }
        else if (_die == true)
        {
            _ani.SetBool("Die", true);
            //Destroy the player, hide him, or exit the game
        }
        
       

    }
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Enemy"))
        {
            _die = true;
        }
    }
    void OnDrawGizomsSelected()
    {
        if (AttackPoint = null)
            return;
        Gizmos.DrawWireSphere(AttackPoint.position, AttackRange);
    }
    //private void Flip()
    //{
    //    // Switch the way the player is labelled as facing.
    //    //m_FacingRight = !m_FacingRight;

    //    transform.Rotate(0f, 30f,0f);
    //}

}
