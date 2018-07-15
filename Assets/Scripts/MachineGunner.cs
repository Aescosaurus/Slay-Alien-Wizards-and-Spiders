using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class MachineGunner
    :
    IsOnScreen
{
    void Start()
    {
        player = Utility.FindInScene( "Player" );

        bullet = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .mageBullet;
    }
    void Update()
    {
        Assert.IsNotNull( player );
        Assert.IsNotNull( bullet );

        // Eww... Can we de-gross-ify this someday pls?
        if( IsActivated() )
        {
            shotTimer.Update( Time.deltaTime );

            if( shotTimer.IsDone() )
            {
                Vector2 vel = new Vector2( 0.0f,0.0f );

                if( player.transform.position.x <
                   transform.position.x )
                {
                    vel.x = -1.0f;
                    ScaleBy( -1 );
                }
                else if( player.transform.position.x >
                    transform.position.x )
                {
                    vel.x = 1.0f;
                    ScaleBy( 1 );
                }

                // if( Mathf
                //     .Abs( player.transform.position.y -
                //     transform.position.y ) < yTolerance )
                {
                    refire.Update( Time.deltaTime );

                    if( refire.IsDone() )
                    {
                        refire.Reset();

                        var bull = Instantiate( bullet );
                        bull.transform
                            .position = transform.position;
                        bull.GetComponent<MagicMove>()
                            .SetVel( vel );

                        ++volleyCur;

                        if( volleyCur > volleySize )
                        {
                            volleyCur = 0;
                            shotTimer.Reset();
                        }
                    }
                }
            }
        }
    }
    void ScaleBy( int dir )
    {
        Vector3 scale = transform.localScale;
        scale.x = Mathf.Abs( scale.x ) * ( float )dir;
        transform.localScale = scale;
    }
    // 
    GameObject player;
    GameObject bullet;
    Timer shotTimer = new Timer( 3.64f );
    Timer refire = new Timer( 0.25f );
    const int volleySize = 9;
    int volleyCur = 0;
    const float yTolerance = 0.91f;
}
