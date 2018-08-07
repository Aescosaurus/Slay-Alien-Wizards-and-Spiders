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

        lvlChanger = Utility.FindInScene( "LevelChanger" )
            .GetComponent<ChangeLevel>();
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
        // Check == 0 instead of < 1 so if youre hit
        //  the fade out only triggers once.
        if( health == 0 )
        {
            lvlChanger.EndGame();
        }
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
    Timer invulTimer = new Timer( 2.5f );
    bool invul = false;
    ChangeLevel lvlChanger;
}
