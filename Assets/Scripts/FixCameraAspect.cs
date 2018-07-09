using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixCameraAspect
    :
    MonoBehaviour
{
    void Start()
    {
        const float width = 16.0f;
        const float height = 9.0f;

        Camera.main.aspect = width / height;
        // Camera.main.ResetAspect();
    }
}
