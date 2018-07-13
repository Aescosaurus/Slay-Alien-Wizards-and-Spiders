using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FlyingSpider
    :
    IsOnScreen
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        player = Utility.FindInScene( "Player" );

        baseY = transform.position.y;

        MoveMe();
    }
    void Update()
    {
        if( IsActivated() )
        {
            MoveMe();
        }
    }
    void MoveMe()
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( player );
        Assert.IsTrue( baseY != -9999.0f );

        Vector2 pos = ( Vector2 )transform.position;

        pos.y = baseY + Mathf.Sin( pos.x );

        pos.x += speed * ( float )dir;
        if( pos.x > maxX )
        {
            dir = -1;
            pos.x -= speed;
        }
        else if( pos.x < minX )
        {
            dir = 1;
            pos.x += speed;
        }

        transform.position = ( Vector3 )pos;
    }
    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.tag == "Player" )
        {
            other.GetComponent<Player>()
                .Attack( transform.position );
        }
    }
    // 
    Rigidbody2D body;
    GameObject player;
    const float minX = -9.9f;
    const float maxX = 7.6f;
    const float speed = 0.041f;
    int dir = -1;
    float baseY = -9999.0f;
}
