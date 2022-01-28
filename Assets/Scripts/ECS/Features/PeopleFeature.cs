using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class PeopleFeature : Feature
{
    public PeopleFeature(Contexts contexts, Transform parentTransform, Transform pooledObjRoot, GameConfig gameConfig) : base("People Feature")
    {
        Add(new PeopleGroupInitSystem(contexts, parentTransform.gameObject, gameConfig));

        Add(new PeopleGroupMoveSystem(contexts, gameConfig));
        Add(new PeopleGroupControlXSystem(contexts, gameConfig));
        Add(new PeopleAddSystem(contexts, parentTransform, gameConfig));
        Add(new PeopleUpCounterSystem(contexts));
        Add(new PeopleDownCounterSystem(contexts));
        Add(new PeopleMoveToBaseSystem(contexts, gameConfig));

        Add(new PeopleCleanupSystem(contexts, pooledObjRoot));
    }
}
