using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMove>();
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( moveScript );

        if( coll.gameObject.tag == "Enemy" )
        {
            // Hurt!
            body.AddForce( new Vector2( 0.0f,12.1f ),
                ForceMode2D.Impulse );
            moveScript.StopJumping();
            print( "Ouch!" );
        }
    }
    // 
    Rigidbody2D body;
    PlayerMove moveScript;
}
