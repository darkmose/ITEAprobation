using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFeature : Feature
{
    public CameraFeature(Contexts contexts) : base("Camera System")
    {
        Add(new CameraFollowSystem(contexts));
    }
}
