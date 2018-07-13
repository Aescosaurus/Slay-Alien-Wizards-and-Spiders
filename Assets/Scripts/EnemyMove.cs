using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EnemyMove
    :
    IsOnScreen
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        player = Utility.FindInScene( "Player" );
    }
    void Update()
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( player );

        if( IsActivated() )
        {
            Vector2 force = new Vector2( 0.0f,0.0f );
            force.x = ( player.transform.position.x >
                transform.position.x ) ? speed : -speed;
            body.AddForce( force *
                Time.deltaTime * dtOffset );
        }
    }
    // 
    Rigidbody2D body;
    GameObject player;
    const float speed = 10.0f;
    const float dtOffset = 1.0f / 0.01700295f;
}
