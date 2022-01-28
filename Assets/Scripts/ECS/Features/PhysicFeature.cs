using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PhysicFeature : Feature
{
    public PhysicFeature(Contexts contexts) : base("Physic Feature")
    {
        Add(new TriggersHandleSystem(contexts));
        Add(new CollisionsHandleSystem(contexts));
        Add(new PhysicsCleanupSystem(contexts));
    }
}
