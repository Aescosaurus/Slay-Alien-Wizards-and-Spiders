using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class SpiderBoss
    :
    MonoBehaviour
{
    void Start()
    {
        player = Utility.FindInScene( "Player" );
        body = GetComponent<Rigidbody2D>();
        babySpider = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .smallSpider;
    }
    void Update()
    {
        Assert.IsNotNull( player );
        Assert.IsNotNull( body );
        Assert.IsNotNull( babySpider );

        if( dead ) return;

        if( canJump )
        {
            Vector3 vel = ( player.transform.position -
                transform.position ).normalized * speed;

            body.AddForce( new Vector2( vel.x,0.0f ) );
        }

        jumpTimer.Update( Time.deltaTime );
        if( jumpTimer.IsDone() && canJump )
        {
            jumpTimer.Reset();

            Vector2 vel = ( ( ( Vector2 )player.transform
                .position + ( Vector2.up * 15.1f ) ) -
                ( Vector2 )transform.position )
                .normalized * jumpPower;

            body.AddForce( vel,ForceMode2D.Impulse );

            int spidsInScene = GameObject
                .FindGameObjectsWithTag( "Enemy" ).Length;

            if( spidsInScene < 20 )
            {
                int nSpiders = Random.Range( 1,3 + 1 );
                for( int i = 1; i <= nSpiders; ++i )
                {
                    GameObject sp = Instantiate( babySpider );
                    sp.transform.position = transform.position;
                    sp.GetComponent<SmallSpider>().Jump();
                }
            }
        }
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        if( coll.gameObject.layer == 8 )
        {
            canJump = true;
        }
    }
    public void Kill()
    {
        dead = true;
    }
    // 
    GameObject player;
    Rigidbody2D body;
    GameObject babySpider;
    Timer jumpTimer = new Timer( 4.2f );
    bool canJump = false;
    const float jumpPower = 12.5f;
    const float speed = 9.5f;
    bool dead = false;
}
