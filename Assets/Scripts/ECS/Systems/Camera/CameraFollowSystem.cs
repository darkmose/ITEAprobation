using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Entitas;

public class CameraFollowSystem : IExecuteSystem
{
    private const float CameraZPadding = 4.5f;
    private const float CameraHeight = 7f;
    private Contexts _contexts;

    public CameraFollowSystem(Contexts contexts)
    {
        _contexts = contexts;
    }

    public void Execute()
    {
        var group = _contexts.game.GetGroup(GameMatcher.Follow);
        var entities = group.GetEntities();
        foreach (var entity in entities)
        {
            if (entity.isCamera)
            {
                var currPos = entity.view.Value.transform.position;
                currPos.y = CameraHeight;
                currPos.z = entity.follow.FolowTarget.transform.position.z - CameraZPadding;
                entity.ReplacePosition(currPos);
            }
        }
    }

}
