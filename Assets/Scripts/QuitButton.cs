using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class QuitButton
    :
    MonoBehaviour
{
    void Start()
    {
        cam = Camera.main;
        coll = GetComponent<BoxCollider2D>();
    }
    void Update()
    {
        Assert.IsNotNull( coll );

        if( Input.GetAxis( "Attack" ) > 0.0f &&
            coll.bounds.Contains( GetMousePos() ) )
        {
            Application.Quit();
        }
    }
    Vector2 GetMousePos()
    {
        Assert.IsNotNull( cam );

        Vector3 msPos = Input.mousePosition;
        return ( cam.ScreenToWorldPoint( msPos ) );
    }
    // 
    Camera cam;
    BoxCollider2D coll;
}
