using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PortalScript
    :
    MonoBehaviour
{
    void Start()
    {
        GameObject[] changers = GameObject
            .FindGameObjectsWithTag( "LevelChanger" );
        Assert.IsTrue( changers.Length == 1 );
        levelChanger = changers[0]
            .GetComponent<ChangeLevel>();
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Player" )
        {
            levelChanger.NextLevel();
        }
    }
    // 
    ChangeLevel levelChanger;
}
