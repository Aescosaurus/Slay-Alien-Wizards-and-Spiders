using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class WizardBoss
    :
    MonoBehaviour
{
    enum Phase
    {
        Shotgun,
        Wave,
        Targeting
    }
    void Start()
    {
        bullet = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .mageBullet;
        player = Utility.FindInScene( "Player" );
    }
    void Update()
    {
        Assert.IsNotNull( bullet );
        Assert.IsNotNull( bullet );

        if( dead ) return;

        if( state == Phase.Shotgun )
        {
            shotgunRefire.Update( Time.deltaTime );

            if( !shotgunRefire.IsDone() ) return;

            ++shotgunCounter;
            if( shotgunCounter > nShotguns )
            {
                shotgunCounter = 0;
                state = Phase.Wave;
                shotgunRefire.Reset();
                return;
            }
            shotgunRefire.Reset();

            const int nBullets = 7; // From 8.
            const float startAngle = ( Mathf.PI * 2.0f ) - Mathf.PI / 12.0f;
            const float startAngle2 = ( Mathf.PI * 2.0f ) + Mathf.PI / 12.0f;
            const float endAngle = Mathf.PI - Mathf.PI / 12.0f;
            const float endAngle2 = Mathf.PI + Mathf.PI / 12.0f;
            const float diff = endAngle - startAngle;
            const float diff2 = endAngle2 - startAngle2;
            for( int i = 0; i < nBullets; ++i )
            {
                float angle = 0.0f;
                if( shotgunCounter % 2 == 0 )
                {
                    angle = startAngle + diff *
                        ( ( float )i / ( float )nBullets );
                }
                else
                {
                    angle = startAngle2 + diff2 *
                        ( ( float )i / ( float )nBullets );
                }

                Vector2 vel = new Vector2(
                    Mathf.Cos( angle ),
                    Mathf.Sin( angle ) );

                var bull = Instantiate( bullet );
                var scr = bull.GetComponent<MagicMove>();

                scr.SetPosAndVel( transform.position,
                    vel );
            }
        }
        else if( state == Phase.Wave )
        {
            const int nRounds = 2;
            const int nBullets = 8;
            const float minAngle = ( Mathf.PI * 2.0f ) - Mathf.PI / 12.0f;
            const float maxAngle = Mathf.PI - Mathf.PI / 12.0f;
            const float diff = maxAngle - minAngle;

            waveTimer.Update( Time.deltaTime );

            if( !waveTimer.IsDone() ) return;

            waveTimer.Reset();

            var bull = Instantiate( bullet );
            var scr = bull.GetComponent<MagicMove>();

            float angle = minAngle + diff *
                ( ( float )curWaveBullet / ( float )nBullets );

            Vector2 vel = new
                Vector2( Mathf.Cos( angle ),
                Mathf.Sin( angle ) );

            scr.SetPosAndVel( transform.position,
                vel );

            ++curWaveBullet;

            if( curWaveBullet > nBullets )
            {
                ++curRound;
                curWaveBullet = 0;

                if( curRound > nRounds )
                {
                    curRound = 0;
                    state = Phase.Targeting;
                    waveTimer.Reset();
                }
            }
        }
        else if( state == Phase.Targeting )
        {
            const int nBullets = 5;
            const int nRefires = 4;

            targetRefire.Update( Time.deltaTime );

            if( !targetRefire.IsDone() ) return;

            targetRefire.Reset();
            ++curTargeted;
            if( curTargeted > nRefires )
            {
                targetRefire.Reset();
                curTargeted = 0;
                state = Phase.Shotgun;
                return;
            }

            const float angleDev = Mathf.PI / 12.0f;

            for( int i = 0; i < nBullets; ++i )
            {
                var bull = Instantiate( bullet );
                var scr = bull.GetComponent<MagicMove>();

                Vector2 diff = ( player.transform.position -
                    transform.position ).normalized;

                float angle = Mathf.Atan2( diff.y,diff.x ) +
                    Random.Range( -angleDev,angleDev );

                Vector2 vel = new
                    Vector2( Mathf.Cos( angle ),
                    Mathf.Sin( angle ) );

                scr.SetPosAndVel( transform.position,vel );
            }
        }
    }
    public void Kill()
    {
        dead = true;
        var enemies = GameObject
            .FindGameObjectsWithTag( "Enemy" );
        foreach( GameObject e in enemies )
        {
            Destroy( e );
        }
    }
    // 
    GameObject player;
    GameObject bullet;
    Phase state = Phase.Shotgun;
    Timer shotgunRefire = new Timer( 0.68f );
    const int nShotguns = 6;
    int shotgunCounter = 0;

    int curWaveBullet = 0;
    Timer waveTimer = new Timer( 0.282f );
    int curRound = 0;

    int curTargeted = 0;
    Timer targetRefire = new Timer( 0.7f );

    bool dead = false;
}
