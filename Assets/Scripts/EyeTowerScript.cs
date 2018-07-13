using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class EyeTowerScript
    :
    IsOnScreen
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();

        player = Utility.FindInScene( "Player" );
        bullet = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .mageBullet;

        FreezePosition();
    }
    void Update()
    {
        Assert.IsNotNull( player );
        Assert.IsNotNull( bullet );
        Assert.IsNotNull( body );

        if( IsActivated() )
        {
            refire.Update( Time.deltaTime );

            if( refire.IsDone() )
            {
                refire.Reset();

                Vector3 vel = ( player.transform.position -
                    transform.position ).normalized;

                GameObject bull = Instantiate( bullet );
                bull.GetComponent<MagicMove>()
                    .SetPosAndVel( transform.position,
                    vel );
            }
        }
    }
    void OnTriggerEnter2D( Collider2D coll )
    {
        if( coll.gameObject.tag == "Bullet" && !fell )
        {
            fell = true;
            UnfreezePosition();
            transform.Rotate( Vector3.forward,180.0f );
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
    GameObject player;
    GameObject bullet;
    Timer refire = new Timer( 1.2f );
    bool fell = false;
}
