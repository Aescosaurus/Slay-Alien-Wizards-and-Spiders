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
        GameObject[] players = GameObject
            .FindGameObjectsWithTag( "Player" );
        Assert.IsTrue( players.Length == 1 );
        player = players[0];
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
            body.AddForce( force );
        }
    }
    // 
    Rigidbody2D body;
    GameObject player;
    const float speed = 10.0f;
}
