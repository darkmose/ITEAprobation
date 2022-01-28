using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class PeopleCleanupSystem : ICleanupSystem
{
    private Contexts _contexts;
    private Transform _pooledObjectsRoot;

    public PeopleCleanupSystem(Contexts contexts, Transform pooledObjectsRoot)
    {
        _contexts = contexts;
        _pooledObjectsRoot = pooledObjectsRoot;
    }

    public void Cleanup()
    {
        var group = _contexts.game.GetGroup(GameMatcher.Player);
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            if (entity.isDead)
            {
                entity.view.Value.Unlink();
                entity.view.Value.transform.SetParent(_pooledObjectsRoot);
                entity.view.Value.SetActive(false);
                entity.Destroy();
            }
        }

    }
}
