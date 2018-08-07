using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FadeOut
    :
    MonoBehaviour
{
    void Start()
    {
        rend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Assert.IsNotNull( rend );

        if( fading )
        {
            var temp = rend.color;
            temp.a += alphaSubAmount;
            if( temp.a > 1.0f ) temp.a = 1.0f;
            rend.color = temp;
        }
    }
    public void StartFadingOut()
    {
        fading = true;
        // Cast to Vec2 to not be z of minus whatever.
        transform.position = ( Vector2 )Camera.main.transform.position;

        var temp = rend.color;
        temp.a = 0.0f;
        rend.color = temp;
    }
    // 
    bool fading = false;
    SpriteRenderer rend;
    const float alphaSubAmount = 0.002f;
}
