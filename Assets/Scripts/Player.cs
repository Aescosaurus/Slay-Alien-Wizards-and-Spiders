using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class Player
    :
    MonoBehaviour
{
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        moveScript = GetComponent<PlayerMove>();

        hpBarFiller = Utility.FindInScene( "HealthBar" )
            .GetComponent<HealthBarBase>().childHealthBar;
    }
    void Update()
    {
        if( invul ) invulTimer.Update( Time.deltaTime );

        if( invulTimer.IsDone() )
        {
            invul = false;
            invulTimer.Reset();
        }
    }
    void OnCollisionEnter2D( Collision2D coll )
    {
        Assert.IsNotNull( body );
        Assert.IsNotNull( moveScript );

        if( coll.gameObject.tag == "Enemy" )
        {
            Attack( coll.transform.position );
        }
    }
    public void Attack( Vector2 pos )
    {
        Assert.IsNotNull( hpBarFiller );

        if( invul ) return;

        // Hurt!
        --health;
        Vector2 nPos = hpBarFiller.transform.localPosition;
        nPos.x -= 0.318f;
        hpBarFiller.transform.localPosition = nPos;

        body.AddForce( new Vector2( 0.0f,9.1f ),
            ForceMode2D.Impulse );
        moveScript.StopJumping();

        body.AddForce( new
            Vector2( -( ( pos -
            ( Vector2 )transform.position )
            .normalized * 8.0f ).x,0.0f ),
            ForceMode2D.Impulse );

        print( "Ouch!" );

        invul = true;
    }
    // 
    Rigidbody2D body;
    PlayerMove moveScript;
    int health = 6;
    GameObject hpBarFiller;
    Timer invulTimer = new Timer( 4.5f );
    bool invul = false;
}
