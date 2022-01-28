using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLinker : MonoBehaviour
{
    void Start()
    {
        if (TryGetComponent(out Canvas canvas))
        {
            if (canvas.worldCamera == null)
            {
                canvas.worldCamera = Camera.main;
            }
        }
    }
}
