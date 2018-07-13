using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FallingSpider
    :
    MonoBehaviour
{
    void Start()
    {
        // startPos = ( Vector2 )transform.position;
        body = GetComponent<Rigidbody2D>();

        player = Utility.FindInScene( "Player" );

        FreezePosition();
    }
    void Update()
    {
        Assert.IsNotNull( player );
        // Assert.IsTrue( startPos != null );

        if( !fell &&
            Mathf.Abs( player.transform.position.x -
            transform.position.x ) < xTolerance &&
            Mathf.Abs( player.transform.position.y -
            transform.position.y ) < yTolerance )
        {
            UnfreezePosition();
            fell = true;
            transform.Rotate( Vector3.forward,180.0f );
        }

        if( fell )
        {
            jumpReset.Update( Time.deltaTime );

            if( jumpReset.IsDone() )
            {
                jumpReset.Reset();

                body.AddForce( new
                    Vector2( 0.0f,jumpPower ),
                    ForceMode2D.Impulse );
            }
        }
    }
    void FreezePosition()
    {
        body.constraints = RigidbodyConstraints2D
            .FreezePosition;
    }
    void UnfreezePosition()
    {
        body.constraints = RigidbodyConstraints2D
            .None;
        body.constraints = RigidbodyConstraints2D
            .FreezeRotation;
    }
    // 
    GameObject player;
    Rigidbody2D body;
    bool fell = false;
    const float xTolerance = 1.61f;
    const float yTolerance = 3.5f;
    Timer jumpReset = new Timer( 3.5f );
    const float jumpPower = 8.7f;
}
