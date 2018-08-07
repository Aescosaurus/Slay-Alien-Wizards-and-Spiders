using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.SceneManagement;

public class ChangeLevel
    :
    MonoBehaviour
{
    public void EnableTheObject()
    {
        player = Utility.FindInScene( "Player" );
        playerStart = player.transform.position;

        theLevel = initialLevel;

        cam = Camera.main;
    }
    void Update()
    {
        if( Input.GetKeyUp( KeyCode.Space ) )
        {
            NextLevel();
        }
    }
    public void EndGame()
    {
        // SceneManager.LoadScene( SceneManager
        //     .GetActiveScene().name );

        cam.GetComponent<Lockable>().Lock();

        Utility.FindInScene( "QuitButton" )
            .transform.position = new
            Vector3( 1.5f,-4.0f,10.0f ) +
            cam.transform.position;

        Utility.FindInScene( "LoseScreen" )
            .GetComponent<FadeOut>().StartFadingOut();
    }
    public void NextLevel()
    {
        Assert.IsNotNull( player );

        if( ( currentAct == 1 && nCurLevel > 3 ) ||
            ( currentAct == 2 && nCurLevel > 2 ) ||
            ( currentAct == 3 && nCurLevel > 2 ) )
        {
            nCurLevel = 1;
            usedMaps.Clear();

            Destroy( theLevel );
            player.transform.position = ( Vector3 )playerStart;

            if( currentAct == 1 )
            {
                theLevel = Instantiate( act1BossRoom );
            }
            else if( currentAct == 2 )
            {
                theLevel = Instantiate( act2BossRoom );
            }
            else if( currentAct == 3 )
            {
                theLevel = Instantiate( act3BossRoom );
            }

            ++currentAct;

            theLevel.transform.position = Vector3.zero;

            return;
        }

        Destroy( theLevel );

        player.transform.position = ( Vector3 )playerStart;

        if( currentAct == 1 ) LoadLevel( act1Maps );
        else if( currentAct == 2 ) LoadLevel( act2Maps );
        else if( currentAct == 3 ) LoadLevel( act3Maps );

        theLevel.transform.position = Vector3.zero;

        ++nCurLevel;
    }
    void LoadLevel( GameObject[] mapsList )
    {
        int nMap = 0;
        do
        {
            nMap = Random.Range( 0,mapsList.Length );
        }
        while( usedMaps.Contains( nMap ) );
        print( nMap );

        usedMaps.Add( nMap );
        theLevel = Instantiate( mapsList[nMap] );
    }
    // 
    public GameObject initialLevel;
    [SerializeField] GameObject[] act1Maps;
    [SerializeField] GameObject[] act2Maps;
    [SerializeField] GameObject[] act3Maps;
    [SerializeField] GameObject act1BossRoom;
    [SerializeField] GameObject act2BossRoom;
    [SerializeField] GameObject act3BossRoom;
    List<int> usedMaps = new List<int>();
    Vector2 playerStart = new Vector2( 0.0f,0.0f );
    GameObject player;
    int nCurLevel = 1;
    int currentAct = 1;
    GameObject theLevel;
    Camera cam;
}
