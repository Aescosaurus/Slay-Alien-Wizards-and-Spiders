using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Assertions;

public class ParticleDropper
    :
    MonoBehaviour
{
    void Start()
    {
        particle = Utility.FindInScene( "PrefabManager" )
            .GetComponent<PrefabManagerScript>()
            .particle;
    }
    // void OnDestroy()
    // {
    //     CreateParticles( transform.position,
    //         Random.Range( 3,6 ) );
    // }
    public void CreateParticles( Vector2 pos,int amount )
    {
        Assert.IsNotNull( particle );

        for( int i = 0; i < amount; ++i )
        {
            GameObject part = Instantiate( particle );
            part.transform.position = ( Vector3 )pos;
        }
    }
    // 
    GameObject particle;
}
