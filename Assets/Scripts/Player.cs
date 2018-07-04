using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player
    :
    MonoBehaviour
{
    void Start()
    {

    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.tag == "Enemy" )
        {
            // Hurt!
            print( "Hurt!" );
        }
    }
}
