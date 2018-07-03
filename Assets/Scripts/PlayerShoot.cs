using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerShoot
    :
    MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        cam = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        refire.Update( Time.deltaTime );

        bool clicking = Input.GetAxis( "Attack" ) > 0.0f;

        if( !clicking )
        {
            canClick = true;
        }
        else if( canClick )
        {
            ShootAt( GetMousePos() );
            canClick = false;
        }
    }
    void ShootAt( Vector2 target )
    {
        Assert.IsNotNull( bullet );

        GameObject temp = Instantiate( bullet );
        Bullet script = temp.GetComponent<Bullet>();
        script.SetPos( transform.position );
        script.SetVel( ( target -
            ( Vector2 )transform.position ).normalized );
    }
    Vector2 GetMousePos()
    {
        Assert.IsNotNull( cam );
        Vector3 msPos = Input.mousePosition;
        return( cam.ScreenToWorldPoint( msPos ) );
    }
    // 
    [SerializeField] GameObject bullet;
    Camera cam;
    Timer refire = new Timer( 0.5f );
    bool canClick = false;
}
