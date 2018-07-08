using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IsOnScreen
    :
    MonoBehaviour
{
    void OnBecameVisible()
    {
        activated = true;
    }
    void OnBecameInvisible()
    {
        activated = false;
    }
    protected bool IsActivated()
    {
        return( activated );
    }
    // 
    bool activated = false;
}
