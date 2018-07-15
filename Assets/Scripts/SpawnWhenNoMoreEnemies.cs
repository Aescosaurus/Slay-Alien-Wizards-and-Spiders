using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpawnWhenNoMoreEnemies
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        var pos = ( Vector2 )transform.position;
        originalPos.Set( pos.x,pos.y );

        transform.position = Vector2.left * 9999.0f;

        FreezePosition();
    }
    void Update()
    {
        Assert.IsNotNull( body );

        checkTimer.Update( Time.deltaTime );
        if( checkTimer.IsDone() && !done )
        {
            checkTimer.Reset();
            int nEnemies = GameObject
                .FindGameObjectsWithTag( "Enemy" ).Length;

            if( nEnemies == 0 )
            {
                transform.position = originalPos;
                UnfreezePosition();
                done = true;
            }
        }
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Player" )
        {
            Destroy( gameObject );
        }
    }
    void FreezePosition()
    {
        body.constraints = RigidbodyConstraints2D
            .FreezePosition | RigidbodyConstraints2D
            .FreezeRotation;
    }
    void UnfreezePosition()
    {
        body.constraints = RigidbodyConstraints2D
            .None;
        body.constraints = RigidbodyConstraints2D
            .FreezeRotation;
    }
    // 
    Rigidbody2D body;
    Vector2 originalPos = new Vector2( 0.0f,0.0f );
    Timer checkTimer = new Timer( 1.0f );
    bool done = false;
}
