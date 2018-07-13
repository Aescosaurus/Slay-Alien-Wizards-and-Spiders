using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Utility
{
    public static GameObject FindInScene( string tag )
    {
        GameObject[] items = GameObject
            .FindGameObjectsWithTag( tag );
        Assert.IsTrue( items.Length == 1 );
        return( items[0] );
    }
}
