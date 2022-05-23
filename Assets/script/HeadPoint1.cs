using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPoint1 : MonoBehaviour
{
    //public bool _Die;
    public enemy1 enemy1;

    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            enemy1.die();
            
        }
    }
}
