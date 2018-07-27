using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class StartButton
    :
    MonoBehaviour
{
    void Start()
    {
        cam = Camera.main;
        coll = GetComponent<BoxCollider2D>();
        levelChangerScr = Utility
            .FindInScene( "LevelChanger" )
            .GetComponent<ChangeLevel>();

        Assert.IsNotNull( levelChangerScr );
        levelChangerScr.enabled = false;
    }
    void Update()
    {
        Assert.IsNotNull( coll );
        Assert.IsNotNull( levelChangerScr );

        if( Input.GetAxis( "Attack" ) > 0.0f &&
            coll.bounds.Contains( GetMousePos() ) )
        {
            StartGame();
        }
    }
    void StartGame()
    {
        {
            var pl = Instantiate( player );
            pl.transform.position = ( Vector3 )playerStart;

            var tutLvl = Instantiate( tutorialLevel );
            tutLvl.transform.position = Vector3.zero;

            levelChangerScr.initialLevel = tutLvl;
        }

        levelChangerScr.enabled = true;
        levelChangerScr.EnableTheObject();

        for( int i = 0; i < stuffToRemove.Length; ++i )
        {
            stuffToRemove[i].transform.position = farAway;
        }
        transform.position = farAway;
    }
    Vector2 GetMousePos()
    {
        Assert.IsNotNull( cam );

        Vector3 msPos = Input.mousePosition;
        return ( cam.ScreenToWorldPoint( msPos ) );
    }
    // 
    [SerializeField] GameObject[] stuffToRemove;
    Camera cam;
    BoxCollider2D coll;
    Vector2 playerStart = new Vector2( -1.11f,-3.05f );
    ChangeLevel levelChangerScr;
    [SerializeField] GameObject player;
    [SerializeField] GameObject tutorialLevel;
    Vector2 farAway = new Vector2( 99.0f,0.0f );
}
