using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadPoint2 : MonoBehaviour
{
    public enemy2 enemy2;
    public bool _Die;
    private void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            enemy2.die();
            
        }
    }
}
