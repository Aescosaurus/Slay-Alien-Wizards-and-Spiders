using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class FadeOutOnPress
    :
    MonoBehaviour
{
    void Start()
    {
        sprRend = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        Assert.IsNotNull( axis );
        Assert.IsNotNull( sprRend );
        if( sprRend.color.a > 0.0f &&
            Input.GetAxis( axis ) != 0.0f )
        {
            sprRend.color = new Color( 1.0f,1.0f,1.0f,
                sprRend.color.a - alphaSub );
        }
    }
    // 
    [SerializeField] string axis;
    SpriteRenderer sprRend;
    const float alphaSub = 0.04f;
}
