using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet
    :
    MonoBehaviour
{
    public void SetPos( Vector3 pos )
    {
        transform.position = pos;
    }
    public void SetVel( Vector2 dir )
    {
        GetComponent<Rigidbody2D>()
            .AddForce( dir * speed );
    }
    // 
    const float speed = 872.5f;
}
