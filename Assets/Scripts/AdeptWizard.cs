﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AdeptWizard
    :
    MonoBehaviour
{
    void Start()
    {
        GameObject[] players = GameObject
            .FindGameObjectsWithTag( "Player" );
        Assert.IsTrue( players.Length == 1 );
        player = players[0];

        GameObject[] list = GameObject
            .FindGameObjectsWithTag( "PrefabManager" );
        Assert.IsTrue( list.Length == 1 );
        PrefabManagerScript script = list[0]
            .GetComponent<PrefabManagerScript>();
        bullet = script.mageBullet;
    }
    void Update()
    {
        refireTime.Update( Time.deltaTime );

        if( refireTime.IsDone() && Mathf
            .Abs( player.transform.position.y -
            transform.position.y ) < yTolerance )
        {
            refireTime.Reset();

            Vector2 vel = new Vector2( 0.0f,0.0f );

            if( player.transform.position.x <
                transform.position.x )
            {
                vel.x = -1.0f;
            }
            else if( player.transform.position.x >
                transform.position.x )
            {
                vel.x = 1.0f;
            }

            GameObject bull = Instantiate( bullet );
            bull.transform.position = transform.position;
            bull.GetComponent<MagicMove>().SetVel( vel );
        }
    }
    // 
    Timer refireTime = new Timer( 3.5f );
    GameObject bullet;
    GameObject player;
    const float yTolerance = 0.783f;
}