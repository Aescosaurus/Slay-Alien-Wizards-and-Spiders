using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HideMouse
    :
    MonoBehaviour
{
    void Update()
    {
        if( Cursor.visible )
        {
            Cursor.visible = false;
        }
    }
}
