using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SmallSpider
    :
    IsOnScreen
{
    void Start()
    {
        dir = GetRandDir();
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Assert.IsNotNull( body );

        if( IsActivated() )
        {
            jumpTimer.Update( Time.deltaTime );

            if( jumpTimer.IsDone() )
            {
                body.AddForce( new
                    Vector2( 0.0f,jumpPower ),
                    ForceMode2D.Impulse );

                jumpTimer.Reset();
            }

            body.AddForce( new
                Vector2( ( float )dir * speed,0.0f ) );

            Vector2 tPos = ( Vector2 )transform.position;
            if( tPos == lastPos &&
                tPos == posBeforeThat )
            {
                // print( "I'm stuck!!" );
                dir = GetRandDir();

                posBeforeThat.Set( -9999.0f,-9999.0f );
            }
            else
            {
                posBeforeThat = lastPos;
                lastPos = ( Vector2 )transform.position;
            }
        }
    }
    void OnCollisionExit2D( Collision2D coll )
    {
        // dir = GetRandDir();
    }
    int GetRandDir()
    {
        return( ( Random.Range( 0,10 ) > 5 ) ? 1 : -1 );
    }
    // 
    Rigidbody2D body;
    int dir = -1;
    const float speed = 10.0f;
    const float jumpPower = 4.61542f;
    Timer jumpTimer = new Timer( 3.15f );
    Vector2 lastPos = new Vector2( 0.0f,0.0f );
    Vector2 posBeforeThat = new Vector2( 0.0f,0.0f );
}
