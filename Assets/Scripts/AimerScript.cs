using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class AimerScript
    :
    MonoBehaviour
{
    void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        Assert.IsNotNull( cam );

        transform.position = ( Vector3 )GetMousePos();
    }
    Vector2 GetMousePos()
    {
        Assert.IsNotNull( cam );

        Vector3 msPos = Input.mousePosition;
        return ( cam.ScreenToWorldPoint( msPos ) );
    }
    // 
    Camera cam;
}
