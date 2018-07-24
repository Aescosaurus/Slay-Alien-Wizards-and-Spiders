using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WormBossMove
    :
    MonoBehaviour
{
    enum Direction
    {
        Left = - 1,
        Right = 1
    }
    // 
    void Start()
    {
        transform.position = startPos;
        dir = Direction.Right;
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        Assert.IsNotNull( body );
        body.velocity = Vector3.zero;
        transform.position += ( Vector3 )( move *
            ( int )dir * speed * Time.deltaTime );
        
        if( transform.position.x < -17.0f )
        {
            TurnAround( Direction.Right );
            ScaleBy( 1 );
        }
        else if( transform.position.x > 17.0f )
        {
            TurnAround( Direction.Left );
            ScaleBy( -1 );
        }
    }
    void TurnAround( Direction newDir )
    {
        dir = newDir;
        var pos = transform.position;
        pos.y = Random.Range( minY,maxY );
        transform.position = pos;
    }
    void ScaleBy( int dir )
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs( scale.x ) * ( float )dir;
        transform.localScale = scale;
    }
    // 
    Rigidbody2D body;
    const float speed = 7.1f;
    Vector2 startPos = new Vector2( -15.0f,2.0f );
    Vector2 move = new Vector2( 1.0f,0.0f );
    Direction dir;
    const float minY = -2.23f;
    const float maxY = 5.39f;
}
