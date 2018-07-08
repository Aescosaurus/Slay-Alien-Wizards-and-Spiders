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
        GameObject[] list = GameObject
            .FindGameObjectsWithTag( "PrefabManager" );
        Assert.IsTrue( list.Length == 1 );
        PrefabManagerScript script = list[0]
            .GetComponent<PrefabManagerScript>();
        particle = script.particle;
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
