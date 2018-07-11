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
        Assert.IsNotNull( cam );
        refire.Update( Time.deltaTime );

        {
            float amount = Input.GetAxis( "Auto Attack" );
            if( amount > 0.0f && canToggle )
            {
                autoAttack = !autoAttack;
                canToggle = false;
            }
            else if( amount == 0.0f )
            {
                canToggle = true;
            }
        }

        bool clicking = Input.GetAxis( "Attack" ) > 0.0f ||
            autoAttack;

        if( !clicking || autoAttack )
        {
            canClick = true;
        }
        if( clicking && canClick && refire.IsDone() )
        {
            refire.Reset();
            ShootAt( GetMousePos() );
            canClick = false;
        }
    }
    void ShootAt( Vector2 target )
    {
        Assert.IsNotNull( bullet );

        for( int i = 0; i < 6; ++i )
        {
            Vector2 delta = ( target - ( Vector2 )transform
                .position ).normalized;

            float angle = Mathf.Atan2( delta.y,delta.x );

            const float deviation = Mathf.PI / 15.0f;
            angle += Random.Range( -deviation,deviation );
            
            GameObject temp = Instantiate( bullet );
            Bullet script = temp.GetComponent<Bullet>();
            script.SetPos( transform.position );
            script.SetVel( new Vector2( Mathf.Cos( angle ),
                Mathf.Sin( angle ) ) );
        }
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
    Timer refire = new Timer( 0.3f );
    bool canClick = false;
    bool autoAttack = false;
    bool canToggle = false;
}
