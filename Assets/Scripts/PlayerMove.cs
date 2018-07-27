using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class PlayerMove
    :
    MonoBehaviour
{
    // Use this for initialization
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        cam = Camera.main;
        walls = Utility.FindInScene( "Walls" );
        healthBar = Utility.FindInScene( "HealthBar" );
    }
    // Update is called once per frame
    void Update()
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( cam );
        Assert.IsNotNull( walls );
        Assert.IsNotNull( healthBar );

        float dt = GetDT();

        if( Input.GetAxis( "Move Left" ) > 0.0f )
        {
            body.AddForce( new Vector2( -speed *
                dt,0.0f ) );
        }
        if( Input.GetAxis( "Move Right" ) > 0.0f )
        {
            body.AddForce( new Vector2( speed *
                dt,0.0f ) );
        }

        body.AddForce( -body.velocity * 3.0f * dt );

        if( Input.GetAxis( "Jump" ) > 0.0f )
        {
            if( canJump )
            {
                jumping = true;
                canJump = false;
            }
        }
        else if( minJump.IsDone() ) FinishJump();

        if( jumping )
        {
            body.AddForce( new Vector2( 0.0f,jumpPower *
                dt * ( ( 1.0f - maxJump.GetPercent() ) * 1.5f ) ) );

            maxJump.Update( Time.deltaTime );
            minJump.Update( Time.deltaTime );

            if( maxJump.IsDone() ) FinishJump();
        }

        // if( Input.GetAxis( "Jump" ) == 0.0f )
        // {
        //     canJump = true;
        // }

        {
            Vector3 camPos = new Vector3
            (
                cam.transform.position.x,
                transform.position.y,
                cam.transform.position.z
            );
            cam.transform.position = camPos;

            Vector3 wallPos = new Vector3
            (
                walls.transform.position.x,
                transform.position.y,
                walls.transform.position.z
            );
            walls.transform.position = wallPos;

            Vector3 hpBarPos = new Vector3
            (
                healthBar.transform.position.x,
                transform.position.y - 4.7f,
                healthBar.transform.position.z
            );
            healthBar.transform.position = hpBarPos;
        }
    }
    void FinishJump()
    {
        maxJump.Reset();
        minJump.Reset();
        jumping = false;
    }
    public void StopJumping()
    {
        FinishJump();
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.layer == 8 )
        {
            canJump = true;
        }
    }
    float GetDT()
    {
        return ( Time.deltaTime * dtOffset );
    }
    // 
    const float dtOffset = 1.0f / 0.01700295f;
    const float speed = 30.0f; // From 20.
    Rigidbody2D body;
    const float jumpPower = 45.4f;
    bool jumping = false;
    bool canJump = false;
    Timer minJump = new Timer( 0.21f );
    Timer maxJump = new Timer( 0.75f );
    Camera cam;
    [SerializeField] GameObject walls;
    [SerializeField] GameObject healthBar;
}