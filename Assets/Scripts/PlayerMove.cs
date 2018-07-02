using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMove
    :
    MonoBehaviour
{
    const float speed = 20.0f;
    Rigidbody2D body;
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        Assert.IsTrue( body != null );

        if( Input.GetAxis( "Move" ) < 0.0f )
        {
            body.AddForce( new Vector2( -speed,0.0f ) );
        }
        if( Input.GetAxis( "Move" ) > 0.0f )
        {
            body.AddForce( new Vector2( speed,0.0f ) );
        }

        body.AddForce( -body.velocity * 3.0f );
    }
}
