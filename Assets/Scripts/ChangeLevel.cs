using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ChangeLevel
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Player" );
        playerStart = player.transform.position;

        theLevel = initialLevel;
    }
    void Update()
    {
        if( Input.GetKeyUp( KeyCode.Space ) )
        {
            NextLevel();
        }
    }
    public void NextLevel()
    {
        Assert.IsNotNull( player );

        if( nCurLevel > levelsToProgress )
        {
            nCurLevel = 0;
            usedMaps.Clear();
            ++currentAct;
        }

        Destroy( theLevel );

        player.transform.position = ( Vector3 )playerStart;

        if( currentAct == 1 ) LoadLevel( act1Maps );
        else if( currentAct == 2 ) LoadLevel( act2Maps );

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
    [SerializeField] GameObject initialLevel;
    [SerializeField] GameObject[] act1Maps;
    [SerializeField] GameObject[] act2Maps;
    List<int> usedMaps = new List<int>();
    Vector2 playerStart = new Vector2( 0.0f,0.0f );
    GameObject player;
    int nCurLevel = 0;
    const int levelsToProgress = 3;
    int currentAct = 1;
    GameObject theLevel;
}
