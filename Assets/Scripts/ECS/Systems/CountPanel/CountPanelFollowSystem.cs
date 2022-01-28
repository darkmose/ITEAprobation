using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CountPanelFollowSystem : IExecuteSystem
{
    private const float CountPanelHeight = 5f;
    private Contexts _contexts;

    public CountPanelFollowSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var group = _contexts.game.GetGroup(GameMatcher.Follow);
        var entities = group.GetEntities();

        foreach (var entity in entities)
        {
            if (entity.isCountPanel || entity.isEnemiesCountPanel)
            {
                var currPos = entity.view.Value.transform.position;
                currPos.y = CountPanelHeight;
                currPos.x = entity.follow.FolowTarget.transform.position.x;
                currPos.z = entity.follow.FolowTarget.transform.position.z;
                entity.ReplacePosition(currPos);
            }
        }
    }
}
