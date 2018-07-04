using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
    :
    MonoBehaviour
{
    // void Update()
    // {
    //     lifetime.Update( Time.deltaTime );
    //     
    //     if( lifetime.IsDone() ) Destroy( gameObject );
    // }
    public void SetPos( Vector3 pos )
    {
        transform.position = pos;
    }
    public void SetVel( Vector2 dir )
    {
        GetComponent<Rigidbody2D>()
            .AddForce( dir * speed,ForceMode2D.Impulse );
    }
    void OnTriggerEnter2D( Collider2D other )
    {
        if( other.tag != "Player" )
        {
            Enemy script = other.gameObject
                .GetComponent<Enemy>();
            if( script != null )
            {
                script.Attack( 1 );
            }
            Destroy( gameObject );
        }
    }
    // 
    const float speed = 28.5f;
    // Timer lifetime = new Timer( 0.34f );
}
