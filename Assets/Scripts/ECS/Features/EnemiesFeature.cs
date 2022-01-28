using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class EnemiesFeature : Feature
{
    public EnemiesFeature(Contexts contexts, GameConfig gameConfig, Transform pooledObjectsRoot)
    {
        Add(new EnemySpawnerSpawnSystem(contexts, gameConfig));
        Add(new EnemyScanSystem(contexts));
        Add(new EnemiesUpCounterSystem(contexts));
        Add(new EnemiesDownCounterSystem(contexts));

        Add(new EnemyCleanupSystem(contexts, pooledObjectsRoot));
        Add(new EnemyGroupCleanupSystem(contexts));
    }
}
