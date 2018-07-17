using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Boss1
    :
    Enemy
{
    void Update()
    {
        if( amDead )
        {
            if( !setOrigPos )
            {
                setOrigPos = true;
                origPos = ( Vector2 )transform.position;
                drop = GetComponent<ParticleDropper>();
            }

            Assert.IsNotNull( drop );

            transform.position = ( Vector3 )( origPos +
                new Vector2( Mathf
                .Sin( Time.time * 46.0f ) * 0.07f,0.0f ) );

            if( Random.Range( 0,10 ) > 7 )
            {
                drop.CreateParticles( transform.position,
                    Random.Range( 0,2 ) );
            }

            deathTimer.Update( Time.deltaTime );
            if( deathTimer.IsDone() )
            {
                drop.CreateParticles( transform.position,
                    Random.Range( 12,17 ) );
                Destroy( gameObject );
            }
        }
    }
    public void DestroyMe()
    {
        amDead = true;
    }
    // 
    bool amDead = false;
    Vector2 origPos = new Vector2( 0.0f,0.0f );
    bool setOrigPos = false;
    ParticleDropper drop;
    Timer deathTimer = new Timer( 1.4f );
}
