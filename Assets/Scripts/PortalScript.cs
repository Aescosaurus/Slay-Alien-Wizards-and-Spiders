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
        levelChanger = Utility
            .FindInScene( "LevelChanger" )
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
