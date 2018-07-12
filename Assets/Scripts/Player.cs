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
            Attack( coll.transform.position );
        }
    }
    public void Attack( Vector2 pos )
    {
        // Hurt!
        body.AddForce( new Vector2( 0.0f,9.1f ),
            ForceMode2D.Impulse );
        moveScript.StopJumping();

        body.AddForce( new
            Vector2( -( ( pos -
            ( Vector2 )transform.position )
            .normalized * 8.0f ).x,0.0f ),
            ForceMode2D.Impulse );

        print( "Ouch!" );
    }
    // 
    Rigidbody2D body;
    PlayerMove moveScript;
}
