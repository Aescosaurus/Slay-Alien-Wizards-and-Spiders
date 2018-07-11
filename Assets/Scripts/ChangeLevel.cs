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
        GameObject[] players = GameObject
            .FindGameObjectsWithTag( "Player" );
        Assert.IsTrue( players.Length == 1 );
        player = players[0];
        playerStart = players[0].transform.position;

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
        Destroy( theLevel );

        int nMap = 0;
        do
        {
            nMap = Random.Range( 0,act1Maps.Length );
        }
        while( usedMaps.Contains( nMap ) );
        usedMaps.Add( nMap );

        theLevel = Instantiate( act1Maps[nMap] );

        theLevel.transform.position = Vector3.zero;

        player.transform.position = ( Vector3 )playerStart;

        ++nCurLevel;
    }
    // 
    [SerializeField] GameObject[] act1Maps;
    List<int> usedMaps = new List<int>();
    Vector2 playerStart = new Vector2( 0.0f,0.0f );
    GameObject player;
    int nCurLevel = 0;
    [SerializeField] GameObject initialLevel;
    GameObject theLevel;
}
