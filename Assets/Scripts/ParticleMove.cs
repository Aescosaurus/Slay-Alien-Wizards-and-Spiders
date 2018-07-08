using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleMove
    :
    MonoBehaviour
{
    void Start()
    {
        Rigidbody2D body = GetComponent<Rigidbody2D>();

        body.AddForce( GetForceDir(),ForceMode2D.Impulse );
    }
    void Update()
    {
        if( hitGround )
        {
            lifetime.Update( Time.deltaTime );
        }
        
        if( lifetime.IsDone() )
        {
            Destroy( gameObject );
        }
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.layer == 8 )
        {
            hitGround = true;
        }
        else if( coll.gameObject.tag == "Player" )
        {
            Destroy( gameObject );
        }
        else if( coll.gameObject.tag == "Enemy" )
        {
            Destroy( gameObject );
        }
    }
    Vector2 GetForceDir()
    {
        float randX = Random.Range( -xSpeed,xSpeed );
        float randY = Random.Range( 5.1f,12.1f );

        return( new Vector2( randX,randY ) );
    }
    // 
    const float xSpeed = 4.1f;
    Timer lifetime = new Timer( 2.05f );
    bool hitGround = false;
}
