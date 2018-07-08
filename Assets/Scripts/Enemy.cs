using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Attack( int amount,Vector2 force )
    {
        Assert.IsNotNull( body );

        hp -= amount;
        if( hp < 1 )
        {
            Destroy( gameObject );
        }
        else
        {
            body.AddForce( force,ForceMode2D.Impulse );
        }
    }
    // 
    [SerializeField] int hp = 10;
    Rigidbody2D body;
}
