﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class RogueEnemy
    :
    IsOnScreen
{
    void Start()
    {
        GameObject[] list = GameObject
            .FindGameObjectsWithTag( "PrefabManager" );
        Assert.IsTrue( list.Length == 1 );
        PrefabManagerScript script = list[0]
            .GetComponent<PrefabManagerScript>();
        bullet = script.mageBullet;

        GameObject[] players = GameObject
            .FindGameObjectsWithTag( "Player" );
        Assert.IsTrue( players.Length == 1 );
        player = players[0];
    }
    void Update()
    {
        Assert.IsNotNull( bullet );
        Assert.IsNotNull( player );
        if( IsActivated() )
        {
            shotTimer.Update( Time.deltaTime );

            if( shotTimer.IsDone() )
            {
                shotTimer.Reset();

                if( player.transform.position.x <
                    transform.position.x )
                {
                    ScaleBy( -1 );
                }
                else
                {
                    ScaleBy( 1 );
                }

                GameObject up = Instantiate( bullet );
                GameObject down = Instantiate( bullet );
                GameObject left = Instantiate( bullet );
                GameObject right = Instantiate( bullet );

                up.GetComponent<MagicMove>()
                    .SetPosAndVel( transform.position,
                    Vector2.up );
                down.GetComponent<MagicMove>()
                    .SetPosAndVel( transform.position,
                    Vector2.down );
                left.GetComponent<MagicMove>()
                    .SetPosAndVel( transform.position,
                    Vector2.left );
                right.GetComponent<MagicMove>()
                    .SetPosAndVel( transform.position,
                    Vector2.right );
            }
        }
    }
    void ScaleBy( int amount )
    {
        Vector3 temp = transform.localScale;
        temp.x = Mathf.Abs( temp.x ) * amount;
        transform.localScale = temp;
    }
    // 
    GameObject bullet;
    Timer shotTimer = new Timer( 2.6f );
    GameObject player;
}
