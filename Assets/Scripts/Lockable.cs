using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lockable
    :
    MonoBehaviour
{
    void LateUpdate()
    {
        if( locked )
        {
            transform.position = lockPos;
        }
    }
    public void Lock()
    {
        lockPos = transform.position;
        locked = true;
    }
    // 
    Vector3 lockPos = new Vector3( 0.0f,0.0f,0.0f );
    bool locked = false;
}
