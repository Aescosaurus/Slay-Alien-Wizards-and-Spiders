using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EasyEnemy
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    public void Attack( int amount,Vector2 force )
    {
        Assert.IsNotNull( body );

        hp -= amount;
        if( hp < 1 && !dead )
        {
            dead = true;

            ParticleDropper drop = GetComponent<ParticleDropper>();
            if( drop != null )
            {
                drop.CreateParticles( transform.position,
                    Random.Range( 4,7 ) );
            }
            Destroy( gameObject );
        }
        else if( willKnockback )
        {
            body.AddForce( force,ForceMode2D.Impulse );
        }
    }
    // 
    [SerializeField] int hp = 10;
    [SerializeField] bool willKnockback = true;
    Rigidbody2D body;
    bool dead = false;
}
