using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;
using Entitas.Unity;

public class EnemyGroupCleanupSystem : ICleanupSystem
{
    private Contexts _contexts;

    public EnemyGroupCleanupSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Cleanup()
    {
        var group = _contexts.game.GetGroup(GameMatcher.AllOf(GameMatcher.EnemyGroup, GameMatcher.GroupDead));        
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            GameObject.Destroy(entity.view.Value);
            entity.Destroy();

            var countPanelEntity = _contexts.game.GetGroup(GameMatcher.EnemiesCountPanel).GetSingleEntity();
            GameObject.Destroy(countPanelEntity.view.Value);
            countPanelEntity.Destroy();
        }

    }
}
