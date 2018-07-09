using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class BigSpider
    :
    MonoBehaviour
{
    void Start()
    {
        GameObject[] players = GameObject
            .FindGameObjectsWithTag( "Player" );
        Assert.IsTrue( players.Length == 1 );
        player = players[0];

        enemyScript = GetComponent<Enemy>();

        GameObject[] list = GameObject
            .FindGameObjectsWithTag( "PrefabManager" );
        Assert.IsTrue( list.Length == 1 );
        PrefabManagerScript script = list[0]
            .GetComponent<PrefabManagerScript>();
        babySpider = script.smallSpider;
    }
    void Update()
    {
        Assert.IsNotNull( player );
        Assert.IsNotNull( enemyScript );
        Assert.IsNotNull( babySpider );

        if( ( ( Vector2 )player.transform.position -
            ( Vector2 )transform.position )
            .SqrMagnitude() < triggerDistSq &&
            Mathf.Abs( player.transform.position.y -
            transform.position.y ) < triggerDist / 2.0f )
        {
            enemyScript.Attack( 999,new
                Vector2( 0.0f,0.0f ) );
            
            int nSpiders = Random.Range( 2,4 + 1 );
            for( int i = 1; i <= nSpiders; ++i )
            {
                GameObject sp = Instantiate( babySpider );
                sp.transform.position = transform.position;
                sp.GetComponent<SmallSpider>().Jump();
            }
        }

        // TODO: Make this guy wiggle around a bit.
    }
    // 
    GameObject player;
    Enemy enemyScript;
    GameObject babySpider;
    const float triggerDist = 5.2f;
    const float triggerDistSq = triggerDist * triggerDist;
}
