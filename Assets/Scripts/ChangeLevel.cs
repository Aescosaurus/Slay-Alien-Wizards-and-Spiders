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
    public void NextLevel()
    {
        Assert.IsNotNull( player );
        Destroy( theLevel );
        theLevel = Instantiate( act1Maps[Random
            .Range( 0,act1Maps.Length - 1 )] );

        theLevel.transform.position = Vector3.zero;

        player.transform.position = ( Vector3 )playerStart;

        ++nCurLevel;
    }
    // 
    [SerializeField] GameObject[] act1Maps;
    Vector2 playerStart = new Vector2( 0.0f,0.0f );
    GameObject player;
    int nCurLevel = 0;
    [SerializeField] GameObject initialLevel;
    GameObject theLevel;
}
