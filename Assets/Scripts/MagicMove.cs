using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MagicMove
    :
    MonoBehaviour
{
    void Awake()
    {
        body = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        lifetime.Update( Time.deltaTime );

        if( lifetime.IsDone() )
        {
            Destroy( gameObject );
        }
    }
    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.tag == "Player" )
        {
            coll.gameObject.GetComponent<Player>()
                .Attack( transform.position );
        }
    }
    public void SetVel( Vector2 vel )
    {
        Assert.IsNotNull( body );
        body.AddForce( vel * speed,ForceMode2D.Impulse );
    }
    public void SetPosAndVel( Vector2 pos,Vector2 vel )
    {
        transform.position = ( Vector3 )pos;
        SetVel( vel );
        angle = Mathf.Atan2( vel.x,vel.y ) * Mathf.Rad2Deg;
    }
    void OnBecameInvisible()
    {
        Destroy( gameObject );
    }
    // 
    Rigidbody2D body;
    Timer lifetime = new Timer( 12.4f );
    const float speed = 2.9f;
    public float angle;
}
