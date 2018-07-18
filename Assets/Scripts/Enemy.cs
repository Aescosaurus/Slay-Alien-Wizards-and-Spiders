using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Enemy
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }
    // void Update()
    // {
    //     // Don't put stuff here cuz I override it.
    // }
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
            // Destroy( gameObject );
            DestroyThis();
        }
        else if( willKnockback )
        {
            body.AddForce( force * forceOffset,
                ForceMode2D.Impulse );
        }
    }
    void DestroyThis()
    {
        var bossScript = GetComponent<BossDeath>();
        if( bossScript != null )
        {
            bossScript.DestroyMe();
            var spidBoss = GetComponent<SpiderBoss>();
            if( spidBoss != null )
            {
                spidBoss.Kill();
            }
            var wizBoss = GetComponent<WizardBoss>();
            if( wizBoss != null )
            {
                wizBoss.Kill();
            }
        }
        else
        {
            Destroy( gameObject );
        }
    }
    // 
    [SerializeField] int hp = 10;
    [SerializeField] bool willKnockback = true;
    [SerializeField] float forceOffset = 1.0f;
    Rigidbody2D body;
    bool dead = false;
}
